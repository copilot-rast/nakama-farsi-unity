namespace PolicePatrol.Sdk.Assets
{
    public sealed record LocalAssetInfo(string AssetId, string SourceGuid, string Type, string Folder, string Name, string Hash)
    {
        public string Fingerprint => AssetSyncRecord.FingerprintOf(Hash, Folder, Name, Type);
    }
}
