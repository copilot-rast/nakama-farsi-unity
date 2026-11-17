using System;
using NakamaFarsi.Sdk;
using NF = NakamaFarsi.Sdk;

namespace PolicePatrol.Sdk
{
    public static class PolicePatrolSdk
    {
        public static ApiClient Client { get; private set; }

        public static bool IsInitialized => Client != null;

        public static ApiClient Initialize(SdkOptions options, NakamaFarsiClient core = null, ISdkLogger logger = null)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            core = core ?? new NakamaFarsiClient(CoreOptions(options), logger: logger == null ? null : new CoreLogger(logger));
            Client = new ApiClient(options, core, logger);
            if (!string.IsNullOrEmpty(options.Language))
            {
                core.Language = options.Language;
            }

            return Client;
        }

        public static NakamaFarsiOptions CoreOptions(SdkOptions options)
        {
            var o = NakamaFarsiOptions.FromUrl(options.BaseUrl, options.ServerKey);
            o.Language = string.IsNullOrEmpty(options.Language) ? "fa" : options.Language;
            o.TimeoutSeconds = Math.Max(1, options.TimeoutSeconds);
            o.UseSocket = options.UseSocket;
            o.HttpKey = string.IsNullOrEmpty(options.HttpKey) ? null : options.HttpKey;
            o.Logging = options.Logging;
            o.StorePrefix = "PolicePatrol.Sdk.";
            return o;
        }

        public static void Shutdown() => Client = null;

        public static void SetLanguage(string language)
        {
            if (Client != null)
            {
                Client.Language = language;
            }
        }

        internal static bool TryGetClient<T>(Action<ApiResult<T>> onComplete, out ApiClient client)
        {
            client = Client;
            if (client != null)
            {
                return true;
            }

            onComplete?.Invoke(ApiResult<T>.Fail(ApiError.NotInitialized));
            return false;
        }

        internal static void Run<T>(Action<ApiResult<T>> onComplete, Func<ApiClient, System.Threading.Tasks.Task<T>> work, System.Collections.Generic.IReadOnlyDictionary<string, string> aliases = null, string what = null)
        {
            if (!TryGetClient(onComplete, out var client))
            {
                return;
            }

            client.Run(() => work(client), onComplete, aliases, what);
        }
    }
}
