namespace PolicePatrol.Sdk.Unity
{
    public sealed class ContentProgress
    {
        public ContentProgress(long downloadedBytes, long totalBytes)
        {
            DownloadedBytes = downloadedBytes;
            TotalBytes = totalBytes;
        }

        public long DownloadedBytes { get; }

        public long TotalBytes { get; }

        public float Percent => TotalBytes <= 0 ? 1f : (float)DownloadedBytes / TotalBytes;
    }
}
