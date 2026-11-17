using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Assets
{
    public sealed record GameAsset(
        string AssetId,
        string Type,
        string Folder,
        string Name,
        int Version,
        string Hash,
        JObject Data)
    {
        [JsonIgnore]
        public string DataJson => Data?.ToString(Formatting.None) ?? "{}";

        public T ToObject<T>() => Data == null ? default : Data.ToObject<T>();
    }
}
