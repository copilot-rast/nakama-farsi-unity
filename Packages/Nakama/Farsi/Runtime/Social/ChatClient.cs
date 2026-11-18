using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nakama;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NakamaFarsi.Sdk.Social
{
    public sealed class ChatMessage
    {
        public string Id { get; set; }
        public string ChannelId { get; set; }
        public string SenderId { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        public string Sticker { get; set; }
        public string StickerPack { get; set; }
        public string StickerUrl { get; set; }
        public string CreateTime { get; set; }
        public bool IsSticker => !string.IsNullOrEmpty(Sticker);
        public JObject Content { get; set; }

        public static ChatMessage From(IApiChannelMessage m)
        {
            JObject content = null;
            try
            {
                content = string.IsNullOrEmpty(m.Content) ? new JObject() : JObject.Parse(m.Content);
            }
            catch (JsonException)
            {
                content = new JObject();
            }

            return new ChatMessage
            {
                Id = m.MessageId,
                ChannelId = m.ChannelId,
                SenderId = m.SenderId,
                Username = m.Username,
                Text = (string)content["text"],
                Sticker = (string)content["sticker"],
                StickerPack = (string)content["stickerPack"],
                StickerUrl = (string)content["stickerUrl"],
                CreateTime = m.CreateTime,
                Content = content,
            };
        }
    }

    public sealed class ChatClient
    {
        private sealed class Joined
        {
            public string Target;
            public ChannelType Type;
            public bool Persistence;
            public ISocket Socket;
        }

        private readonly NakamaFarsiClient _client;
        private readonly Dictionary<string, Joined> _joined = new Dictionary<string, Joined>(StringComparer.Ordinal);

        public ChatClient(NakamaFarsiClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _client.Socket.ChannelMessageReceived += m => MessageReceived?.Invoke(ChatMessage.From(m));
            _client.Socket.Connected += () => _ = RejoinAsync();
        }

        public event Action<ChatMessage> MessageReceived;

        public event Action<IChannel> Rejoined;

        public IReadOnlyCollection<string> JoinedChannelIds
        {
            get
            {
                lock (_joined)
                {
                    return new List<string>(_joined.Keys);
                }
            }
        }

        public void ForgetChannels()
        {
            lock (_joined)
            {
                _joined.Clear();
            }
        }

        public async Task RejoinAsync()
        {
            var socket = _client.Socket.Socket;
            if (socket == null)
            {
                return;
            }

            List<KeyValuePair<string, Joined>> stale;
            lock (_joined)
            {
                stale = new List<KeyValuePair<string, Joined>>();
                foreach (var pair in _joined)
                {
                    if (!ReferenceEquals(pair.Value.Socket, socket))
                    {
                        stale.Add(pair);
                    }
                }
            }

            foreach (var pair in stale)
            {
                try
                {
                    var channel = await socket.JoinChatAsync(pair.Value.Target, pair.Value.Type, pair.Value.Persistence, false).ConfigureAwait(false);
                    lock (_joined)
                    {
                        if (_joined.TryGetValue(pair.Key, out var still) && ReferenceEquals(still, pair.Value))
                        {
                            still.Socket = socket;
                        }
                    }

                    _client.Dispatcher.Post(() => Rejoined?.Invoke(channel));
                }
                catch (Exception e)
                {
                    _client.Logger.Log("Chat rejoin failed for " + pair.Key + ": " + e.Message);
                }
            }
        }

        public Task<IChannel> JoinDirectAsync(string userId, bool persistence = true, CancellationToken ct = default) => Join(userId, ChannelType.DirectMessage, persistence, ct);

        public Task<IChannel> JoinRoomAsync(string room, bool persistence = true, CancellationToken ct = default) => Join(room, ChannelType.Room, persistence, ct);

        public Task<IChannel> JoinGroupAsync(string groupId, bool persistence = true, CancellationToken ct = default) => Join(groupId, ChannelType.Group, persistence, ct);

        public async Task LeaveAsync(string channelId)
        {
            lock (_joined)
            {
                _joined.Remove(channelId);
            }

            var socket = await SocketAsync().ConfigureAwait(false);
            await socket.LeaveChatAsync(channelId).ConfigureAwait(false);
        }

        public Task<IChannelMessageAck> SendTextAsync(string channelId, string text, CancellationToken ct = default) =>
            Send(channelId, new JObject { ["text"] = text ?? string.Empty });

        public Task<IChannelMessageAck> SendStickerAsync(string channelId, string stickerRef, CancellationToken ct = default) =>
            Send(channelId, new JObject { ["sticker"] = stickerRef ?? string.Empty });

        public Task<IChannelMessageAck> SendAsync(string channelId, JObject content, CancellationToken ct = default) => Send(channelId, content ?? new JObject());

        public async Task<IReadOnlyList<ChatMessage>> HistoryAsync(string channelId, int limit = 50, bool forward = false, string cursor = null, CancellationToken ct = default)
        {
            var session = await _client.Session.EnsureAsync(ct).ConfigureAwait(false);
            var list = await _client.Client.ListChannelMessagesAsync(session, channelId, limit, forward, cursor, null, ct).ConfigureAwait(false);
            var result = new List<ChatMessage>();
            foreach (var m in list.Messages)
            {
                result.Add(ChatMessage.From(m));
            }

            return result;
        }

        public Task<string> StickersJsonAsync(CancellationToken ct = default) =>
            _client.CallRpcAsync("base_stickers", new JObject { ["lang"] = _client.Language }.ToString(Formatting.None), RpcCallOptions.Read, ct);

        public Task<string> QuotaJsonAsync(CancellationToken ct = default) =>
            _client.CallRpcAsync("base_chat_quota", new JObject { ["lang"] = _client.Language }.ToString(Formatting.None), RpcCallOptions.Read, ct);

        private async Task<IChannel> Join(string target, ChannelType type, bool persistence, CancellationToken ct)
        {
            var socket = await SocketAsync().ConfigureAwait(false);
            try
            {
                var channel = await socket.JoinChatAsync(target, type, persistence, false).ConfigureAwait(false);
                lock (_joined)
                {
                    _joined[channel.Id] = new Joined { Target = target, Type = type, Persistence = persistence, Socket = socket };
                }

                return channel;
            }
            catch (Exception e) when (!(e is ApiException))
            {
                throw new ApiException(ErrorOf(e), e);
            }
        }

        private async Task<IChannelMessageAck> Send(string channelId, JObject content)
        {
            var socket = await SocketAsync().ConfigureAwait(false);
            try
            {
                return await socket.WriteChatMessageAsync(channelId, content.ToString(Formatting.None)).ConfigureAwait(false);
            }
            catch (Exception e) when (!(e is ApiException))
            {
                throw new ApiException(ErrorOf(e), e);
            }
        }

        private ApiError ErrorOf(Exception e)
        {
            var status = e is ApiResponseException api ? api.StatusCode : 0;
            return ErrorParser.Parse(e.Message, status, _client.Errors, _client.Language);
        }

        private async Task<ISocket> SocketAsync()
        {
            if (!_client.Socket.IsConnected)
            {
                await _client.Socket.ConnectAsync().ConfigureAwait(false);
            }

            return _client.Socket.Socket ?? throw new ApiException(ApiError.Network("socket is not connected"));
        }
    }
}
