using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NakamaFarsi.Sdk.Tests
{
    public class ErrorCatalogRefreshTests
    {
        private sealed class CountingGet : IHttpGet
        {
            public int Calls;

            public string Message = "اول";

            public Task<HttpGetResult> GetAsync(string url, IDictionary<string, string> headers, int timeoutSeconds, CancellationToken ct)
            {
                Interlocked.Increment(ref Calls);
                var body = "{\"lang\":\"fa\",\"cacheSeconds\":86400,\"errors\":{\"GIFT_EXPIRED\":{\"status\":410,\"message\":\"" + Message + "\"}}}";
                return Task.FromResult(new HttpGetResult(200, body, null, null));
            }
        }

        [Fact]
        public async Task StaleCatalogIsReloadedOnTheNextErrorAndTheRefreshIsPublic()
        {
            var clock = new FakeClock();
            var http = new CountingGet();
            var transport = new FakeTransport("http");
            var client = new NakamaFarsiClient(new NakamaFarsiOptions { UseSocket = false }, Jwt.StoreWithSession(clock.UtcNow), clock: clock, http: http, httpTransport: transport, socketTransport: transport);
            await client.RefreshErrorCatalogAsync();
            Assert.Equal(1, http.Calls);
            Assert.False(client.IsErrorCatalogStale);

            transport.Answers.Enqueue(new RpcServerException("GIFT_EXPIRED", 400));
            var e = await Assert.ThrowsAsync<ApiException>(() => client.CallRpcAsync("gift_redeem", "{}"));
            Assert.Equal("اول", e.Error.Message);
            Assert.Equal(1, http.Calls);

            clock.Advance(31 * 60);
            Assert.True(client.IsErrorCatalogStale);
            http.Message = "دوم";
            transport.Answers.Enqueue(new RpcServerException("GIFT_EXPIRED", 400));
            await Assert.ThrowsAsync<ApiException>(() => client.CallRpcAsync("gift_redeem", "{}"));
            for (var i = 0; i < 50 && http.Calls < 2; i++)
            {
                await Task.Delay(20);
            }

            Assert.Equal(2, http.Calls);
            transport.Answers.Enqueue(new RpcServerException("GIFT_EXPIRED", 400));
            e = await Assert.ThrowsAsync<ApiException>(() => client.CallRpcAsync("gift_redeem", "{}"));
            Assert.Equal("دوم", e.Error.Message);

            await client.RefreshErrorCatalogIfStaleAsync();
            Assert.Equal(2, http.Calls);
            await client.RefreshErrorCatalogAsync(true);
            Assert.Equal(3, http.Calls);
        }
    }
}
