using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Editor
{
    public sealed class ServerAsset
    {
        public ServerAsset(string assetId, string sourceGuid, string type, string folder, string name, JObject data, string hash, int version)
        {
            AssetId = assetId;
            SourceGuid = sourceGuid;
            Type = type;
            Folder = folder;
            Name = name;
            Data = data;
            Hash = hash;
            Version = version;
        }

        public string AssetId { get; }

        public string SourceGuid { get; }

        public string Type { get; }

        public string Folder { get; }

        public string Name { get; }

        public JObject Data { get; }

        public string Hash { get; }

        public int Version { get; }
    }
}
