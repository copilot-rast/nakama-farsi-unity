using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace PolicePatrol.Sdk.Assets
{
    public sealed class FileAssetCache : IAssetCache
    {
        private readonly string _directory;

        public FileAssetCache(string directory)
        {
            _directory = directory ?? throw new ArgumentNullException(nameof(directory));
        }

        public GameAsset Load(string assetId)
        {
            var asset = Read<GameAsset>("asset:" + assetId);
            return asset != null && asset.AssetId == assetId ? asset : null;
        }

        public void Save(GameAsset asset) => Write("asset:" + asset.AssetId, asset);

        public void Remove(string assetId) => Delete("asset:" + assetId);

        public string[] LoadIndex(string folder) => Read<string[]>(AssetCacheKeys.Index(folder));

        public void SaveIndex(string folder, string[] assetIds) => Write(AssetCacheKeys.Index(folder), assetIds);

        public void Clear()
        {
            try
            {
                if (Directory.Exists(_directory))
                {
                    Directory.Delete(_directory, true);
                }
            }
            catch (Exception error) when (IsDiskError(error))
            {
            }
        }

        private string PathOf(string key) => Path.Combine(_directory, AssetCacheKeys.FileName(key) + ".json");

        private T Read<T>(string key) where T : class
        {
            try
            {
                var path = PathOf(key);
                return File.Exists(path) ? JsonConvert.DeserializeObject<T>(File.ReadAllText(path, Encoding.UTF8), SdkJson.Settings) : null;
            }
            catch (Exception error) when (IsDiskError(error) || error is JsonException)
            {
                return null;
            }
        }

        private void Write(string key, object value)
        {
            try
            {
                Directory.CreateDirectory(_directory);
                var path = PathOf(key);
                var temp = path + ".tmp";
                File.WriteAllText(temp, SdkJson.Serialize(value), new UTF8Encoding(false));
                if (File.Exists(path))
                {
                    File.Replace(temp, path, null);
                }
                else
                {
                    File.Move(temp, path);
                }
            }
            catch (Exception error) when (IsDiskError(error))
            {
            }
        }

        private void Delete(string key)
        {
            try
            {
                File.Delete(PathOf(key));
            }
            catch (Exception error) when (IsDiskError(error))
            {
            }
        }

        private static bool IsDiskError(Exception error) => error is IOException || error is UnauthorizedAccessException;
    }
}
