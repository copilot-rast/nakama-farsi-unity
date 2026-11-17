using System;
using System.Collections.Generic;

namespace PolicePatrol.Sdk.Assets
{
    public sealed class MemoryAssetCache : IAssetCache
    {
        private readonly Dictionary<string, GameAsset> _assets = new Dictionary<string, GameAsset>(StringComparer.Ordinal);
        private readonly Dictionary<string, string[]> _indexes = new Dictionary<string, string[]>(StringComparer.Ordinal);

        public GameAsset Load(string assetId) => _assets.TryGetValue(assetId, out var asset) ? asset : null;

        public void Save(GameAsset asset) => _assets[asset.AssetId] = asset;

        public void Remove(string assetId) => _assets.Remove(assetId);

        public string[] LoadIndex(string folder) => _indexes.TryGetValue(AssetCacheKeys.Index(folder), out var ids) ? ids : null;

        public void SaveIndex(string folder, string[] assetIds) => _indexes[AssetCacheKeys.Index(folder)] = assetIds;

        public void Clear()
        {
            _assets.Clear();
            _indexes.Clear();
        }
    }
}
