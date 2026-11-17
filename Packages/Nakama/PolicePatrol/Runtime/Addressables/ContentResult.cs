namespace PolicePatrol.Sdk.Unity
{
    public sealed class ContentResult
    {
        public ContentResult(bool isSuccess, bool catalogUpdated, bool offline, long downloadedBytes, string error)
        {
            IsSuccess = isSuccess;
            CatalogUpdated = catalogUpdated;
            Offline = offline;
            DownloadedBytes = downloadedBytes;
            Error = error;
        }

        public bool IsSuccess { get; }

        public bool CatalogUpdated { get; }

        public bool Offline { get; }

        public long DownloadedBytes { get; }

        public string Error { get; }
    }
}
