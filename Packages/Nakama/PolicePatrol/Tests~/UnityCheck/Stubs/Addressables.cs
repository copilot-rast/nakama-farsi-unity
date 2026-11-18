using System;
using System.Collections;
using System.Collections.Generic;

namespace UnityEngine.ResourceManagement.AsyncOperations
{
    public enum AsyncOperationStatus
    {
        None,
        Succeeded,
        Failed,
    }

    public struct DownloadStatus
    {
        public long TotalBytes;
        public long DownloadedBytes;
        public bool IsDone;

        public float Percent => TotalBytes > 0 ? (float)DownloadedBytes / TotalBytes : 0f;
    }

    public struct AsyncOperationHandle<TObject> : IEnumerator
    {
        public TObject Result => default;

        public AsyncOperationStatus Status => AsyncOperationStatus.None;

        public Exception OperationException => null;

        public bool IsDone => true;

        public object Current => null;

        public DownloadStatus GetDownloadStatus() => default;

        public bool MoveNext() => false;

        public void Reset() { }
    }

    public struct AsyncOperationHandle : IEnumerator
    {
        public AsyncOperationStatus Status => AsyncOperationStatus.None;

        public Exception OperationException => null;

        public bool IsDone => true;

        public object Current => null;

        public DownloadStatus GetDownloadStatus() => default;

        public bool MoveNext() => false;

        public void Reset() { }
    }
}

namespace UnityEngine.ResourceManagement.ResourceLocations
{
    public interface IResourceLocation
    {
        string InternalId { get; }
    }
}

namespace UnityEngine.AddressableAssets.ResourceLocators
{
    public interface IResourceLocator
    {
    }
}

namespace UnityEngine.AddressableAssets
{
    using UnityEngine.AddressableAssets.ResourceLocators;
    using UnityEngine.ResourceManagement.AsyncOperations;

    public class AssetReference
    {
        public AssetReference(string guid) { }

        public UnityEngine.Object Asset => null;

        public bool RuntimeKeyIsValid() => false;

        public bool IsValid() => false;

        public AsyncOperationHandle<TObject> LoadAssetAsync<TObject>() => default;

        public bool SetEditorSubObject(UnityEngine.Object value) => true;
    }

    public static class Addressables
    {
        public static Func<UnityEngine.ResourceManagement.ResourceLocations.IResourceLocation, string> InternalIdTransformFunc { get; set; }

        public static AsyncOperationHandle<IResourceLocator> InitializeAsync(bool autoReleaseHandle) => default;

        public static AsyncOperationHandle<List<string>> CheckForCatalogUpdates(bool autoReleaseHandle = true) => default;

        public static AsyncOperationHandle<List<IResourceLocator>> UpdateCatalogs(IEnumerable<string> catalogs = null, bool autoReleaseHandle = true) => default;

        public static AsyncOperationHandle<long> GetDownloadSizeAsync(object key) => default;

        public static AsyncOperationHandle<IList<UnityEngine.ResourceManagement.ResourceLocations.IResourceLocation>> LoadResourceLocationsAsync(object key, Type type = null) => default;

        public static AsyncOperationHandle<TObject> LoadAssetAsync<TObject>(object key) => default;

        public static AsyncOperationHandle DownloadDependenciesAsync(object key, bool autoReleaseHandle = false) => default;

        public static void Release<TObject>(AsyncOperationHandle<TObject> handle) { }

        public static void Release(AsyncOperationHandle handle) { }
    }
}
