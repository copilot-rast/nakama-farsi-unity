using System;
using System.Collections.Generic;
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
        }

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

        public string VerificationToken { get; internal set; }

        internal string VerificationPurpose { get; set; }

        public event Action SessionExpired;

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
