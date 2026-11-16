using System;
using System.Threading;
using System.Threading.Tasks;
using Nakama;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NakamaFarsi.Sdk.Social
{
    public sealed class LiveNotification
    {
        public string Id { get; set; }
        public int Code { get; set; }
        public string Subject { get; set; }
        public JObject Content { get; set; }
        public string SenderId { get; set; }
        public bool Persistent { get; set; }
        public string CreateTime { get; set; }

        public static LiveNotification From(IApiNotification n)
        {
            JObject content;
            try
            {
                content = string.IsNullOrEmpty(n.Content) ? new JObject() : JObject.Parse(n.Content);
            }
            catch (JsonException)
            {
                content = new JObject();
            }

            return new LiveNotification { Id = n.Id, Code = n.Code, Subject = n.Subject, Content = content, SenderId = n.SenderId, Persistent = n.Persistent, CreateTime = n.CreateTime };
        }
    }

    public sealed class NotificationClient
    {
        private readonly NakamaFarsiClient _client;

        public NotificationClient(NakamaFarsiClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _client.Socket.NotificationReceived += n => Received?.Invoke(LiveNotification.From(n));
        }

        public event Action<LiveNotification> Received;

        public Task<string> InboxJsonAsync(int limit = 20, string cursor = null, CancellationToken ct = default) =>
            _client.CallRpcAsync("publication_inbox", new JObject { ["limit"] = limit, ["cursor"] = cursor ?? string.Empty, ["lang"] = _client.Language }.ToString(Formatting.None), RpcCallOptions.Read, ct);

        public Task<string> MarkSeenAsync(params string[] ids) =>
            _client.CallRpcAsync("publication_inbox_seen", new JObject { ["ids"] = new JArray(ids ?? Array.Empty<string>()) }.ToString(Formatting.None), RpcCallOptions.Write);
    }
}
