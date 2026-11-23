using System;
using System.Collections.Generic;
using System.IO;
using PolicePatrol.Sdk.Assets;
using UnityEngine;

namespace PolicePatrol.Sdk.Unity
{
    public static class PolicePatrolAssets
    {
        private static IAssetCache _cache;
        private static string _cacheWorkspace;
        private static PolicePatrolAssetRegistry _registry;

        public static bool ApplyInEditor { get; set; }

        public static bool? RequireOnline
        {
            get => AssetProvider.RequireOnline;
            set => AssetProvider.RequireOnline = value;
        }

        public static TimeSpan? MaxCacheAge
        {
            get => AssetProvider.MaxCacheAge;
            set => AssetProvider.MaxCacheAge = value;
        }

        public static AssetCacheState LastLoad(string folder) => (Cache as IAssetCacheMeta)?.LoadState(folder);

        public static PolicePatrolAssetRegistry Registry
        {
            get => _registry != null ? _registry : _registry = PolicePatrolAssetRegistry.Load();
            set => _registry = value;
        }

        public static IAssetCache Cache
        {
            get
            {
                var workspace = PolicePatrolSdk.Client?.Options.Workspace;
                if (_cache == null || _cacheWorkspace != workspace)
                {
                    _cacheWorkspace = workspace;
                    _cache = new FileAssetCache(Path.Combine(Application.persistentDataPath, "PolicePatrol", "assets", string.IsNullOrEmpty(workspace) ? "default" : workspace));
                }

                return _cache;
            }
        }

        public static AssetJsonOptions JsonOptions(PolicePatrolAssetRegistry registry)
        {
            var options = new AssetJsonOptions { References = new RegistryReferences(registry) };
            options.Converters.Add(new UnityAssetConverters());
            return options;
        }

        public static void LoadFolder(string folder, Action<ApiResult<AssetFolder>> onComplete) =>
            AssetProvider.LoadFolder(folder, Cache, onComplete);

        public static void LoadAndApply(string folder, Action<ApiResult<AssetApplyReport>> onComplete) =>
            LoadFolder(folder, result => onComplete?.Invoke(result.IsSuccess
                ? ApiResult<AssetApplyReport>.Ok(ApplyAll(result.Data), result.Code)
                : ApiResult<AssetApplyReport>.Fail(result.Error)));

        public static AssetApplyReport ApplyAll(AssetFolder folder)
        {
            if (Application.isEditor && !ApplyInEditor)
            {
                Debug.LogWarning("[PolicePatrol] Server data was loaded but not written onto the project's assets in the editor. Set PolicePatrolAssets.ApplyInEditor = true to try it in Play Mode, or use Tools > PolicePatrol > Asset Sync > Pull.");
                return new AssetApplyReport(0, Array.Empty<string>(), Array.Empty<string>(), true, folder?.Offline ?? false);
            }

            var registry = Registry;
            var options = JsonOptions(registry);
            var missing = new List<string>();
            var warnings = new List<string>();
            var applied = 0;
            foreach (var asset in folder?.Assets ?? Array.Empty<GameAsset>())
            {
                var target = registry != null ? registry.FindAsset(asset.AssetId) : null;
                if (target == null)
                {
                    missing.Add(asset.AssetId);
                    continue;
                }

                foreach (var warning in AssetObjectJson.Apply(asset.Data, target, options).Warnings)
                {
                    warnings.Add(asset.AssetId + "." + warning);
                }

                applied++;
            }

            return new AssetApplyReport(applied, missing.ToArray(), warnings.ToArray(), false, folder?.Offline ?? false);
        }

        public static AssetApplyResult ApplyTo(GameAsset asset, ScriptableObject target) =>
            AssetObjectJson.Apply(asset.Data, target, JsonOptions(Registry));

        public static T Create<T>(GameAsset asset) where T : ScriptableObject
        {
            var instance = ScriptableObject.CreateInstance<T>();
            instance.name = asset.Name;
            ApplyTo(asset, instance);
            return instance;
        }

        public static void ClearCache() => Cache.Clear();
    }
}
