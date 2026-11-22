using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NakamaFarsi.Sdk;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NF = NakamaFarsi.Sdk;

namespace PolicePatrol.Sdk
{
    public sealed class ApiClient
    {
        private readonly ISdkLogger _logger;

        public ApiClient(SdkOptions options, NakamaFarsiClient core, ISdkLogger logger = null)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));
            Core = core ?? throw new ArgumentNullException(nameof(core));
            _logger = logger;
            Core.Session.SessionExpired += () => Core.Dispatcher.Post(() => SessionExpired?.Invoke());
            Core.Notifications.Received += n =>
            {
                if (ReferenceEquals(PolicePatrolSdk.Client, this) && n != null)
                {
                    Stats.StatsProvider.OnNotification(n.Code, n.Content);
                }
            };
            RestoreOtp();
        }

        public static readonly TimeSpan DefaultOtpLifetime = TimeSpan.FromMinutes(10);

        private string OtpStoreKey => Core.Options.StorePrefix + "otp.pending";

        public SdkOptions Options { get; }

        public NakamaFarsiClient Core { get; }

        public ItemKeys Items { get; } = new ItemKeys();

        public string Language
        {
            get => Core.Language;
            set
            {
                Core.Language = string.IsNullOrEmpty(value) ? "fa" : value;
                _ = Core.RefreshErrorCatalogAsync();
            }
        }

        public bool HasSession => Core.Session.Current != null;

        public string VerificationToken { get; private set; }

        internal string VerificationPurpose { get; private set; }

        public DateTimeOffset? VerificationExpiresAt { get; private set; }

        public DateTimeOffset? VerificationResendAt { get; private set; }

        internal void RememberOtp(string phone, string purpose, JToken answer)
        {
            var seconds = answer?["expiresIn"] is JValue v && (v.Type == JTokenType.Integer || v.Type == JTokenType.Float) ? (double)v : 0;
            var resend = answer?["resendAfter"] is JValue r && (r.Type == JTokenType.Integer || r.Type == JTokenType.Float) ? (double)r : 0;
            VerificationToken = phone;
            VerificationPurpose = purpose;
            VerificationExpiresAt = DateTimeOffset.UtcNow + (seconds > 0 ? TimeSpan.FromSeconds(seconds) : DefaultOtpLifetime);
            VerificationResendAt = resend > 0 ? DateTimeOffset.UtcNow + TimeSpan.FromSeconds(resend) : (DateTimeOffset?)null;
            Core.Store.Set(OtpStoreKey, new JObject
            {
                ["phone"] = phone,
                ["purpose"] = purpose,
                ["expiresAt"] = VerificationExpiresAt.Value.ToUnixTimeSeconds(),
                ["resendAt"] = VerificationResendAt?.ToUnixTimeSeconds(),
            }.ToString(Formatting.None));
            Core.Store.Save();
        }

        internal void ForgetOtp()
        {
            VerificationToken = null;
            VerificationPurpose = null;
            VerificationExpiresAt = null;
            VerificationResendAt = null;
            Core.Store.Delete(OtpStoreKey);
            Core.Store.Save();
        }

        private void RestoreOtp()
        {
            var text = Core.Store.Get(OtpStoreKey);
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            try
            {
                var saved = JObject.Parse(text);
                var expires = DateTimeOffset.FromUnixTimeSeconds((long)saved["expiresAt"]);
                if (expires > DateTimeOffset.UtcNow && !string.IsNullOrEmpty((string)saved["phone"]))
                {
                    VerificationToken = (string)saved["phone"];
                    VerificationPurpose = (string)saved["purpose"];
                    VerificationExpiresAt = expires;
                    VerificationResendAt = saved["resendAt"] is JValue at && at.Type == JTokenType.Integer ? DateTimeOffset.FromUnixTimeSeconds((long)at) : (DateTimeOffset?)null;
                    return;
                }
            }
            catch (Exception)
            {
            }

            ForgetOtp();
        }

        public event Action SessionExpired;

        internal NF.ApiException WithResendWait(NF.ApiException e, string phone)
        {
            var error = e.Error;
            if (error.Code != "OTP_TOO_SOON" || error.RetryAfterSeconds != null || VerificationResendAt == null || string.IsNullOrEmpty(phone) || !SamePhone(phone, VerificationToken))
            {
                return e;
            }

            var wait = (int)Math.Ceiling((VerificationResendAt.Value - DateTimeOffset.UtcNow).TotalSeconds);
            if (wait <= 0)
            {
                return e;
            }

            var meta = error.Meta != null ? (JObject)error.Meta.DeepClone() : new JObject();
            meta["retryAfter"] = wait;
            var message = Core.Errors.TryResolve(error.Code, meta, out _, out var filled) ? filled : error.Message;
            return new NF.ApiException(new NF.ApiError(error.Code, error.Status, message, meta, wait, error.Field, error.Lang), e);
        }

        private static bool SamePhone(string a, string b)
        {
            string Tail(string p) => new string((p ?? string.Empty).Where(char.IsDigit).ToArray()) is var d && d.Length >= 10 ? d.Substring(d.Length - 10) : d;
            return Tail(a) == Tail(b);
        }

        internal async Task<JToken> Rpc(string id, object payload, bool readOnly, bool idempotent = false, bool anonymous = false)
        {
            var body = await Core.CallRpcAsync(id, payload is string s ? s : JsonConvert.SerializeObject(payload ?? new JObject()), new RpcCallOptions { ReadOnly = readOnly, Idempotent = idempotent, AllowAnonymous = anonymous }).ConfigureAwait(false);
            if (Options.Logging)
            {
                _logger?.Log("[PolicePatrol.Sdk] rpc " + id + " -> ok" + (Core.Socket.IsConnected && Options.UseSocket ? " (socket)" : " (http)"));
            }

            try
            {
                return string.IsNullOrWhiteSpace(body) ? new JObject() : JToken.Parse(body);
            }
            catch (JsonException e)
            {
                throw new NF.ApiException(NF.ApiError.InvalidResponse(e.Message), e);
            }
        }

        internal void Run<T>(Func<Task<T>> work, Action<ApiResult<T>> onComplete, IReadOnlyDictionary<string, string> aliases = null, string what = null)
        {
            Task<T> task;
            try
            {
                task = work();
            }
            catch (Exception e)
            {
                task = Task.FromException<T>(e);
            }

            task.ContinueWith(t =>
            {
                ApiResult<T> result;
                if (t.IsFaulted || t.IsCanceled)
                {
                    var e = t.Exception?.GetBaseException();
                    var error = e is NF.ApiException api
                        ? ErrorAliases.Convert(api.Error, aliases)
                        : e is SdkFailure sdk ? sdk.Error
                        : new ApiError(0, ApiError.NetworkErrorCode, null, e?.Message ?? "cancelled");
                    if (Options.Logging)
                    {
                        _logger?.Error("[PolicePatrol.Sdk] " + (what ?? "call") + " -> " + error.Status + " " + error.Code + (error.ServerCode != null && error.ServerCode != error.Code ? " (" + error.ServerCode + ")" : string.Empty));
                    }

                    result = ApiResult<T>.Fail(error);
                }
                else
                {
                    result = ApiResult<T>.Ok(t.Result);
                }

                if (onComplete != null)
                {
                    Core.Dispatcher.Post(() => onComplete(result));
                }
            }, TaskScheduler.Default);
        }
    }

    internal sealed class SdkFailure : Exception
    {
        public SdkFailure(ApiError error)
            : base(error.Message)
        {
            Error = error;
        }

        public ApiError Error { get; }
    }
}
