using System;
using System.Threading;
using System.Threading.Tasks;
using Nakama;

namespace NakamaFarsi.Sdk
{
    public sealed class SocketManager
    {
        private readonly IClient _client;
        private readonly SessionManager _sessions;
        private readonly Func<IClient, ISocket> _factory;
        private readonly IMainThreadDispatcher _dispatcher;
        private readonly ISdkLogger _logger;
        private readonly object _gate = new object();
        private ISocket _socket;
        private bool _wanted;
        private int _attempt;
        private int _generation;
        private Task _connecting;

        public SocketManager(IClient client, SessionManager sessions, Func<IClient, ISocket> factory = null, IMainThreadDispatcher dispatcher = null, ISdkLogger logger = null)
        {
            _client = client;
            _sessions = sessions;
            _factory = factory ?? (Func<IClient, ISocket>)(c => Nakama.Socket.From(c));
            _dispatcher = dispatcher ?? ImmediateDispatcher.Instance;
            _logger = logger ?? NullLogger.Instance;
        }

        public ISocket Socket => _socket;

        public bool IsConnected => _socket != null && _socket.IsConnected;

        public int MaxBackoffSeconds { get; set; } = 30;

        public int ConnectTimeoutSeconds { get; set; } = 10;

        public string LangTag { get; set; } = "en";

        public event Action Connected;

        public event Action<string> Disconnected;

        public event Action<IApiNotification> NotificationReceived;

        public event Action<IApiChannelMessage> ChannelMessageReceived;

        public Task ConnectAsync()
        {
            lock (_gate)
            {
                _wanted = true;
                if (IsConnected)
                {
                    return Task.CompletedTask;
                }

                if (_connecting != null && !_connecting.IsCompleted)
                {
                    return _connecting;
                }

                _connecting = ConnectOnce(_generation);
                return _connecting;
            }
        }

        public async Task CloseAsync()
        {
            ISocket socket;
            lock (_gate)
            {
                _wanted = false;
                _generation++;
                socket = _socket;
                _socket = null;
            }

            if (socket != null)
            {
                try
                {
                    await socket.CloseAsync().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    _logger.Warn("Socket close: " + e.Message);
                }
            }
        }

        public async Task ReconnectAsync()
        {
            var wanted = _wanted;
            await CloseAsync().ConfigureAwait(false);
            if (wanted)
            {
                await ConnectAsync().ConfigureAwait(false);
            }
        }

        private async Task ConnectOnce(int generation)
        {
            ISession session;
            try
            {
                session = await _sessions.EnsureAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _logger.Warn("Socket not connected, no session: " + e.Message);
                return;
            }

            var socket = _factory(_client);
            socket.Closed += reason => OnClosed(socket, generation, reason);
            socket.ReceivedError += e => _logger.Warn("Socket error: " + e.Message);
            socket.ReceivedNotification += n => _dispatcher.Post(() => NotificationReceived?.Invoke(n));
            socket.ReceivedChannelMessage += m => _dispatcher.Post(() => ChannelMessageReceived?.Invoke(m));
            try
            {
                await socket.ConnectAsync(session, true, ConnectTimeoutSeconds, LangTag).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _logger.Warn("Socket connect failed: " + e.Message);
                ScheduleRetry(generation);
                return;
            }

            lock (_gate)
            {
                if (generation != _generation || !_wanted)
                {
                    _ = socket.CloseAsync();
                    return;
                }

                _socket = socket;
                _attempt = 0;
            }

            _logger.Log("Socket connected");
            _dispatcher.Post(() => Connected?.Invoke());
        }

        private void OnClosed(ISocket socket, int generation, string reason)
        {
            lock (_gate)
            {
                if (!ReferenceEquals(socket, _socket))
                {
                    return;
                }

                _socket = null;
            }

            _logger.Log("Socket closed: " + reason);
            _dispatcher.Post(() => Disconnected?.Invoke(reason));
            ScheduleRetry(generation);
        }

        private void ScheduleRetry(int generation)
        {
            int wait;
            lock (_gate)
            {
                if (!_wanted || generation != _generation)
                {
                    return;
                }

                _attempt++;
                wait = (int)Math.Min(MaxBackoffSeconds, Math.Pow(2, Math.Min(10, _attempt - 1)));
            }

            Task.Delay(TimeSpan.FromSeconds(wait)).ContinueWith(_ =>
            {
                lock (_gate)
                {
                    if (!_wanted || generation != _generation || IsConnected || (_connecting != null && !_connecting.IsCompleted))
                    {
                        return;
                    }

                    _connecting = ConnectOnce(generation);
                }
            }, TaskScheduler.Default);
        }
    }
}
