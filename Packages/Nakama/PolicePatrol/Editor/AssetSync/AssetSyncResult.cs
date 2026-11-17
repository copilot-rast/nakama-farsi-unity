using PolicePatrol.Sdk.Assets;

namespace PolicePatrol.Sdk.Editor
{
    public sealed class AssetSyncResult
    {
        public AssetSyncResult(int created, int updated, int unchanged, int deleted, AssetManifestItem[] items)
        {
            Created = created;
            Updated = updated;
            Unchanged = unchanged;
            Deleted = deleted;
            Items = items ?? new AssetManifestItem[0];
        }

        public int Created { get; }

        public int Updated { get; }

        public int Unchanged { get; }

        public int Deleted { get; }

        public AssetManifestItem[] Items { get; }
    }
}
