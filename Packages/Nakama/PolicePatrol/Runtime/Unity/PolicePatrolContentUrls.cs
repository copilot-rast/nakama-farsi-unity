using System;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace PolicePatrol.Sdk.Unity
{
    public static class PolicePatrolContentUrls
    {
        public const string RuntimeVariable = "{PolicePatrol.Sdk.Unity.PolicePatrolContentUrls.BaseUrl}";

        public static string BaseUrl { get; set; } = string.Empty;

        public static string CatalogUrl { get; private set; }

        public static string CatalogHash { get; private set; }

        public static string PackVersion { get; private set; }

        public static bool IsResolved => !string.IsNullOrEmpty(BaseUrl);

        public static string Platform =>
            Application.platform == RuntimePlatform.Android ? "Android"
            : Application.platform == RuntimePlatform.IPhonePlayer ? "iOS"
            : Application.platform == RuntimePlatform.WindowsEditor ? "StandaloneWindows64"
            : Application.platform == RuntimePlatform.OSXEditor ? "StandaloneOSX"
            : Application.platform == RuntimePlatform.LinuxEditor ? "StandaloneLinux64"
            : Application.platform.ToString();

        public static void Resolve(Action<ApiResult<JObject>> onComplete = null) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var r = await c.Rpc("assets_content_index", new JObject { ["platform"] = Platform, ["appVersion"] = Application.version }, true).ConfigureAwait(false);
                if (r?["pack"] is JObject pack)
                {
                    BaseUrl = ((string)pack["baseUrl"] ?? string.Empty).TrimEnd('/');
                    CatalogUrl = (string)pack["catalogUrl"];
                    CatalogHash = (string)pack["catalogHash"];
                    PackVersion = (string)pack["version"];
                }

                return r as JObject ?? new JObject();
            }, null, "assets_content_index");
    }
}
