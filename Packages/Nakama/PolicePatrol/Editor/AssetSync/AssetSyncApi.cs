using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Assets;

namespace PolicePatrol.Sdk.Editor
{
    public sealed class AssetSyncApi
    {
        private readonly AssetSyncSettings _settings;

        public AssetSyncApi(AssetSyncSettings settings)
        {
            _settings = settings;
        }

        public const string BasePath = "/v2/assets/editor";

        public async Task<AssetManifestItem[]> ManifestAsync()
        {
            var answer = await EditorApiClient.SendJsonAsync<JObject>(_settings, HttpMethod.Get, BasePath + "/manifest?recursive=true", null);
            return (answer?["items"] as JArray ?? new JArray()).ToObject<AssetManifestItem[]>(SdkJson.Serializer);
        }

        public async Task<ServerAsset[]> FetchAsync(string[] assetIds)
        {
            var answer = await EditorApiClient.SendJsonAsync<JObject>(_settings, HttpMethod.Post, BasePath + "/fetch", new JObject { ["assetIds"] = new JArray(assetIds) });
            return (answer?["items"] as JArray ?? new JArray()).ToObject<ServerAsset[]>(SdkJson.Serializer);
        }

        public Task<AssetSyncResult> SyncAsync(JArray items, JArray deletes) =>
            EditorApiClient.SendJsonAsync<AssetSyncResult>(_settings, HttpMethod.Post, BasePath + "/push", new JObject { ["items"] = items, ["deletes"] = deletes });
    }
}
