using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Editor
{
    public sealed class ContentTarget
    {
        public ContentTarget(string contentId, string key, string url, int version, int fileCount, long totalBytes, string versionName = null)
        {
            ContentId = contentId;
            Key = key;
            Url = url;
            Version = version;
            FileCount = fileCount;
            TotalBytes = totalBytes;
            VersionName = versionName ?? (version == 0 ? string.Empty : version.ToString());
        }

        public string ContentId { get; }

        public string Key { get; }

        public string Url { get; }

        public int Version { get; }

        public string VersionName { get; }

        public int FileCount { get; }

        public long TotalBytes { get; }

        public static ContentTarget From(JObject pack, int packs) => new ContentTarget(
            (string)pack["id"],
            (string)pack["platform"],
            (string)pack["baseUrl"] ?? (string)pack["url"] ?? string.Empty,
            packs > 0 ? packs : 1,
            (int?)pack["fileCount"] ?? 0,
            (long?)pack["totalBytes"] ?? 0,
            (string)pack["version"]);
    }
}
