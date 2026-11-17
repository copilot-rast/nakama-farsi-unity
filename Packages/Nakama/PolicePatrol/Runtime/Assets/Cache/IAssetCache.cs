namespace PolicePatrol.Sdk.Assets
{
    public interface IAssetCache
    {
        GameAsset Load(string assetId);

        void Save(GameAsset asset);

        void Remove(string assetId);

        string[] LoadIndex(string folder);

        void SaveIndex(string folder, string[] assetIds);

        void Clear();
    }
}
