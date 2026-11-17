using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using PolicePatrol.Sdk.Assets;

namespace PolicePatrol.Sdk.Editor
{
    public sealed class AssetSyncState
    {
        private const string FilePath = "Library/PolicePatrolAssets/state.json";

        [JsonProperty("scopes")]
        private Dictionary<string, Dictionary<string, AssetSyncRecord>> _scopes = new Dictionary<string, Dictionary<string, AssetSyncRecord>>(StringComparer.Ordinal);

        public static AssetSyncState Load()
        {
            try
            {
                return File.Exists(FilePath) ? JsonConvert.DeserializeObject<AssetSyncState>(File.ReadAllText(FilePath)) ?? new AssetSyncState() : new AssetSyncState();
            }
            catch (JsonException)
            {
                return new AssetSyncState();
            }
        }

        public Dictionary<string, AssetSyncRecord> For(AssetSyncSettings settings)
        {
            if (!_scopes.TryGetValue(settings.Scope, out var records))
            {
                records = new Dictionary<string, AssetSyncRecord>(StringComparer.Ordinal);
                _scopes[settings.Scope] = records;
            }

            return records;
        }

        public void Remember(AssetSyncSettings settings, IEnumerable<AssetManifestItem> items)
        {
            var records = For(settings);
            foreach (var item in items ?? Array.Empty<AssetManifestItem>())
            {
                records[item.AssetId] = AssetSyncRecord.Of(item);
            }
        }

        public void Forget(AssetSyncSettings settings, IEnumerable<string> assetIds)
        {
            var records = For(settings);
            foreach (var id in assetIds)
            {
                records.Remove(id);
            }
        }

        public void Save()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}
