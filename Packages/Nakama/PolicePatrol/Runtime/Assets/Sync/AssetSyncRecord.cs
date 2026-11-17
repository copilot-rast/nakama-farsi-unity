namespace PolicePatrol.Sdk.Assets
{
    public sealed record AssetSyncRecord(int Version, string Fingerprint)
    {
        public static string FingerprintOf(string hash, string folder, string name, string type) =>
            hash + "|" + folder + "|" + name + "|" + type;

        public static AssetSyncRecord Of(AssetManifestItem item) =>
            new AssetSyncRecord(item.Version, FingerprintOf(item.Hash, item.Folder, item.Name, item.Type));
    }
}
