namespace PolicePatrol.Sdk.Assets
{
    public sealed record AssetDiffEntry(string AssetId, AssetSyncStatus Status, LocalAssetInfo Local, AssetManifestItem Server);
}
