using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NakamaFarsi.Sdk.Payments
{
    public enum PurchaseOutcome
    {
        Success,
        Pending,
        Redirect,
        Cancelled,
        Failed,
    }

    public sealed class PurchaseResult
    {
        public PurchaseOutcome Outcome { get; set; }
        public string PaymentId { get; set; }
        public string Status { get; set; }
        public bool RewardGranted { get; set; }
        public JArray Rewards { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
        public string RedirectUrl { get; set; }
        public ApiError ApiError { get; set; }
        public JObject Raw { get; set; }

        public bool IsSuccess => Outcome == PurchaseOutcome.Success;
    }

    public sealed class PaymentClient
    {
        public static readonly TimeSpan DefaultPollInterval = TimeSpan.FromSeconds(2);
        public static readonly TimeSpan DefaultPollTimeout = TimeSpan.FromMinutes(1);
        public static readonly TimeSpan DefaultSubmitTimeout = TimeSpan.FromMinutes(1);

        private static readonly HashSet<string> Accepted = new HashSet<string> { "REWARD_PENDING", "PRODUCT_ALREADY_BOUGHT", "PRIZE_ALREADY_OWNED" };

        private readonly NakamaFarsiClient _client;
        private readonly Dictionary<string, StoreConfig> _configs = new Dictionary<string, StoreConfig>();

        public PaymentClient(NakamaFarsiClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public TimeSpan PollInterval { get; set; } = DefaultPollInterval;
        public TimeSpan PollTimeout { get; set; } = DefaultPollTimeout;
        public TimeSpan SubmitTimeout { get; set; } = DefaultSubmitTimeout;
        public Func<TimeSpan, CancellationToken, Task> Delay { get; set; } = (wait, ct) => Task.Delay(wait, ct);

        public event Action<PurchaseResult> Completed;

        public static bool IsRetryable(ApiError error) =>
            error != null && (error.IsNetworkError || error.Code == ApiError.TimeoutCode || error.Status == 429 || error.Status >= 500 || error.Code == "STORE_UNAVAILABLE");

        public Task<JObject> CatalogAsync(string categoryKey = null, CancellationToken ct = default)
        {
            var body = new JObject { ["lang"] = _client.Language };
            if (!string.IsNullOrEmpty(categoryKey))
            {
                body["categoryKey"] = categoryKey;
            }

            return Call("economy_catalog", body, RpcCallOptions.Read, ct);
        }

        public Task<JObject> BalancesAsync(CancellationToken ct = default) => Call("economy_balances", new JObject(), RpcCallOptions.Read, ct);

        public Task<JObject> HistoryAsync(int limit = 20, string cursor = null, CancellationToken ct = default) =>
            Call("economy_payments_mine", new JObject { ["limit"] = limit, ["cursor"] = cursor ?? string.Empty, ["lang"] = _client.Language }, RpcCallOptions.Read, ct);

        public async Task<StoreConfig> StoreConfigAsync(string method, CancellationToken ct = default)
        {
            if (_configs.TryGetValue(method, out var cached))
            {
                return cached;
            }

            var raw = await Call("economy_store_config", new JObject { ["method"] = method }, RpcCallOptions.Read, ct).ConfigureAwait(false);
            var config = new StoreConfig
            {
                Method = (string)raw["method"] ?? method,
                Sandbox = (bool?)raw["sandbox"] ?? false,
                RsaPublicKey = (string)raw["rsaPublicKey"] ?? string.Empty,
                PackageName = (string)raw["packageName"] ?? string.Empty,
            };
            _configs[method] = config;
            return config;
        }

        public async Task<PurchaseResult> BuyAsync(string productId, string method, IStoreBilling store = null, string giftCode = null, string offerId = null, Action<string> openUrl = null, CancellationToken ct = default)
        {
            if (string.IsNullOrEmpty(productId))
            {
                throw new ApiException(ApiError.Invalid("productId", "required"));
            }

            if (PaymentMethods.IsStore(method) && store == null)
            {
                throw new ApiException(ApiError.Invalid("store", "a store billing adapter is needed for " + method));
            }

            var body = new JObject { ["productId"] = productId, ["method"] = method, ["lang"] = _client.Language };
            if (!string.IsNullOrEmpty(giftCode))
            {
                body["giftCode"] = giftCode;
            }

            if (!string.IsNullOrEmpty(offerId))
            {
                body["offerId"] = offerId;
            }

            JObject start;
            try
            {
                start = await Call("economy_purchase_start", body, RpcCallOptions.Write, ct).ConfigureAwait(false);
            }
            catch (ApiException e)
            {
                return Finish(new PurchaseResult { Outcome = PurchaseOutcome.Failed, Error = e.Error.Code, ApiError = e.Error });
            }

            var paymentId = (string)start["paymentId"];
            switch ((string)start["status"])
            {
                case "success":
                    return Finish(FromServer(start, PurchaseOutcome.Success));
                case "redirect":
                    var redirect = FromServer(start, PurchaseOutcome.Redirect);
                    redirect.RedirectUrl = (string)start["redirectUrl"];
                    openUrl?.Invoke(redirect.RedirectUrl);
                    return redirect;
                case "store":
                    return Finish(await StoreFlowAsync(store, paymentId, (string)start["sku"], (string)start["developerPayload"] ?? paymentId, ct).ConfigureAwait(false));
                default:
                    return Finish(FromServer(start, PurchaseOutcome.Failed));
            }
        }

        public async Task<PurchaseResult> StatusAsync(string paymentId, CancellationToken ct = default)
        {
            var raw = await Call("economy_purchase_status", new JObject { ["paymentId"] = paymentId, ["lang"] = _client.Language }, RpcCallOptions.Read, ct).ConfigureAwait(false);
            return FromStatus(raw);
        }

        public async Task<PurchaseResult> WaitAsync(string paymentId, TimeSpan? timeout = null, CancellationToken ct = default)
        {
            var until = DateTime.UtcNow + (timeout ?? PollTimeout);
            PurchaseResult last = null;
            while (true)
            {
                try
                {
                    last = await StatusAsync(paymentId, ct).ConfigureAwait(false);
                    if (last.Outcome != PurchaseOutcome.Pending)
                    {
                        return Finish(last);
                    }
                }
                catch (ApiException e) when (IsRetryable(e.Error))
                {
                    last = last ?? new PurchaseResult { Outcome = PurchaseOutcome.Pending, PaymentId = paymentId, Error = e.Error.Code, ApiError = e.Error };
                }
                catch (ApiException e)
                {
                    return Finish(new PurchaseResult { Outcome = PurchaseOutcome.Failed, PaymentId = paymentId, Error = e.Error.Code, ApiError = e.Error });
                }

                if (DateTime.UtcNow >= until)
                {
                    return last;
                }

                await Delay(PollInterval, ct).ConfigureAwait(false);
            }
        }

        public async Task<PurchaseResult> SubmitAsync(string paymentId, string purchaseToken, CancellationToken ct = default) =>
            await Retry(() => Call("economy_purchase_submit", new JObject { ["paymentId"] = paymentId, ["token"] = purchaseToken }, RpcCallOptions.Write, ct), paymentId, ct).ConfigureAwait(false);

        public async Task<PurchaseResult> ReviewAsync(string method, string sku, string purchaseToken, CancellationToken ct = default) =>
            await Retry(() => Call("economy_purchase_review", new JObject { ["method"] = method, ["sku"] = sku, ["token"] = purchaseToken }, RpcCallOptions.Write, ct), null, ct).ConfigureAwait(false);

        public async Task<IReadOnlyList<PurchaseResult>> RecoverAsync(IStoreBilling store, CancellationToken ct = default)
        {
            var results = new List<PurchaseResult>();
            if (store == null)
            {
                return results;
            }

            var owned = await Wrap<IReadOnlyList<StorePurchase>>(done => store.GetPurchases(done)).ConfigureAwait(false);
            foreach (var purchase in owned ?? Array.Empty<StorePurchase>())
            {
                if (purchase.IsSubscription || string.IsNullOrEmpty(purchase.PurchaseToken))
                {
                    continue;
                }

                var result = await ReviewAsync(store.Method, purchase.Sku, purchase.PurchaseToken, ct).ConfigureAwait(false);
                if (ServerAccepted(result))
                {
                    await Wrap<bool>(done => store.Consume(purchase.PurchaseToken, done)).ConfigureAwait(false);
                    Finish(result);
                }

                results.Add(result);
            }

            return results;
        }

        public static bool ServerAccepted(PurchaseResult result) =>
            result != null && result.Status == "success" && (result.RewardGranted || string.IsNullOrEmpty(result.Error) || Accepted.Contains(result.Error));

        private async Task<PurchaseResult> StoreFlowAsync(IStoreBilling store, string paymentId, string sku, string payload, CancellationToken ct)
        {
            var bought = await Wrap<StorePurchaseResult>(done => store.Purchase(sku, payload, done)).ConfigureAwait(false);
            if (bought == null || bought.IsCancelled)
            {
                return new PurchaseResult { Outcome = PurchaseOutcome.Cancelled, PaymentId = paymentId, Status = "pending" };
            }

            if (!bought.IsSuccess || string.IsNullOrEmpty(bought.PurchaseToken))
            {
                return new PurchaseResult { Outcome = PurchaseOutcome.Failed, PaymentId = paymentId, Status = "pending", Error = bought.Error ?? "STORE_PURCHASE_FAILED" };
            }

            var result = await SubmitAsync(paymentId, bought.PurchaseToken, ct).ConfigureAwait(false);
            if (ServerAccepted(result))
            {
                await Wrap<bool>(done => store.Consume(bought.PurchaseToken, done)).ConfigureAwait(false);
            }

            return result;
        }

        private async Task<PurchaseResult> Retry(Func<Task<JObject>> call, string paymentId, CancellationToken ct)
        {
            var until = DateTime.UtcNow + SubmitTimeout;
            while (true)
            {
                try
                {
                    var raw = await call().ConfigureAwait(false);
                    var result = FromStatus(raw);
                    if (result.Error == "STORE_UNAVAILABLE" && result.Status == "pending" && DateTime.UtcNow < until)
                    {
                        await Delay(PollInterval, ct).ConfigureAwait(false);
                        continue;
                    }

                    return result;
                }
                catch (ApiException e) when (IsRetryable(e.Error) && DateTime.UtcNow < until)
                {
                    await Delay(PollInterval, ct).ConfigureAwait(false);
                }
                catch (ApiException e)
                {
                    return new PurchaseResult
                    {
                        Outcome = IsRetryable(e.Error) ? PurchaseOutcome.Pending : PurchaseOutcome.Failed,
                        PaymentId = paymentId,
                        Status = "pending",
                        Error = e.Error.Code,
                        ApiError = e.Error,
                    };
                }
            }
        }

        private static PurchaseResult FromStatus(JObject raw)
        {
            var status = (string)raw["status"];
            var outcome = status == "success" ? PurchaseOutcome.Success : status == "pending" ? PurchaseOutcome.Pending : PurchaseOutcome.Failed;
            return FromServer(raw, outcome);
        }

        private static PurchaseResult FromServer(JObject raw, PurchaseOutcome outcome) => new PurchaseResult
        {
            Outcome = outcome,
            PaymentId = (string)raw["paymentId"],
            Status = (string)raw["status"],
            RewardGranted = (bool?)raw["rewardGranted"] ?? (outcome == PurchaseOutcome.Success && raw["rewards"] != null),
            Rewards = raw["rewards"] as JArray ?? new JArray(),
            Message = (string)raw["purchaseMessage"] ?? string.Empty,
            Error = (string)raw["error"],
            Raw = raw,
        };

        private PurchaseResult Finish(PurchaseResult result)
        {
            if (result != null && result.Outcome != PurchaseOutcome.Redirect && result.Outcome != PurchaseOutcome.Pending)
            {
                Completed?.Invoke(result);
            }

            return result;
        }

        private async Task<JObject> Call(string id, JObject body, RpcCallOptions options, CancellationToken ct)
        {
            var text = await _client.CallRpcAsync(id, body.ToString(Formatting.None), options, ct).ConfigureAwait(false);
            return string.IsNullOrWhiteSpace(text) ? new JObject() : JObject.Parse(text);
        }

        private static Task<T> Wrap<T>(Action<Action<T>> start)
        {
            var tcs = new TaskCompletionSource<T>(TaskCreationOptions.RunContinuationsAsynchronously);
            try
            {
                start(value => tcs.TrySetResult(value));
            }
            catch (Exception e)
            {
                tcs.TrySetException(e);
            }

            return tcs.Task;
        }
    }
}
