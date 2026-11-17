namespace PolicePatrol.Sdk.Assets
{
    public sealed record AssetManifestItem(
        string AssetId,
        string SourceGuid,
        string Type,
        string Folder,
        string Name,
        int Version,
        string Hash);
}
