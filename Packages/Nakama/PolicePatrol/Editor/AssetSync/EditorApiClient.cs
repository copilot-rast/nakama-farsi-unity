using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Editor
{
    public static class EditorApiClient
    {
        private static readonly HttpClient Http = new HttpClient { Timeout = Timeout.InfiniteTimeSpan };

        public static Task<T> SendJsonAsync<T>(AssetSyncSettings settings, HttpMethod method, string path, JToken body) =>
            SendAsync<T>(settings, method, path, body == null ? null : new StringContent(body.ToString(Formatting.None), Encoding.UTF8, "application/json"), TimeSpan.FromMinutes(3));

        public static async Task<T> SendAsync<T>(AssetSyncSettings settings, HttpMethod method, string path, HttpContent content, TimeSpan timeout)
        {
            using (var request = new HttpRequestMessage(method, settings.ServerUrl.Trim().TrimEnd('/') + path))
            using (var cancel = new CancellationTokenSource(timeout))
            {
                request.Headers.Add("X-Api-Key", settings.ApiKey);
                request.Content = content;

                using (var response = await Http.SendAsync(request, cancel.Token))
                {
                    var text = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                    {
                        throw AssetSyncException.From((int)response.StatusCode, text);
                    }

                    return JsonConvert.DeserializeObject<T>(text, SdkJson.Settings);
                }
            }
        }
    }
}
