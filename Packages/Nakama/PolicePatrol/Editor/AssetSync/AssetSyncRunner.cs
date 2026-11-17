using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Assets;
using UnityEditor;

namespace PolicePatrol.Sdk.Editor
{
    public static class AssetSyncRunner
    {
        public const int FetchBatch = 200;

        public static async Task<AssetSyncSession> CompareAsync(AssetSyncSettings settings)
        {
            var scan = AssetScanner.Scan(settings);
            var manifest = await new AssetSyncApi(settings).ManifestAsync();
            var scopes = settings.Folders.Select(folder => AssetPaths.FolderOfAssetPath(folder.TrimEnd('/') + "/x")).ToArray();
            var inScope = manifest.Where(item => scopes.Any(scope => scope.Length == 0 || item.Folder == scope || item.Folder.StartsWith(scope + "/", StringComparison.Ordinal)));
            var diff = AssetDiff.Compare(scan.Assets.Select(asset => asset.Info), inScope, AssetSyncState.Load().For(settings));
            return new AssetSyncSession(scan, diff);
        }

        public static async Task<string> PushAsync(AssetSyncSettings settings, AssetSyncSession session, IReadOnlyList<AssetDiffEntry> push, IReadOnlyList<AssetDiffEntry> delete)
        {
            if (!session.Scan.CanSync)
            {
                throw new InvalidOperationException("Fix the id problems listed above before pushing.");
            }

            var writes = push.Select(entry => (Token: (JToken)Item(session.Scan.Find(entry.AssetId), entry.Server), IsDelete: false))
                .Concat(delete.Select(entry => (Token: (JToken)new JObject { ["assetId"] = entry.AssetId, ["baseVersion"] = entry.Server.Version }, IsDelete: true)))
                .ToList();
            var api = new AssetSyncApi(settings);
            var state = AssetSyncState.Load();
            int created = 0, updated = 0, unchanged = 0, deleted = 0;

            for (var start = 0; start < writes.Count; start += AssetPaths.MaxSyncItems)
            {
                var batch = writes.Skip(start).Take(AssetPaths.MaxSyncItems).ToList();
                EditorUtility.DisplayProgressBar("Asset Sync", "Pushing " + (start + batch.Count) + " of " + writes.Count, (float)start / writes.Count);
                try
                {
                    var result = await api.SyncAsync(
                        new JArray(batch.Where(w => !w.IsDelete).Select(w => w.Token)),
                        new JArray(batch.Where(w => w.IsDelete).Select(w => w.Token)));
                    state.Remember(settings, result.Items);
                    state.Forget(settings, batch.Where(w => w.IsDelete).Select(w => (string)w.Token["assetId"]));
                    state.Save();
                    created += result.Created;
                    updated += result.Updated;
                    unchanged += result.Unchanged;
                    deleted += result.Deleted;
                }
                finally
                {
                    EditorUtility.ClearProgressBar();
                }
            }

            AssetRegistryBuilder.Build(session.Scan);
            return $"Pushed: {created} new, {updated} updated, {unchanged} unchanged, {deleted} deleted. Registry updated.";
        }

        public static async Task<string> PullAsync(AssetSyncSettings settings, AssetSyncSession session, IReadOnlyList<AssetDiffEntry> pull)
        {
            var api = new AssetSyncApi(settings);
            var state = AssetSyncState.Load();
            var options = AssetScanner.Options(session.Scan.References);
            var warnings = new List<string>();
            var applied = 0;
            var ids = pull.Select(entry => entry.AssetId).ToArray();

            try
            {
                for (var start = 0; start < ids.Length; start += FetchBatch)
                {
                    EditorUtility.DisplayProgressBar("Asset Sync", "Pulling " + Math.Min(ids.Length, start + FetchBatch) + " of " + ids.Length, (float)start / ids.Length);
                    foreach (var remote in await api.FetchAsync(ids.Skip(start).Take(FetchBatch).ToArray()))
                    {
                        var local = session.Scan.Find(remote.AssetId);
                        if (local == null)
                        {
                            continue;
                        }

                        Undo.RecordObject(local.Asset, "Pull asset data");
                        warnings.AddRange(AssetObjectJson.Apply(remote.Data, local.Asset, options).Warnings.Select(w => remote.AssetId + "." + w));
                        EditorUtility.SetDirty(local.Asset);
                        state.Remember(settings, new[] { new AssetManifestItem(remote.AssetId, remote.SourceGuid, remote.Type, remote.Folder, remote.Name, remote.Version, remote.Hash) });
                        applied++;
                    }
                }
            }
            finally
            {
                EditorUtility.ClearProgressBar();
                AssetDatabase.SaveAssets();
                state.Save();
            }

            return $"Pulled {applied} asset(s)." + (warnings.Count == 0 ? string.Empty : "\nKept the current value where the server data did not fit:\n" + string.Join("\n", warnings.Take(30)));
        }

        private static JObject Item(ScannedAsset asset, AssetManifestItem server) => new JObject
        {
            ["assetId"] = asset.AssetId,
            ["sourceGuid"] = asset.Guid,
            ["type"] = asset.Info.Type,
            ["folder"] = asset.Info.Folder,
            ["name"] = asset.Info.Name,
            ["data"] = asset.Data,
            ["baseVersion"] = server != null ? (JToken)server.Version : JValue.CreateNull(),
        };
    }
}
