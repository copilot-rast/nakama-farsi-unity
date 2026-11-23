using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Assets
{
    internal sealed class AssetFolderLoader
    {
        private static readonly TimeSpan ClockSlack = TimeSpan.FromHours(1);
        private readonly string _folder;
        private readonly IAssetCache _cache;
        private readonly Action<ApiResult<AssetFolder>> _onComplete;
        private readonly Dictionary<string, GameAsset> _ready = new Dictionary<string, GameAsset>(StringComparer.Ordinal);
        private readonly List<string> _missing = new List<string>();
        private AssetManifestItem[] _manifest = Array.Empty<AssetManifestItem>();
        private AssetClientPolicy _policy = AssetClientPolicy.None;
        private DateTimeOffset? _serverTime;
        private int _next;
        private int _downloaded;

        public AssetFolderLoader(string folder, IAssetCache cache, Action<ApiResult<AssetFolder>> onComplete)
        {
            _folder = folder;
            _cache = cache;
            _onComplete = onComplete;
        }

        public void Start() => AssetProvider.LoadManifest(_folder, true, OnManifest);

        private void OnManifest(ApiResult<AssetManifest> result)
        {
            if (!result.IsSuccess)
            {
                UseCacheOrFail(result.Error);
                return;
            }

            _manifest = result.Data?.Items ?? Array.Empty<AssetManifestItem>();
            _policy = result.Data?.Client ?? AssetClientPolicy.None;
            _serverTime = result.Data?.ServerTime;
            var meta = _cache as IAssetCacheMeta;
            meta?.SaveState(_folder, new AssetCacheState(_policy, meta.LoadState(_folder)?.LoadedAt, _serverTime));
            foreach (var item in _manifest)
            {
                var cached = _cache.Load(item.AssetId);
                if (cached != null && cached.Version == item.Version && cached.Hash == item.Hash)
                {
                    _ready[item.AssetId] = cached;
                }
                else
                {
                    _missing.Add(item.AssetId);
                }
            }

            FetchNext();
        }

        private void FetchNext()
        {
            if (_next >= _missing.Count)
            {
                Finish();
                return;
            }

            var batch = _missing.Skip(_next).Take(AssetProvider.MaxFetchIds).ToArray();
            _next += batch.Length;
            AssetProvider.Fetch(batch, OnFetched);
        }

        private void OnFetched(ApiResult<GameAsset[]> result)
        {
            if (!result.IsSuccess)
            {
                _onComplete?.Invoke(ApiResult<AssetFolder>.Fail(result.Error));
                return;
            }

            foreach (var asset in result.Data ?? Array.Empty<GameAsset>())
            {
                _cache.Save(asset);
                _ready[asset.AssetId] = asset;
                _downloaded++;
            }

            FetchNext();
        }

        private void Finish()
        {
            var ids = _manifest.Select(item => item.AssetId).ToArray();
            foreach (var stale in (_cache.LoadIndex(_folder) ?? Array.Empty<string>()).Except(ids, StringComparer.Ordinal))
            {
                _cache.Remove(stale);
            }

            _cache.SaveIndex(_folder, ids);
            var loadedAt = DateTimeOffset.UtcNow;
            (_cache as IAssetCacheMeta)?.SaveState(_folder, new AssetCacheState(_policy, loadedAt, _serverTime));
            var assets = ids.Where(_ready.ContainsKey).Select(id => _ready[id]).ToArray();
            _onComplete?.Invoke(ApiResult<AssetFolder>.Ok(new AssetFolder(_folder, assets, _downloaded, false) { Policy = _policy, LoadedAt = loadedAt }));
        }

        private void UseCacheOrFail(ApiError error)
        {
            if (!(error.IsNetworkError || error.Status >= 500))
            {
                _onComplete?.Invoke(ApiResult<AssetFolder>.Fail(error));
                return;
            }

            var state = (_cache as IAssetCacheMeta)?.LoadState(_folder);
            var policy = state?.Policy ?? AssetClientPolicy.None;
            if (AssetProvider.RequireOnline ?? policy.RequireOnline)
            {
                _onComplete?.Invoke(ApiResult<AssetFolder>.Fail(Blocked(error, AssetErrorCodes.OnlineRequired, "Server data must be loaded online", new JObject())));
                return;
            }

            var maxAge = AssetProvider.MaxCacheAge ?? policy.MaxCacheAge;
            if (maxAge.HasValue && maxAge.Value > TimeSpan.Zero)
            {
                var age = state?.LoadedAt == null ? (TimeSpan?)null : DateTimeOffset.UtcNow - state.LoadedAt.Value;
                if (age == null || age.Value > maxAge.Value || age.Value < -ClockSlack)
                {
                    var meta = new JObject
                    {
                        ["ageHours"] = age.HasValue ? (JToken)Math.Round(age.Value.TotalHours, 2) : JValue.CreateNull(),
                        ["maxCacheAgeHours"] = Math.Round(maxAge.Value.TotalHours, 2),
                        ["loadedAt"] = state?.LoadedAt?.ToString("o"),
                    };
                    _onComplete?.Invoke(ApiResult<AssetFolder>.Fail(Blocked(error, AssetErrorCodes.CacheTooOld, "Saved server data is too old to use offline", meta)));
                    return;
                }
            }

            var ids = _cache.LoadIndex(_folder);
            var assets = ids?.Select(_cache.Load).ToArray();
            if (assets == null || assets.Any(asset => asset == null))
            {
                _onComplete?.Invoke(ApiResult<AssetFolder>.Fail(error));
                return;
            }

            _onComplete?.Invoke(ApiResult<AssetFolder>.Ok(new AssetFolder(_folder, assets, 0, true) { Policy = state?.Policy, LoadedAt = state?.LoadedAt }));
        }

        private ApiError Blocked(ApiError error, string code, string message, JObject meta)
        {
            meta["originalCode"] = error.Code;
            meta["originalStatus"] = error.Status;
            meta["folder"] = _folder;
            return new ApiError(error.Status, code, meta, message) { ServerCode = error.ServerCode };
        }
    }
}
