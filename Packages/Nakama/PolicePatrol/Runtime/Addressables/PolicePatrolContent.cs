using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace PolicePatrol.Sdk.Unity
{
    public static class PolicePatrolContent
    {
        private static bool _urlsCleaned;

        public static void Prepare(object key, Action<ContentProgress> onProgress, Action<ContentResult> onComplete)
        {
            CleanUrls();
            ContentRunner.Instance.StartCoroutine(PrepareRoutine(key, onProgress, onComplete));
        }

        public static void LoadAll(IEnumerable<AssetReference> references, Action<float> onProgress, Action<ContentResult> onComplete)
        {
            CleanUrls();
            ContentRunner.Instance.StartCoroutine(LoadAllRoutine(references, onProgress, onComplete));
        }

        public static void LoadOrNull<T>(string address, Action<T> onComplete) where T : UnityEngine.Object
        {
            CleanUrls();
            ContentRunner.Instance.StartCoroutine(LoadOrNullRoutine(address, onComplete));
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void CleanUrls()
        {
            if (_urlsCleaned)
            {
                return;
            }

            _urlsCleaned = true;
            var previous = Addressables.InternalIdTransformFunc;
            Addressables.InternalIdTransformFunc = location =>
                ContentUrls.CollapseSlashes(previous != null ? previous(location) : location.InternalId);
        }

        private static IEnumerator LoadOrNullRoutine<T>(string address, Action<T> onComplete) where T : UnityEngine.Object
        {
            var locations = Addressables.LoadResourceLocationsAsync(address, typeof(T));
            yield return locations;
            var known = locations.Status == AsyncOperationStatus.Succeeded && locations.Result != null && locations.Result.Count > 0;
            Addressables.Release(locations);
            if (!known)
            {
                onComplete?.Invoke(null);
                yield break;
            }

            var load = Addressables.LoadAssetAsync<T>(address);
            yield return load;
            onComplete?.Invoke(load.Status == AsyncOperationStatus.Succeeded ? load.Result : null);
        }

        private static IEnumerator LoadAllRoutine(IEnumerable<AssetReference> references, Action<float> onProgress, Action<ContentResult> onComplete)
        {
            var pending = new List<AsyncOperationHandle<UnityEngine.Object>>();
            foreach (var reference in references ?? Array.Empty<AssetReference>())
            {
                if (reference != null && reference.RuntimeKeyIsValid() && !reference.IsValid())
                {
                    pending.Add(reference.LoadAssetAsync<UnityEngine.Object>());
                }
            }

            var failed = 0;
            string firstError = null;
            for (var i = 0; i < pending.Count; i++)
            {
                while (!pending[i].IsDone)
                {
                    onProgress?.Invoke((float)i / pending.Count);
                    yield return null;
                }

                if (pending[i].Status != AsyncOperationStatus.Succeeded)
                {
                    failed++;
                    firstError = firstError ?? pending[i].OperationException?.Message;
                }
            }

            onProgress?.Invoke(1f);
            onComplete?.Invoke(new ContentResult(failed == 0, false, false, 0, failed == 0 ? null : failed + " of " + pending.Count + " could not load: " + firstError));
        }

        private static IEnumerator PrepareRoutine(object key, Action<ContentProgress> onProgress, Action<ContentResult> onComplete)
        {
            if (!PolicePatrolContentUrls.IsResolved && PolicePatrolSdk.IsInitialized)
            {
                var resolved = false;
                PolicePatrolContentUrls.Resolve(_ => resolved = true);
                var waited = 0f;
                while (!resolved && waited < 15f)
                {
                    waited += Time.unscaledDeltaTime;
                    yield return null;
                }
            }

            var init = Addressables.InitializeAsync(false);
            yield return init;
            Addressables.Release(init);

            var check = Addressables.CheckForCatalogUpdates(false);
            yield return check;
            var offline = check.Status != AsyncOperationStatus.Succeeded;
            var catalogUpdated = false;
            if (!offline && check.Result != null && check.Result.Count > 0)
            {
                var update = Addressables.UpdateCatalogs(check.Result, false);
                yield return update;
                catalogUpdated = update.Status == AsyncOperationStatus.Succeeded;
                Addressables.Release(update);
            }

            Addressables.Release(check);

            var size = Addressables.GetDownloadSizeAsync(key);
            yield return size;
            var sizeOk = size.Status == AsyncOperationStatus.Succeeded;
            var bytes = sizeOk ? size.Result : 0;
            var sizeError = size.OperationException?.Message;
            Addressables.Release(size);
            if (!sizeOk)
            {
                onComplete?.Invoke(new ContentResult(false, catalogUpdated, offline, 0, sizeError ?? "could not read the download size"));
                yield break;
            }

            if (bytes == 0)
            {
                onComplete?.Invoke(new ContentResult(true, catalogUpdated, offline, 0, null));
                yield break;
            }

            var download = Addressables.DownloadDependenciesAsync(key, false);
            while (!download.IsDone)
            {
                var status = download.GetDownloadStatus();
                onProgress?.Invoke(new ContentProgress(status.DownloadedBytes, status.TotalBytes));
                yield return null;
            }

            var ok = download.Status == AsyncOperationStatus.Succeeded;
            var error = download.OperationException?.Message;
            Addressables.Release(download);
            if (ok)
            {
                onProgress?.Invoke(new ContentProgress(bytes, bytes));
            }

            onComplete?.Invoke(new ContentResult(ok, catalogUpdated, offline, ok ? bytes : 0, ok ? null : error ?? "download failed"));
        }
    }
}
