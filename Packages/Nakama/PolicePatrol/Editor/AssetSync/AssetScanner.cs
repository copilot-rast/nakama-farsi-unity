using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PolicePatrol.Sdk.Assets;
using PolicePatrol.Sdk.Unity;
using UnityEditor;
using UnityEngine;

namespace PolicePatrol.Sdk.Editor
{
    public static class AssetScanner
    {
        private const BindingFlags Fields = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;

        public static AssetScanResult Scan(AssetSyncSettings settings)
        {
            var folders = settings.Folders.Where(AssetDatabase.IsValidFolder).ToArray();
            var guids = folders.Length == 0 ? Array.Empty<string>() : AssetDatabase.FindAssets("t:ScriptableObject", folders).Distinct().ToArray();
            var assets = new List<ScannedAsset>();
            var unreadable = new List<string>();
            var emptyIds = new List<string>();

            try
            {
                for (var i = 0; i < guids.Length; i++)
                {
                    var path = AssetDatabase.GUIDToAssetPath(guids[i]);
                    if (i % 50 == 0)
                    {
                        EditorUtility.DisplayProgressBar("Asset Sync", "Reading " + path, (float)i / Math.Max(1, guids.Length));
                    }

                    if (!path.EndsWith(".asset", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    var main = AssetDatabase.LoadMainAssetAtPath(path);
                    if (main == null)
                    {
                        unreadable.Add(path);
                        continue;
                    }

                    if (!(main is ScriptableObject asset) || asset is PolicePatrolAssetRegistry || settings.ExcludedTypes.Contains(asset.GetType().FullName))
                    {
                        continue;
                    }

                    if (!TryIdField(asset, settings.IdFields, out var id))
                    {
                        id = guids[i];
                    }
                    else if (id.Length == 0)
                    {
                        emptyIds.Add(path);
                        continue;
                    }

                    assets.Add(new ScannedAsset(asset, path, guids[i], id));
                }

                var references = new EditorReferences(assets);
                var options = Options(references);
                foreach (var asset in assets)
                {
                    var data = AssetObjectJson.Write(asset.Asset, options);
                    asset.Describe(data, new LocalAssetInfo(
                        asset.AssetId,
                        asset.Guid,
                        asset.Asset.GetType().FullName,
                        AssetPaths.FolderOfAssetPath(asset.Path),
                        asset.Asset.name.Trim(),
                        AssetCanonicalJson.Hash(data)));
                }

                var duplicates = assets
                    .GroupBy(asset => asset.AssetId, StringComparer.Ordinal)
                    .Where(group => group.Count() > 1)
                    .ToDictionary(group => group.Key, group => group.Select(asset => asset.Path).ToArray(), StringComparer.Ordinal);
                var invalid = assets.Where(asset => !AssetPaths.IsValidId(asset.AssetId)).ToList();
                return new AssetScanResult(assets, duplicates, invalid, emptyIds, unreadable, references);
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }
        }

        public static AssetJsonOptions Options(EditorReferences references)
        {
            var options = new AssetJsonOptions { References = references };
            options.Converters.Add(new UnityAssetConverters());
            return options;
        }

        private static bool TryIdField(object asset, IEnumerable<string> names, out string value)
        {
            value = null;
            foreach (var name in names.Where(n => !string.IsNullOrWhiteSpace(n)))
            {
                for (var type = asset.GetType(); type != null && type != typeof(ScriptableObject); type = type.BaseType)
                {
                    var field = type.GetField(name.Trim(), Fields);
                    if (field != null && field.FieldType == typeof(string))
                    {
                        value = ((string)field.GetValue(asset) ?? string.Empty).Trim();
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
