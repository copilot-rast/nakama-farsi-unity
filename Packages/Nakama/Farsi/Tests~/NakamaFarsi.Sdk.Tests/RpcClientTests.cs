using System.Linq;
using System;
using System.Threading.Tasks;
using Nakama;
using Xunit;

namespace NakamaFarsi.Sdk.Tests
{
    public class RpcClientTests
    {
        private readonly FakeClock _clock = new FakeClock();
        private readonly FakeTransport _http = new FakeTransport("http");
        private readonly FakeTransport _socket = new FakeTransport("socket");

        private RpcClient Make(int retries = 1)
        {
            var options = new NakamaFarsiOptions { UseSocket = true, ReadRetries = retries, TimeoutSeconds = 1 };
            var client = new Client("http", "127.0.0.1", 1, "k");
            var sessions = new SessionManager(client, Jwt.StoreWithSession(_clock.UtcNow), options, _clock);
            Assert.NotNull(sessions.Current);
            return new RpcClient(options, sessions, _http, _socket, new ErrorCatalog(null)) { RetryDelayMilliseconds = 1 };
        }

        [Fact]
        public async Task SignInRpcsSignInWithTheDeviceFirstWhenThereIsNoSession()
        {
            var client = new Client("http", "127.0.0.1", 1, "k");
            var sessions = new SessionManager(client, new MemoryKeyValueStore(), new NakamaFarsiOptions(), _clock);
            Assert.Null(sessions.Current);
            var rpc = new RpcClient(new NakamaFarsiOptions { UseSocket = false }, sessions, _http, _socket, new ErrorCatalog(null));
            var e = await Assert.ThrowsAsync<ApiException>(() => rpc.CallRpcAsync("account_password_login", "{}", new RpcCallOptions { AllowAnonymous = true }));
            Assert.Equal(ApiError.NotLoggedInCode, e.Error.Code);
            Assert.Empty(_http.Calls);

            var signedIn = 0;
            rpc.SignInSilently = ct =>
            {
                signedIn++;
                sessions.Adopt(Jwt.Make(_clock.UtcNow.AddHours(2)), Jwt.Make(_clock.UtcNow.AddDays(30)));
                return Task.CompletedTask;
            };
            await Assert.ThrowsAsync<ApiException>(() => rpc.CallRpcAsync("account_me", "{}", RpcCallOptions.Read));
            Assert.Equal(0, signedIn);
            _http.Answers.Enqueue("{\"token\":\"t\"}");
            var res = await rpc.CallRpcAsync("account_password_login", "{}", RpcCallOptions.Write);
            Assert.Equal("{\"token\":\"t\"}", res);
            Assert.Equal(1, signedIn);
            Assert.Single(_http.Calls);
            _http.Answers.Enqueue("{}");
            await rpc.CallRpcAsync("publication_otp_request", "{}", RpcCallOptions.Write);
            Assert.Equal(1, signedIn);
        }

        [Fact]
        public void TheSilentDeviceIdIsTheConfiguredOneOrAStoredOne()
        {
            var store = new MemoryKeyValueStore();
            var a = new NakamaFarsiClient(new NakamaFarsiOptions { DeviceId = "n/a" }, store);
            var id = a.DeviceId;
            Assert.False(string.IsNullOrEmpty(id));
            Assert.Equal(id, new NakamaFarsiClient(new NakamaFarsiOptions(), store).DeviceId);
            Assert.Equal("dev-1", new NakamaFarsiClient(new NakamaFarsiOptions { DeviceId = "dev-1" }, store).DeviceId);
        }

        [Fact]
        public async Task PaymentCallsAlwaysUseHttp()
        {
            foreach (var id in new[] { "economy_purchase_start", "economy_purchase_submit", "economy_purchase_status", "economy_purchase_review" })
            {
                _http.Answers.Enqueue("{\"status\":\"success\"}");
                await Make().CallRpcAsync(id, "{}", RpcCallOptions.Write);
            }

            Assert.Empty(_socket.Calls);
            Assert.Equal(4, _http.Calls.Count);
        }

        [Fact]
        public async Task SocketFirst()
        {
            _socket.Answers.Enqueue("{\"ok\":1}");
            var res = await Make().CallRpcAsync("x_get", "{}", RpcCallOptions.Read);
            Assert.Equal("{\"ok\":1}", res);
            Assert.Single(_socket.Calls);
            Assert.Empty(_http.Calls);
        }

        [Fact]
        public async Task SocketDownGoesHttpEvenForWrites()
        {
            _socket.IsAvailable = false;
            _http.Answers.Enqueue("{\"bought\":true}");
            var res = await Make().CallRpcAsync("x_buy", "{}", RpcCallOptions.Write);
            Assert.Equal("{\"bought\":true}", res);
            Assert.Empty(_socket.Calls);
        }

        [Fact]
        public async Task NotSentSocketFailureFallsBackForWrites()
        {
            _socket.Answers.Enqueue(new RpcTransportException("closed before send", false));
            _http.Answers.Enqueue("{}");
            await Make().CallRpcAsync("x_buy", "{}", RpcCallOptions.Write);
            Assert.Single(_http.Calls);
        }

        [Fact]
        public async Task WriteIsNotResentAfterAnUncertainSocketFailure()
        {
            _socket.Answers.Enqueue(new RpcTransportException("dropped", true));
            var e = await Assert.ThrowsAsync<ApiException>(() => Make().CallRpcAsync("x_buy", "{}", RpcCallOptions.Write));
            Assert.Equal(ApiError.NetworkErrorCode, e.Error.Code);
            Assert.Empty(_http.Calls);
        }

        [Fact]
        public async Task ReadIsResentOverHttpWithRetries()
        {
            _socket.Answers.Enqueue(new RpcTransportException("dropped", true));
            _http.Answers.Enqueue(new RpcTransportException("reset", true));
            _http.Answers.Enqueue("{\"v\":2}");
            var res = await Make(retries: 1).CallRpcAsync("x_list", "{}", RpcCallOptions.Read);
            Assert.Equal("{\"v\":2}", res);
            Assert.Equal(2, _http.Calls.Count);
        }

        [Fact]
        public async Task IdempotentWritesMayBeResent()
        {
            _socket.Answers.Enqueue(new RpcTransportException("dropped", true));
            _http.Answers.Enqueue("{}");
            await Make().CallRpcAsync("analytics_track", "{}", new RpcCallOptions { Idempotent = true });
            Assert.Single(_http.Calls);
        }

        [Fact]
        public async Task ServerErrorOverSocketIsFinal()
        {
            _socket.Answers.Enqueue(new RpcServerException("{\"code\":\"INSUFFICIENT_BALANCE\",\"status\":402,\"message\":\"سکه کافی نیست\"}", 0));
            var e = await Assert.ThrowsAsync<ApiException>(() => Make().CallRpcAsync("x_list", "{}", RpcCallOptions.Read));
            Assert.Equal("INSUFFICIENT_BALANCE", e.Error.Code);
            Assert.Equal(402, e.Error.Status);
            Assert.Empty(_http.Calls);
        }

        [Fact]
        public async Task TimeoutBecomesTimeoutError()
        {
            _socket.IsAvailable = false;
            _http.Delay = TimeSpan.FromSeconds(3);
            var e = await Assert.ThrowsAsync<ApiException>(() => Make(retries: 0).CallRpcAsync("x_buy", "{}", RpcCallOptions.Write));
            Assert.Equal(ApiError.TimeoutCode, e.Error.Code);
            Assert.True(e.Error.IsNetworkError);
        }

        [Fact]
        public async Task NoSessionIsNotLoggedIn()
        {
            var options = new NakamaFarsiOptions();
            var sessions = new SessionManager(new Client("http", "127.0.0.1", 1, "k"), new MemoryKeyValueStore(), options, _clock);
            var rpc = new RpcClient(options, sessions, _http, _socket, null);
            var e = await Assert.ThrowsAsync<ApiException>(() => rpc.CallRpcAsync("x", "{}"));
            Assert.Equal(ApiError.NotLoggedInCode, e.Error.Code);
        }

        [Fact]
        public void ExpiredStoredSessionWithoutRefreshIsDropped()
        {
            var store = new MemoryKeyValueStore();
            store.Set("nf.session.token", Jwt.Make(_clock.UtcNow.AddHours(-1)));
            var sessions = new SessionManager(new Client("http", "127.0.0.1", 1, "k"), store, new NakamaFarsiOptions(), _clock);
            Assert.Null(sessions.Current);
            Assert.Null(store.Get("nf.session.token"));
        }

        [Fact]
        public async Task GeneratedWrapperFillsLangAndUsesReadOption()
        {
            var caller = new FakeCaller { Language = "en" };
            caller.Answers.Enqueue("{\"lang\":\"en\",\"enabled\":true,\"packs\":[],\"unknownField\":3}");
            var rpcs = new Generated.NakamaFarsiRpcs(caller);
            var st = await rpcs.Base.StickersAsync();
            Assert.Equal("base_stickers", caller.Calls[0].Id);
            Assert.Contains("\"lang\":\"en\"", caller.Calls[0].Payload);
            Assert.True(caller.Calls[0].Options.ReadOnly);
            Assert.Equal(true, st.Enabled);
            Assert.True(st.Extra.ContainsKey("unknownField"));

            caller.Answers.Enqueue("{}");
            await rpcs.Economy.ItemBuyAsync(new Generated.EconomyItemBuyRequest { Key = "tiggo8", RequestId = "r1" });
            Assert.False(caller.Calls[1].Options.ReadOnly);
            Assert.Contains("\"key\":\"tiggo8\"", caller.Calls[1].Payload);
        }

        [Fact]
        public async Task WrongFieldShapeIsSkippedAndRawIsKept()
        {
            var caller = new FakeCaller { Language = "fa" };
            caller.Answers.Enqueue("{\"enabled\":true,\"chats\":[1,2],\"lang\":\"fa\"}");
            var rpcs = new Generated.NakamaFarsiRpcs(caller);
            var st = await rpcs.Base.StickersAsync();
            Assert.Null(st.Chats);
            Assert.Equal("fa", st.Lang);
            Assert.Equal(2, st.Raw["chats"].Count());
        }
    

        private sealed class ListLogger : ISdkLogger
        {
            public System.Collections.Generic.List<string> Lines { get; } = new System.Collections.Generic.List<string>();

            public void Log(string message) => Lines.Add(message);

            public void Warn(string message) => Lines.Add(message);
        }

        [Fact]
        public void TheBaseLayerLogsOnlyWhenLoggingIsOn()
        {
            var lines = new ListLogger();
            var options = new NakamaFarsiOptions { Logging = false };
            var client = new NakamaFarsiClient(options, new MemoryKeyValueStore(), logger: lines);
            client.Logger.Log("hidden");
            client.Logger.Warn("hidden");
            Assert.Empty(lines.Lines);
            options.Logging = true;
            client.Logger.Warn("shown");
            Assert.Equal(new[] { "shown" }, lines.Lines);
        }
    }
}
