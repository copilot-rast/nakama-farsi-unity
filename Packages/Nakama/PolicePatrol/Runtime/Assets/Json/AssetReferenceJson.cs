using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Assets
{
    public static class AssetReferenceJson
    {
        public const string AssetKey = "$asset";
        public const string ObjectKey = "$object";
        public const string PathKey = "path";

        public static JObject Asset(string assetId) => new JObject { [AssetKey] = assetId };

        public static JObject Object(string key, string path) => new JObject { [ObjectKey] = key, [PathKey] = path };

        public static bool TryGetAsset(JToken token, out string assetId) => TryGet(token, AssetKey, out assetId);

        public static bool TryGetObject(JToken token, out string key) => TryGet(token, ObjectKey, out key);

        private static bool TryGet(JToken token, string name, out string value)
        {
            value = token is JObject json && json[name] is JValue raw && raw.Type == JTokenType.String ? (string)raw : null;
            return !string.IsNullOrEmpty(value);
        }
    }
}
