using System;
using System.Collections.Generic;
using System.Linq;

namespace PolicePatrol.Sdk.Assets
{
    internal sealed class AssetFolderLoader
    {
        private readonly string _folder;
        private readonly IAssetCache _cache;
        private readonly Action<ApiResult<AssetFolder>> _onComplete;
        private readonly Dictionary<string, GameAsset> _ready = new Dictionary<string, GameAsset>(StringComparer.Ordinal);
        private readonly List<string> _missing = new List<string>();
        private AssetManifestItem[] _manifest = Array.Empty<AssetManifestItem>();
        private int _next;
        private int _downloaded;

        public AssetFolderLoader(string folder, IAssetCache cache, Action<ApiResult<AssetFolder>> onComplete)
        {
            _folder = folder;
            _cache = cache;
            _onComplete = onComplete;
        }

        public void Start() => AssetProvider.Manifest(_folder, true, OnManifest);

        private void OnManifest(ApiResult<AssetManifestItem[]> result)
        {
            if (!result.IsSuccess)
            {
                UseCacheOrFail(result.Error);
                return;
            }

            _manifest = result.Data ?? Array.Empty<AssetManifestItem>();
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
            var assets = ids.Where(_ready.ContainsKey).Select(id => _ready[id]).ToArray();
            _onComplete?.Invoke(ApiResult<AssetFolder>.Ok(new AssetFolder(_folder, assets, _downloaded, false)));
        }

        private void UseCacheOrFail(ApiError error)
        {
            var ids = error.IsNetworkError || error.Status >= 500 ? _cache.LoadIndex(_folder) : null;
            var assets = ids?.Select(_cache.Load).ToArray();
            if (assets == null || assets.Any(asset => asset == null))
            {
                _onComplete?.Invoke(ApiResult<AssetFolder>.Fail(error));
                return;
            }

            _onComplete?.Invoke(ApiResult<AssetFolder>.Ok(new AssetFolder(_folder, assets, 0, true)));
        }
    }
}
