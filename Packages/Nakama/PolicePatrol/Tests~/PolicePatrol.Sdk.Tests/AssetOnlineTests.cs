using System;
using System.Linq;
using System.Threading.Tasks;
using PolicePatrol.Sdk.Assets;
using NF = NakamaFarsi.Sdk;
using Xunit;

namespace PolicePatrol.Sdk.Tests
{
    public class AssetOnlineTests : IDisposable
    {
        private const string Fetch = "{\"items\":[{\"assetId\":\"a-1\",\"type\":\"CarData\",\"folder\":\"cars\",\"name\":\"Tiggo8\",\"version\":3,\"hash\":\"h3\",\"data\":{\"speed\":5}}]}";

        private static string Manifest(bool requireOnline, int maxAgeHours) =>
            "{\"etag\":\"\\\"e1\\\"\",\"notModified\":false,\"count\":1,\"items\":[{\"assetId\":\"a-1\",\"type\":\"CarData\",\"folder\":\"cars\",\"name\":\"Tiggo8\",\"version\":3,\"hash\":\"h3\"}],"
            + "\"client\":{\"requireOnline\":" + (requireOnline ? "true" : "false") + ",\"maxCacheAgeHours\":" + maxAgeHours + "},\"serverTime\":\"2026-11-23T10:00:00Z\"}";

        public void Dispose()
        {
            AssetProvider.RequireOnline = null;
            AssetProvider.MaxCacheAge = null;
        }

        private static async Task<MemoryAssetCache> LoadedOnce(ScriptedTransport t, bool requireOnline, int maxAgeHours)
        {
            var cache = new MemoryAssetCache();
            t.Routes["assets_manifest"] = p => Manifest(requireOnline, maxAgeHours);
            t.Routes["assets_fetch"] = p => Fetch;
            var ok = await Harness.Call<AssetFolder>(cb => AssetProvider.LoadFolder("cars", cache, cb));
            Assert.True(ok.IsSuccess);
            Assert.False(ok.Data.Offline);
            Assert.Equal(requireOnline, ok.Data.Policy.RequireOnline);
            Assert.NotNull(ok.Data.LoadedAt);
            var state = cache.LoadState("cars");
            Assert.Equal(new AssetClientPolicy(requireOnline, maxAgeHours), state.Policy);
            Assert.Equal(ok.Data.LoadedAt, state.LoadedAt);
            return cache;
        }

        [Fact]
        public async Task ManifestCarriesTheClientPolicy()
        {
            var t = Harness.Start();
            t.Routes["assets_manifest"] = p => Manifest(true, 48);
            var m = await Harness.Call<AssetManifest>(cb => AssetProvider.LoadManifest("cars", true, "\"e0\"", cb));
            Assert.True(m.Data.Client.RequireOnline);
            Assert.Equal(TimeSpan.FromHours(48), m.Data.Client.MaxCacheAge);
            Assert.Equal("\"e1\"", m.Data.Etag);
            Assert.Equal(new DateTimeOffset(2026, 11, 23, 10, 0, 0, TimeSpan.Zero), m.Data.ServerTime);
            Assert.Contains("\"etag\":\"\\\"e0\\\"\"", t.Calls.Last().Payload);
            var items = await Harness.Call<AssetManifestItem[]>(cb => AssetProvider.Manifest("cars", true, cb));
            Assert.Equal("a-1", items.Data.Single().AssetId);

            t.Routes["assets_manifest"] = p => "{\"etag\":\"\\\"e1\\\"\",\"notModified\":true,\"count\":1,\"client\":{\"requireOnline\":false,\"maxCacheAgeHours\":0},\"serverTime\":\"2026-11-23T10:00:00Z\"}";
            var same = await Harness.Call<AssetManifest>(cb => AssetProvider.LoadManifest("cars", true, "\"e1\"", cb));
            Assert.True(same.Data.NotModified);
            Assert.Empty(same.Data.Items);
            Assert.Equal(1, same.Data.Count);

            t.Routes["assets_manifest"] = p => "{\"items\":[]}";
            var old = await Harness.Call<AssetManifest>(cb => AssetProvider.LoadManifest("cars", true, cb));
            Assert.Equal(AssetClientPolicy.None, old.Data.Client);
        }

        [Fact]
        public async Task OnlineRequiredFailsInsteadOfUsingTheCache()
        {
            var t = Harness.Start();
            var cache = await LoadedOnce(t, true, 0);
            t.Routes["assets_manifest"] = p => new NF.RpcTransportException("reset", true);
            var r = await Harness.Call<AssetFolder>(cb => AssetProvider.LoadFolder("cars", cache, cb));
            Assert.False(r.IsSuccess);
            Assert.Equal(AssetErrorCodes.OnlineRequired, r.Error.Code);
            Assert.Equal(ApiError.NetworkErrorCode, (string)r.Error.Meta["originalCode"]);
            Assert.Equal("cars", (string)r.Error.Meta["folder"]);

            t.Routes["assets_manifest"] = p => new NF.RpcServerException("{\"code\":\"INTERNAL\",\"status\":503}", 503);
            var down = await Harness.Call<AssetFolder>(cb => AssetProvider.LoadFolder("cars", cache, cb));
            Assert.Equal(AssetErrorCodes.OnlineRequired, down.Error.Code);

            AssetProvider.RequireOnline = false;
            var forced = await Harness.Call<AssetFolder>(cb => AssetProvider.LoadFolder("cars", cache, cb));
            Assert.True(forced.IsSuccess);
            Assert.True(forced.Data.Offline);
        }

        [Fact]
        public async Task CacheOlderThanTheLimitFails()
        {
            var t = Harness.Start();
            var cache = await LoadedOnce(t, false, 24);
            var state = cache.LoadState("cars");
            cache.SaveState("cars", state with { LoadedAt = DateTimeOffset.UtcNow.AddHours(-30) });
            t.Routes["assets_manifest"] = p => new NF.RpcTransportException("reset", true);
            var r = await Harness.Call<AssetFolder>(cb => AssetProvider.LoadFolder("cars", cache, cb));
            Assert.Equal(AssetErrorCodes.CacheTooOld, r.Error.Code);
            Assert.Equal(24, (double)r.Error.Meta["maxCacheAgeHours"]);
            Assert.InRange((double)r.Error.Meta["ageHours"], 29.9, 30.1);

            AssetProvider.MaxCacheAge = TimeSpan.FromDays(2);
            var longer = await Harness.Call<AssetFolder>(cb => AssetProvider.LoadFolder("cars", cache, cb));
            Assert.True(longer.IsSuccess);
            Assert.True(longer.Data.Offline);
        }

        [Fact]
        public async Task WithoutAPolicyTheCacheIsUsedOfflineLikeBefore()
        {
            var t = Harness.Start();
            var cache = await LoadedOnce(t, false, 0);
            t.Routes["assets_manifest"] = p => new NF.RpcTransportException("reset", true);
            var r = await Harness.Call<AssetFolder>(cb => AssetProvider.LoadFolder("cars", cache, cb));
            Assert.True(r.IsSuccess);
            Assert.True(r.Data.Offline);
            Assert.Equal("a-1", r.Data.Assets.Single().AssetId);
            Assert.Equal(cache.LoadState("cars").LoadedAt, r.Data.LoadedAt);

            AssetProvider.RequireOnline = true;
            var forced = await Harness.Call<AssetFolder>(cb => AssetProvider.LoadFolder("cars", cache, cb));
            Assert.Equal(AssetErrorCodes.OnlineRequired, forced.Error.Code);
            AssetProvider.RequireOnline = null;

            t.Routes["assets_manifest"] = p => new NF.RpcServerException("{\"code\":\"FORBIDDEN\",\"status\":403}", 403);
            var denied = await Harness.Call<AssetFolder>(cb => AssetProvider.LoadFolder("cars", cache, cb));
            Assert.Equal(403, denied.Error.Status);
        }

        [Fact]
        public void FileCacheKeepsTheState()
        {
            var dir = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "pp-assets-" + Guid.NewGuid().ToString("N"));
            try
            {
                var cache = new FileAssetCache(dir);
                var at = new DateTimeOffset(2026, 11, 23, 10, 0, 0, TimeSpan.Zero);
                cache.SaveState("cars", new AssetCacheState(new AssetClientPolicy(true, 12), at, at));
                var back = new FileAssetCache(dir).LoadState("cars");
                Assert.True(back.Policy.RequireOnline);
                Assert.Equal(12, back.Policy.MaxCacheAgeHours);
                Assert.Equal(at, back.LoadedAt);
                Assert.Null(cache.LoadState("other"));
                cache.Clear();
                Assert.Null(cache.LoadState("cars"));
            }
            finally
            {
                if (System.IO.Directory.Exists(dir))
                {
                    System.IO.Directory.Delete(dir, true);
                }
            }
        }
    }
}
