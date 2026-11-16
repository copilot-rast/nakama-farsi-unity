using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NakamaFarsi.Sdk
{
    public sealed class HttpGetResult
    {
        public HttpGetResult(long status, string body, string etag, int? maxAgeSeconds)
        {
            Status = status;
            Body = body;
            ETag = etag;
            MaxAgeSeconds = maxAgeSeconds;
        }

        public long Status { get; }

        public string Body { get; }

        public string ETag { get; }

        public int? MaxAgeSeconds { get; }
    }

    public interface IHttpGet
    {
        Task<HttpGetResult> GetAsync(string url, IDictionary<string, string> headers, int timeoutSeconds, CancellationToken ct);
    }

    public sealed class HttpClientGet : IHttpGet
    {
        private static readonly HttpClient Shared = new HttpClient { Timeout = Timeout.InfiniteTimeSpan };

        public async Task<HttpGetResult> GetAsync(string url, IDictionary<string, string> headers, int timeoutSeconds, CancellationToken ct)
        {
            using (var cts = CancellationTokenSource.CreateLinkedTokenSource(ct))
            using (var req = new HttpRequestMessage(HttpMethod.Get, url))
            {
                cts.CancelAfter(TimeSpan.FromSeconds(Math.Max(1, timeoutSeconds)));
                if (headers != null)
                {
                    foreach (var h in headers)
                    {
                        req.Headers.TryAddWithoutValidation(h.Key, h.Value);
                    }
                }

                using (var res = await Shared.SendAsync(req, cts.Token).ConfigureAwait(false))
                {
                    var body = res.Content == null ? string.Empty : await res.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var etag = res.Headers.ETag?.ToString();
                    var maxAge = res.Headers.CacheControl?.MaxAge;
                    return new HttpGetResult((long)res.StatusCode, body, etag, maxAge.HasValue ? (int?)maxAge.Value.TotalSeconds : null);
                }
            }
        }
    }
}
