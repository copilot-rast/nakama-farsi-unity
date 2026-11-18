using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PolicePatrol.Sdk.Assets
{
    public static class AssetPaths
    {
        public const int MaxIdLength = 128;
        public const int MaxSyncItems = 500;

        public static string IdKey(string id) => (id ?? string.Empty).ToLower(CultureInfo.InvariantCulture);

        public static Dictionary<string, string[]> Duplicates(IEnumerable<KeyValuePair<string, string>> idAndPath) =>
            idAndPath
                .GroupBy(pair => IdKey(pair.Key), StringComparer.Ordinal)
                .Where(group => group.Count() > 1)
                .ToDictionary(group => group.Key, group => group.Select(pair => pair.Value).ToArray(), StringComparer.OrdinalIgnoreCase);

        public static bool IsValidId(string id) =>
            !string.IsNullOrEmpty(id) && id.Length <= MaxIdLength && id.All(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') || c == '_' || c == '-' || c == '.' || c == ':');

        public static string Folder(string path)
        {
            var raw = (path ?? string.Empty).Replace('\\', '/').Trim().Trim('/');
            return raw.Length == 0 ? string.Empty : string.Join("/", raw.Split('/').Select(segment => segment.Trim()));
        }

        public static string FolderOfAssetPath(string assetPath)
        {
            var path = (assetPath ?? string.Empty).Replace('\\', '/');
            var slash = path.LastIndexOf('/');
            var directory = slash < 0 ? string.Empty : path.Substring(0, slash);
            if (directory == "Assets" || directory.StartsWith("Assets/", System.StringComparison.Ordinal))
            {
                directory = directory.Length == 6 ? string.Empty : directory.Substring(7);
            }

            return Folder(directory);
        }
    }
}
