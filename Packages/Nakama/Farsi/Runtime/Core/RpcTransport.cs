using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Nakama;

namespace NakamaFarsi.Sdk
{
    public sealed class RpcTransportException : Exception
    {
        public RpcTransportException(string message, bool maybeDelivered, Exception inner = null)
            : base(message, inner)
        {
            MaybeDelivered = maybeDelivered;
        }

        public bool MaybeDelivered { get; }
    }

    public sealed class RpcServerException : Exception
    {
        public RpcServerException(string message, long status, Exception inner = null)
            : base(message, inner)
        {
            Status = status;
        }

        public long Status { get; }
    }

    public interface IRpcTransport
    {
        string Name { get; }

        bool IsAvailable { get; }

        Task<string> CallAsync(ISession session, string id, string payload, CancellationToken ct);
    }

    public sealed class HttpRpcTransport : IRpcTransport
    {
        private readonly IClient _client;
        private readonly Func<string> _httpKey;

        public HttpRpcTransport(IClient client, Func<string> httpKey = null)
        {
            _client = client;
            _httpKey = httpKey;
        }

        public string Name => "http";

        public bool IsAvailable => true;

        public async Task<string> CallAsync(ISession session, string id, string payload, CancellationToken ct)
        {
            try
            {
                var res = session == null
                    ? await _client.RpcAsync(_httpKey?.Invoke() ?? string.Empty, id, payload, new RetryConfiguration(1, 1), ct).ConfigureAwait(false)
                    : await _client.RpcAsync(session, id, payload, new RetryConfiguration(1, 1), ct).ConfigureAwait(false);
                return res?.Payload ?? string.Empty;
            }
            catch (ApiResponseException e) when (e.StatusCode > 0)
            {
                throw new RpcServerException(e.Message, e.StatusCode, e);
            }
            catch (OperationCanceledException) when (ct.IsCancellationRequested)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new RpcTransportException(e.Message, true, e);
            }
        }
    }

    public sealed class SocketRpcTransport : IRpcTransport
    {
        private readonly SocketManager _sockets;

        public SocketRpcTransport(SocketManager sockets)
        {
            _sockets = sockets;
        }

        public string Name => "socket";

        public bool IsAvailable => _sockets.IsConnected;

        public async Task<string> CallAsync(ISession session, string id, string payload, CancellationToken ct)
        {
            var socket = _sockets.Socket;
            if (socket == null || !socket.IsConnected)
            {
                throw new RpcTransportException("socket not connected", false);
            }

            try
            {
                var call = socket.RpcAsync(id, payload);
                var done = await Task.WhenAny(call, Task.Delay(Timeout.Infinite, ct)).ConfigureAwait(false);
                if (done != call)
                {
                    ct.ThrowIfCancellationRequested();
                }

                var res = await call.ConfigureAwait(false);
                return res?.Payload ?? string.Empty;
            }
            catch (OperationCanceledException) when (ct.IsCancellationRequested)
            {
                throw;
            }
            catch (WebSocketException e) when (socket.IsConnected)
            {
                throw new RpcServerException(e.Message, 0, e);
            }
            catch (Exception e)
            {
                throw new RpcTransportException(e.Message, true, e);
            }
        }
    }
}
