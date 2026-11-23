using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Assets
{
    public static class AssetProvider
    {
        public const int MaxFetchIds = 200;

        public static bool? RequireOnline { get; set; }

        public static TimeSpan? MaxCacheAge { get; set; }

        public static void Manifest(string folder, bool recursive, Action<ApiResult<AssetManifestItem[]>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c => (await LoadManifest(c, folder, recursive, null).ConfigureAwait(false)).Items, null, "assets_manifest");

        public static void LoadManifest(string folder, bool recursive, Action<ApiResult<AssetManifest>> onComplete) => LoadManifest(folder, recursive, null, onComplete);

        public static void LoadManifest(string folder, bool recursive, string etag, Action<ApiResult<AssetManifest>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, c => LoadManifest(c, folder, recursive, etag), null, "assets_manifest");

        internal static async System.Threading.Tasks.Task<AssetManifest> LoadManifest(ApiClient c, string folder, bool recursive, string etag)
        {
            var body = new JObject { ["folder"] = FolderParameter(folder) ?? string.Empty, ["recursive"] = recursive };
            if (!string.IsNullOrEmpty(etag))
            {
                body["etag"] = etag;
            }

            var r = await c.Rpc("assets_manifest", body, true).ConfigureAwait(false);
            var items = Mapping.Each(r, "items", i => new AssetManifestItem(J.Str(i, "assetId"), J.Str(i, "sourceGuid"), J.Str(i, "type"), J.Str(i, "folder"), J.Str(i, "name"), J.Int(i, "version"), J.Str(i, "hash")));
            return new AssetManifest(items, J.Str(r, "etag"), Policy(r?["client"]), J.Time(r, "serverTime"))
            {
                NotModified = J.Bool(r, "notModified"),
                Count = J.Int(r, "count", items.Length),
            };
        }

        internal static AssetClientPolicy Policy(JToken client) =>
            client is JObject ? new AssetClientPolicy(J.Bool(client, "requireOnline"), Math.Max(0, J.Int(client, "maxCacheAgeHours"))) : AssetClientPolicy.None;

        public static void Fetch(string[] assetIds, Action<ApiResult<GameAsset[]>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var ids = (assetIds ?? Array.Empty<string>()).Take(MaxFetchIds).ToArray();
                if (ids.Length == 0)
                {
                    return Array.Empty<GameAsset>();
                }

                var r = await c.Rpc("assets_fetch", new JObject { ["ids"] = new JArray(ids) }, true).ConfigureAwait(false);
                return Mapping.Each(r, "items", Asset);
            }, null, "assets_fetch");

        public static void Get(string assetId, Action<ApiResult<GameAsset>> onComplete) =>
            Fetch(new[] { assetId }, r => onComplete?.Invoke(!r.IsSuccess ? ApiResult<GameAsset>.Fail(r.Error)
                : r.Data.Length > 0 ? ApiResult<GameAsset>.Ok(r.Data[0])
                : ApiResult<GameAsset>.Fail(new ApiError(404, AssetErrorCodes.NotFound, new JObject { ["assetId"] = assetId }, string.Empty))));

        public static void LoadFolder(string folder, IAssetCache cache, Action<ApiResult<AssetFolder>> onComplete) =>
            new AssetFolderLoader(folder, cache ?? new MemoryAssetCache(), onComplete).Start();

        private static GameAsset Asset(JToken i) =>
            new GameAsset(J.Str(i, "assetId"), J.Str(i, "type"), J.Str(i, "folder"), J.Str(i, "name"), J.Int(i, "version"), J.Str(i, "hash"), i?["data"] as JObject ?? new JObject());

        private static string FolderParameter(string folder) => folder != null && folder.Trim('/', ' ').Length == 0 ? "/" : folder;
    }
}
