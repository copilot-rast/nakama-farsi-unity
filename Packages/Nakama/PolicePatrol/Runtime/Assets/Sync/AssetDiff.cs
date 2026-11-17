using System;
using System.Collections.Generic;
using System.Linq;

namespace PolicePatrol.Sdk.Assets
{
    public static class AssetDiff
    {
        public static AssetDiffEntry[] Compare(
            IEnumerable<LocalAssetInfo> local,
            IEnumerable<AssetManifestItem> server,
            IReadOnlyDictionary<string, AssetSyncRecord> synced)
        {
            var serverById = (server ?? Enumerable.Empty<AssetManifestItem>()).ToDictionary(item => item.AssetId, StringComparer.Ordinal);
            var localItems = (local ?? Enumerable.Empty<LocalAssetInfo>()).ToList();
            var entries = new List<AssetDiffEntry>();

            foreach (var item in localItems)
            {
                serverById.TryGetValue(item.AssetId, out var remote);
                AssetSyncRecord record = null;
                synced?.TryGetValue(item.AssetId, out record);
                entries.Add(new AssetDiffEntry(item.AssetId, StatusOf(item, remote, record), item, remote));
            }

            var localIds = new HashSet<string>(localItems.Select(item => item.AssetId), StringComparer.Ordinal);
            entries.AddRange(serverById.Values
                .Where(remote => !localIds.Contains(remote.AssetId))
                .Select(remote => new AssetDiffEntry(remote.AssetId, AssetSyncStatus.ServerOnly, null, remote)));

            return entries.OrderBy(entry => entry.AssetId, StringComparer.Ordinal).ToArray();
        }

        private static AssetSyncStatus StatusOf(LocalAssetInfo local, AssetManifestItem remote, AssetSyncRecord record)
        {
            if (remote == null)
            {
                return AssetSyncStatus.New;
            }

            if (remote.SourceGuid != local.SourceGuid)
            {
                return AssetSyncStatus.OtherFile;
            }

            if (AssetSyncRecord.Of(remote).Fingerprint == local.Fingerprint)
            {
                return AssetSyncStatus.Same;
            }

            if (record == null)
            {
                return AssetSyncStatus.Differs;
            }

            var localChanged = record.Fingerprint != local.Fingerprint;
            var serverChanged = record.Version != remote.Version;
            if (localChanged && serverChanged)
            {
                return AssetSyncStatus.Conflict;
            }

            if (localChanged)
            {
                return AssetSyncStatus.Changed;
            }

            return serverChanged ? AssetSyncStatus.ServerNewer : AssetSyncStatus.Differs;
        }
    }
}
