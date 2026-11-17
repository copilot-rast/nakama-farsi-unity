using System.Collections.Generic;
using System.Linq;

namespace PolicePatrol.Sdk.Editor
{
    public sealed class AssetScanResult
    {
        public AssetScanResult(
            IReadOnlyList<ScannedAsset> assets,
            IReadOnlyDictionary<string, string[]> duplicates,
            IReadOnlyList<ScannedAsset> invalidIds,
            IReadOnlyList<string> emptyIds,
            IReadOnlyList<string> unreadable,
            EditorReferences references)
        {
            Assets = assets;
            Duplicates = duplicates;
            InvalidIds = invalidIds;
            EmptyIds = emptyIds;
            Unreadable = unreadable;
            References = references;
        }

        public IReadOnlyList<ScannedAsset> Assets { get; }

        public IReadOnlyDictionary<string, string[]> Duplicates { get; }

        public IReadOnlyList<ScannedAsset> InvalidIds { get; }

        public IReadOnlyList<string> EmptyIds { get; }

        public IReadOnlyList<string> Unreadable { get; }

        public EditorReferences References { get; }

        public bool CanSync => Duplicates.Count == 0 && InvalidIds.Count == 0 && EmptyIds.Count == 0;

        public ScannedAsset Find(string assetId) => Assets.FirstOrDefault(asset => asset.AssetId == assetId);
    }
}
