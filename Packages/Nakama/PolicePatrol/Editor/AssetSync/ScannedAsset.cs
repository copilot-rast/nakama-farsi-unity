using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Assets;
using UnityEngine;

namespace PolicePatrol.Sdk.Editor
{
    public sealed class ScannedAsset
    {
        public ScannedAsset(ScriptableObject asset, string path, string guid, string assetId)
        {
            Asset = asset;
            Path = path;
            Guid = guid;
            AssetId = assetId;
        }

        public ScriptableObject Asset { get; }

        public string Path { get; }

        public string Guid { get; }

        public string AssetId { get; }

        public JObject Data { get; private set; }

        public LocalAssetInfo Info { get; private set; }

        internal void Describe(JObject data, LocalAssetInfo info)
        {
            Data = data;
            Info = info;
        }
    }
}
