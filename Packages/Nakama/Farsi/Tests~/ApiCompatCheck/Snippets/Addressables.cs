using System.Threading.Tasks;

namespace UnityEngine.AddressableAssets
{
    public struct CatalogHandle
    {
        public Task<object> Task => System.Threading.Tasks.Task.FromResult<object>(null);
    }

    public static class Addressables
    {
        public static CatalogHandle LoadContentCatalogAsync(string catalogPath) => default;
    }
}
