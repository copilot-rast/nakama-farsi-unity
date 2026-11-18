using System;
using System.Threading;
using System.Threading.Tasks;

namespace NakamaFarsi.Sdk
{
    public sealed class RpcCallOptions
    {
        public static readonly RpcCallOptions Write = new RpcCallOptions();
        public static readonly RpcCallOptions Read = new RpcCallOptions { ReadOnly = true };

        public bool ReadOnly { get; set; }

        public bool Idempotent { get; set; }

        public int TimeoutSeconds { get; set; }

        public bool HttpOnly { get; set; }

        public bool AllowAnonymous { get; set; }

        public bool MayResend => ReadOnly || Idempotent;
    }

    public interface IRpcCaller
    {
        string Language { get; }

        Task<string> CallRpcAsync(string id, string payload, RpcCallOptions options = null, CancellationToken ct = default);
    }

    public sealed class RpcClient : IRpcCaller
    {
        private readonly NakamaFarsiOptions _options;
        private readonly SessionManager _sessions;
        private readonly IRpcTransport _http;
        private readonly IRpcTransport _socket;
        private readonly ErrorCatalog _catalog;
        private readonly ISdkLogger _logger;

        public RpcClient(NakamaFarsiOptions options, SessionManager sessions, IRpcTransport http, IRpcTransport socket, ErrorCatalog catalog, ISdkLogger logger = null)
        {
            _options = options;
            _sessions = sessions;
            _http = http;
            _socket = socket;
            _catalog = catalog;
            _logger = logger ?? NullLogger.Instance;
        }

        public string Language => _options.Language;

        public int RetryDelayMilliseconds { get; set; } = 500;

        public Func<CancellationToken, Task> SignInSilently { get; set; }

        public Action ErrorSeen { get; set; }

        public static readonly System.Collections.Generic.HashSet<string> DeviceSignInRpcs = new System.Collections.Generic.HashSet<string>
        {
            "account_password_login",
            "account_password_forgot",
            "account_password_reset",
            "publication_otp_request",
            "publication_otp_verify",
        };

        public static readonly System.Collections.Generic.Dictionary<string, int> HttpOnlyRpcs = new System.Collections.Generic.Dictionary<string, int>
        {
            ["economy_purchase_start"] = 30,
            ["economy_purchase_submit"] = 30,
            ["economy_purchase_status"] = 0,
            ["economy_purchase_review"] = 30,
        };

        public async Task<string> CallRpcAsync(string id, string payload, RpcCallOptions options = null, CancellationToken ct = default)
        {
            options = options ?? RpcCallOptions.Write;
            if (HttpOnlyRpcs.TryGetValue(id, out var httpTimeout) && !options.HttpOnly)
            {
                options = new RpcCallOptions
                {
                    ReadOnly = options.ReadOnly,
                    Idempotent = options.Idempotent,
                    AllowAnonymous = options.AllowAnonymous,
                    HttpOnly = true,
                    TimeoutSeconds = Math.Max(options.TimeoutSeconds, httpTimeout),
                };
            }

            payload = string.IsNullOrEmpty(payload) ? "{}" : payload;
            var refreshed = false;
            while (true)
            {
                try
                {
                    if ((options.AllowAnonymous || DeviceSignInRpcs.Contains(id)) && !_sessions.IsLoggedIn && SignInSilently != null)
                    {
                        await SignInSilently(ct).ConfigureAwait(false);
                    }

                    var session = await _sessions.EnsureAsync(ct).ConfigureAwait(false);
                    return await Send(session, id, payload, options, ct).ConfigureAwait(false);
                }
                catch (RpcServerException e) when (e.Status == 401 && !refreshed)
                {
                    refreshed = true;
                    try
                    {
                        await _sessions.RefreshAsync(_sessions.Current, ct).ConfigureAwait(false);
                    }
                    catch (ApiException)
                    {
                        throw new ApiException(ErrorParser.Parse(e.Message, e.Status, _catalog, _options.Language), e);
                    }
                }
                catch (RpcServerException e)
                {
                    ErrorSeen?.Invoke();
                    var error = ErrorParser.Parse(e.Message, e.Status, _catalog, _options.Language);
                    Log(id, "error " + error);
                    throw new ApiException(error, e);
                }
            }
        }

        private async Task<string> Send(Nakama.ISession session, string id, string payload, RpcCallOptions options, CancellationToken ct)
        {
            var timeout = options.TimeoutSeconds > 0 ? options.TimeoutSeconds : _options.TimeoutSeconds;
            if (session != null && _options.UseSocket && !options.HttpOnly && _socket != null && _socket.IsAvailable)
            {
                try
                {
                    var res = await WithTimeout(t => _socket.CallAsync(session, id, payload, t), timeout, ct).ConfigureAwait(false);
                    Log(id, "socket ok");
                    return res;
                }
                catch (RpcTransportException e)
                {
                    if (e.MaybeDelivered && !options.MayResend)
                    {
                        Log(id, "socket failed after send, not resent: " + e.Message);
                        throw new ApiException(ApiError.Network(e.Message), e);
                    }

                    Log(id, "socket failed, HTTP fallback: " + e.Message);
                }
                catch (TimeoutException e)
                {
                    if (!options.MayResend)
                    {
                        throw new ApiException(ApiError.Timeout(timeout), e);
                    }

                    Log(id, "socket timeout, HTTP fallback");
                }
            }

            var attempts = options.MayResend ? 1 + Math.Max(0, _options.ReadRetries) : 1;
            for (var i = 1; ; i++)
            {
                try
                {
                    var res = await WithTimeout(t => _http.CallAsync(session, id, payload, t), timeout, ct).ConfigureAwait(false);
                    Log(id, "http ok");
                    return res;
                }
                catch (RpcTransportException e)
                {
                    if (i >= attempts)
                    {
                        throw new ApiException(ApiError.Network(e.Message), e);
                    }
                }
                catch (TimeoutException e)
                {
                    if (i >= attempts)
                    {
                        throw new ApiException(ApiError.Timeout(timeout), e);
                    }
                }

                await Task.Delay(RetryDelayMilliseconds * i, ct).ConfigureAwait(false);
            }
        }

        private static async Task<string> WithTimeout(Func<CancellationToken, Task<string>> call, int seconds, CancellationToken ct)
        {
            using (var cts = CancellationTokenSource.CreateLinkedTokenSource(ct))
            {
                var task = call(cts.Token);
                var done = await Task.WhenAny(task, Task.Delay(TimeSpan.FromSeconds(Math.Max(1, seconds)), cts.Token)).ConfigureAwait(false);
                if (done != task)
                {
                    ct.ThrowIfCancellationRequested();
                    cts.Cancel();
                    _ = task.ContinueWith(t => _ = t.Exception, TaskScheduler.Default);
                    throw new TimeoutException("rpc timed out after " + seconds + " s");
                }

                cts.Cancel();
                return await task.ConfigureAwait(false);
            }
        }

        private void Log(string id, string what)
        {
            if (_options.Logging)
            {
                _logger.Log("rpc " + id + ": " + what);
            }
        }
    }
}
