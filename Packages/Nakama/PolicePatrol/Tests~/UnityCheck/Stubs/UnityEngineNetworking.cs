using System;

namespace UnityEngine.Networking
{
    public class DownloadHandler : IDisposable
    {
        public string text => string.Empty;

        public void Dispose() { }
    }

    public sealed class DownloadHandlerBuffer : DownloadHandler
    {
    }

    public class UploadHandler : IDisposable
    {
        public string contentType { get; set; }

        public void Dispose() { }
    }

    public sealed class UploadHandlerRaw : UploadHandler
    {
        public UploadHandlerRaw(byte[] data) { }
    }

    public sealed class UnityWebRequestAsyncOperation : AsyncOperation
    {
    }

    public sealed class UnityWebRequest : IDisposable
    {
        public enum Result
        {
            InProgress,
            Success,
            ConnectionError,
            ProtocolError,
            DataProcessingError,
        }

        public UnityWebRequest(string url, string method) { }

        public static UnityWebRequest Get(string url) => new UnityWebRequest(url, "GET") { downloadHandler = new DownloadHandlerBuffer() };

        public DownloadHandler downloadHandler { get; set; }

        public UploadHandler uploadHandler { get; set; }

        public int timeout { get; set; }

        public Result result => Result.Success;

        public string error => null;

        public long responseCode => 200;

        public void SetRequestHeader(string name, string value) { }

        public string GetResponseHeader(string name) => null;

        public UnityWebRequestAsyncOperation SendWebRequest() => new UnityWebRequestAsyncOperation();

        public void Dispose() { }
    }
}
