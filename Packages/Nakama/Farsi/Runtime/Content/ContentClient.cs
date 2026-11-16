using System;
using System.Threading;
using System.Threading.Tasks;
using NakamaFarsi.Sdk.Generated;

namespace NakamaFarsi.Sdk.Content
{
    public static class NakamaFarsiContent
    {
        public static string BaseUrl { get; set; } = string.Empty;

        public static string CatalogUrl { get; set; } = string.Empty;

        public static string CatalogHash { get; set; } = string.Empty;

        public static string PackVersion { get; set; } = string.Empty;
    }

    public sealed class ContentClient
    {
        private readonly NakamaFarsiRpcs _rpcs;

        public ContentClient(NakamaFarsiRpcs rpcs)
        {
            _rpcs = rpcs ?? throw new ArgumentNullException(nameof(rpcs));
        }

        public ContentCatalogResponse.PackData Current { get; private set; }

        public async Task<ContentCatalogResponse.PackData> GetCatalogAsync(string platform, string appVersion, CancellationToken ct = default)
        {
            var res = await _rpcs.Content.CatalogAsync(new ContentCatalogRequest { Platform = platform, AppVersion = appVersion }, ct).ConfigureAwait(false);
            Current = res.Pack;
            NakamaFarsiContent.BaseUrl = res.Pack?.BaseUrl ?? string.Empty;
            NakamaFarsiContent.CatalogUrl = res.Pack?.CatalogUrl ?? string.Empty;
            NakamaFarsiContent.CatalogHash = res.Pack?.CatalogHash ?? string.Empty;
            NakamaFarsiContent.PackVersion = res.Pack?.Version ?? string.Empty;
            return res.Pack;
        }

        public static string PlatformName(string runtimePlatform)
        {
            switch (runtimePlatform)
            {
                case "Android":
                    return "Android";
                case "IPhonePlayer":
                    return "iOS";
                case "WindowsPlayer":
                case "WindowsEditor":
                    return "StandaloneWindows64";
                case "OSXPlayer":
                case "OSXEditor":
                    return "StandaloneOSX";
                case "LinuxPlayer":
                case "LinuxEditor":
                    return "StandaloneLinux64";
                case "WebGLPlayer":
                    return "WebGL";
                default:
                    return runtimePlatform ?? string.Empty;
            }
        }
    }
}
