using System;

namespace PolicePatrol.Sdk.Assets
{
    public sealed record AssetFolder(string Folder, GameAsset[] Assets, int Downloaded, bool Offline)
    {
        public GameAsset Find(string assetId) => Array.Find(Assets, asset => asset.AssetId == assetId);

        public GameAsset[] OfType(string type) => Array.FindAll(Assets, asset => asset.Type == type);
    }
}
