using System;
using System.Threading;
using System.Threading.Tasks;
using Nakama;
using NakamaFarsi.Sdk.Analytics;
using NakamaFarsi.Sdk.Auth;
using NakamaFarsi.Sdk.Payments;
using NakamaFarsi.Sdk.Social;
using NakamaFarsi.Sdk.Generated;
using Newtonsoft.Json;

namespace NakamaFarsi.Sdk
{
    public sealed class NakamaFarsiClient : IRpcCaller
    {
        private readonly IHttpGet _http;
        private AnalyticsClient _analytics;

        public NakamaFarsiClient(
            NakamaFarsiOptions options,
            IKeyValueStore store = null,
            IMainThreadDispatcher dispatcher = null,
            ISdkLogger logger = null,
            IClient client = null,
            Func<IClient, ISocket> socketFactory = null,
            IHttpGet http = null,
            IClock clock = null,
            IRpcTransport httpTransport = null,
            IRpcTransport socketTransport = null)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));
            Store = store ?? new MemoryKeyValueStore();
            Dispatcher = dispatcher ?? ImmediateDispatcher.Instance;
            Logger = logger ?? NullLogger.Instance;
            Clock = clock ?? SystemClock.Instance;
            _http = http ?? new HttpClientGet();
            Client = client ?? new Client(options.Scheme, options.Host, options.Port, options.ServerKey, HttpRequestAdapter.WithGzip(), false);
            Client.Timeout = Math.Max(1, options.TimeoutSeconds);
            Session = new SessionManager(Client, Store, options, Clock, Logger);
            Socket = new SocketManager(Client, Session, socketFactory, Dispatcher, Logger) { LangTag = options.Language };
            Errors = new ErrorCatalog(Store, options.StorePrefix);
            Rpc = new RpcClient(options, Session, httpTransport ?? new HttpRpcTransport(Client, () => options.HttpKey), socketTransport ?? new SocketRpcTransport(Socket), Errors, Logger);
            Rpcs = new NakamaFarsiRpcs(this);
            Phone = new PhoneLogin(this);
            Payments = new PaymentClient(this);
            Chat = new ChatClient(this);
            Notifications = new NotificationClient(this);
            Session.SessionChanged += changed =>
            {
                if (options.UseSocket && Socket.Socket != null)
                {
                    _ = Socket.ReconnectAsync();
                }
            };
        }

        public NakamaFarsiOptions Options { get; }

        public IClient Client { get; }

        public SessionManager Session { get; }

        public SocketManager Socket { get; }

        public ErrorCatalog Errors { get; }

        public RpcClient Rpc { get; }

        public NakamaFarsiRpcs Rpcs { get; }

        public PhoneLogin Phone { get; }

        public PaymentClient Payments { get; }

        public ChatClient Chat { get; }

        public NotificationClient Notifications { get; }

        public IKeyValueStore Store { get; }

        public IMainThreadDispatcher Dispatcher { get; }

        public ISdkLogger Logger { get; }

        public IClock Clock { get; }

        public string Language
        {
            get => Options.Language;
            set
            {
                Options.Language = value;
                Socket.LangTag = value;
            }
        }

        public bool IsLoggedIn => Session.IsLoggedIn;

        public AnalyticsClient Analytics => _analytics ?? UseAnalytics(new AnalyticsOptions());

        public AnalyticsClient UseAnalytics(AnalyticsOptions options)
        {
            _analytics = new AnalyticsClient(this, Store, Clock, Logger, options ?? new AnalyticsOptions(), Dispatcher)
            {
                CanSend = () => Session.Current != null,
            };
            return _analytics;
        }

        public async Task<ISession> LoginWithDeviceAsync(string deviceId, bool create = true, string username = null, CancellationToken ct = default)
        {
            var session = await Session.AuthenticateDeviceAsync(deviceId, create, username, null, ct).ConfigureAwait(false);
            AfterLogin();
            return session;
        }

        public void LoginWithDevice(string deviceId, Action<ApiResult<ISession>> onComplete) =>
            Deliver(LoginWithDeviceAsync(deviceId), onComplete);

        public void AfterLogin()
        {
            if (Options.UseSocket && Session.Current != null)
            {
                _ = Socket.ConnectAsync();
            }

            _ = RefreshErrorCatalogAsync();
        }

        public async Task LogoutAsync()
        {
            await Socket.CloseAsync().ConfigureAwait(false);
            await Session.LogoutAsync().ConfigureAwait(false);
        }

        public Task RefreshErrorCatalogAsync(bool force = false)
        {
            if (!force && Errors.IsFresh(Clock.UtcNow, Language))
            {
                return Task.CompletedTask;
            }

            Func<string, string, Task<string>> rpc = null;
            if (Session.Current != null)
            {
                rpc = (id, payload) => Rpc.CallRpcAsync(id, payload, RpcCallOptions.Read);
            }

            return Errors.RefreshAsync(Options, _http, rpc, Language, Clock.UtcNow);
        }

        public Task<string> CallRpcAsync(string id, string payload, RpcCallOptions options = null, CancellationToken ct = default) =>
            Rpc.CallRpcAsync(id, payload, options, ct);

        public async Task<T> CallRpcAsync<T>(string id, object request, RpcCallOptions options = null, CancellationToken ct = default)
        {
            var body = await Rpc.CallRpcAsync(id, SdkJson.Serialize(request), options, ct).ConfigureAwait(false);
            try
            {
                return string.IsNullOrWhiteSpace(body) ? default : JsonConvert.DeserializeObject<T>(body, SdkJson.Settings);
            }
            catch (JsonException e)
            {
                throw new ApiException(ApiError.InvalidResponse(e.Message), e);
            }
        }

        public void CallRpc<T>(string id, object request, Action<ApiResult<T>> onComplete, RpcCallOptions options = null) =>
            Deliver(CallRpcAsync<T>(id, request, options), onComplete);

        public void Deliver<T>(Task<T> task, Action<ApiResult<T>> onComplete)
        {
            task.ContinueWith(t =>
            {
                ApiResult<T> result;
                if (t.IsFaulted)
                {
                    var e = t.Exception?.GetBaseException();
                    result = ApiResult<T>.Fail(e is ApiException api ? api.Error : ApiError.Network(e?.Message));
                }
                else if (t.IsCanceled)
                {
                    result = ApiResult<T>.Fail(ApiError.Network("cancelled"));
                }
                else
                {
                    result = ApiResult<T>.Ok(t.Result);
                }

                if (onComplete != null)
                {
                    Dispatcher.Post(() => onComplete(result));
                }
            }, TaskScheduler.Default);
        }
    }
}
