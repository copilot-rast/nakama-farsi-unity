using System.Linq;
using PolicePatrol.Sdk.Assets;
using PolicePatrol.Sdk.Unity;
using UnityEditor;
using UnityEngine;

namespace PolicePatrol.Sdk.Editor
{
    public static class AssetRegistryBuilder
    {
        public static PolicePatrolAssetRegistry Build(AssetScanResult scan)
        {
            EnsureFolder(AssetSyncSettings.RegistryPath.Substring(0, AssetSyncSettings.RegistryPath.LastIndexOf('/')));
            var registry = AssetDatabase.LoadAssetAtPath<PolicePatrolAssetRegistry>(AssetSyncSettings.RegistryPath);
            if (registry == null)
            {
                registry = ScriptableObject.CreateInstance<PolicePatrolAssetRegistry>();
                AssetDatabase.CreateAsset(registry, AssetSyncSettings.RegistryPath);
            }

            registry.Replace(
                scan.Assets
                    .Where(asset => AssetPaths.IsValidId(asset.AssetId) && !scan.Duplicates.ContainsKey(asset.AssetId))
                    .Select(asset => new PolicePatrolAssetRegistry.AssetEntry { assetId = asset.AssetId, asset = asset.Asset })
                    .ToList(),
                scan.References.Objects
                    .Select(pair => new PolicePatrolAssetRegistry.ObjectEntry { key = pair.Key, value = pair.Value })
                    .ToList());
            EditorUtility.SetDirty(registry);
            AssetDatabase.SaveAssets();
            return registry;
        }

        private static void EnsureFolder(string folder)
        {
            if (AssetDatabase.IsValidFolder(folder))
            {
                return;
            }

            var slash = folder.LastIndexOf('/');
            var parent = folder.Substring(0, slash);
            EnsureFolder(parent);
            AssetDatabase.CreateFolder(parent, folder.Substring(slash + 1));
        }
    }
}
