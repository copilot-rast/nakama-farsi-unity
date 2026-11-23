namespace PolicePatrol.Sdk.Assets
{
    public interface IAssetCacheMeta
    {
        AssetCacheState LoadState(string folder);

        void SaveState(string folder, AssetCacheState state);
    }
}
