using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PolicePatrol.Sdk.Unity;
using UnityEditor;
using UnityEngine;

namespace PolicePatrol.Sdk.Editor
{
    public sealed class AssetSyncSettings
    {
        public const string RegistryPath = "Assets/PolicePatrol/Resources/" + PolicePatrolAssetRegistry.ResourceName + ".asset";

        private const string FilePath = "ProjectSettings/PolicePatrolAssets.json";
        private const string ApiKeyPrefix = "PolicePatrol.Assets.ApiKey.";

        private static readonly JsonSerializerSettings Json = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            ObjectCreationHandling = ObjectCreationHandling.Replace,
            Formatting = Formatting.Indented,
        };

        public string ServerUrl { get; set; } = string.Empty;

        public string Workspace { get; set; } = "default";

        public List<string> Folders { get; set; } = new List<string>();

        public List<string> IdFields { get; set; } = new List<string> { "id", "Id" };

        public List<string> ExcludedTypes { get; set; } = new List<string>();

        public string ContentKey { get; set; } = "game-content";

        [JsonIgnore]
        public string ResolvedContentKey => Regex.Replace(
            (ContentKey ?? string.Empty).Trim().Replace("{version}", PlayerSettings.bundleVersion ?? string.Empty),
            "[^A-Za-z0-9._-]",
            "-");

        [JsonIgnore]
        public string ApiKey
        {
            get => EditorPrefs.GetString(ApiKeyPrefix + Application.dataPath, string.Empty);
            set => EditorPrefs.SetString(ApiKeyPrefix + Application.dataPath, (value ?? string.Empty).Trim());
        }

        [JsonIgnore]
        public string Scope => (ServerUrl ?? string.Empty).Trim().TrimEnd('/') + "|" + Workspace;

        [JsonIgnore]
        public string ServerProblem =>
            string.IsNullOrWhiteSpace(ServerUrl) ? "Set the server URL."
            : string.IsNullOrWhiteSpace(Workspace) ? "Set the workspace."
            : string.IsNullOrWhiteSpace(ApiKey) ? "Paste an API key from the panel (System → API keys) in Tools > PolicePatrol > Asset Sync."
            : null;

        [JsonIgnore]
        public string Problem => ServerProblem ?? (Folders.Count == 0 ? "Add at least one folder to sync." : null);

        public static AssetSyncSettings Load()
        {
            var settings = File.Exists(FilePath)
                ? JsonConvert.DeserializeObject<AssetSyncSettings>(File.ReadAllText(FilePath), Json) ?? new AssetSyncSettings()
                : new AssetSyncSettings();

            var config = PolicePatrolSdkConfig.Load();
            if (string.IsNullOrWhiteSpace(settings.ServerUrl) && config != null)
            {
                settings.ServerUrl = config.BaseUrl;
                settings.Workspace = config.Workspace;
            }

            return settings;
        }

        public void Save() => File.WriteAllText(FilePath, JsonConvert.SerializeObject(this, Json));
    }
}
