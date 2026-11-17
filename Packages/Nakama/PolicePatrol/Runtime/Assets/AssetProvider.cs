using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Assets
{
    public static class AssetProvider
    {
        public const int MaxFetchIds = 200;

        public static void Manifest(string folder, bool recursive, Action<ApiResult<AssetManifestItem[]>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var body = new JObject { ["folder"] = FolderParameter(folder) ?? string.Empty, ["recursive"] = recursive };
                var r = await c.Rpc("assets_manifest", body, true).ConfigureAwait(false);
                return Mapping.Each(r, "items", i => new AssetManifestItem(J.Str(i, "assetId"), J.Str(i, "sourceGuid"), J.Str(i, "type"), J.Str(i, "folder"), J.Str(i, "name"), J.Int(i, "version"), J.Str(i, "hash")));
            }, null, "assets_manifest");

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
                : ApiResult<GameAsset>.Fail(new ApiError(404, "ASSET_NOT_FOUND", new JObject { ["assetId"] = assetId }, string.Empty))));

        public static void LoadFolder(string folder, IAssetCache cache, Action<ApiResult<AssetFolder>> onComplete) =>
            new AssetFolderLoader(folder, cache ?? new MemoryAssetCache(), onComplete).Start();

        private static GameAsset Asset(JToken i) =>
            new GameAsset(J.Str(i, "assetId"), J.Str(i, "type"), J.Str(i, "folder"), J.Str(i, "name"), J.Int(i, "version"), J.Str(i, "hash"), i?["data"] as JObject ?? new JObject());

        private static string FolderParameter(string folder) => folder != null && folder.Trim('/', ' ').Length == 0 ? "/" : folder;
    }
}
