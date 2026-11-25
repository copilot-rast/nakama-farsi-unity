using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NakamaFarsi.Sdk.Payments;
using Xunit;

namespace NakamaFarsi.Sdk.Tests
{
    public class PaymentTests
    {
        private sealed class Store : IStoreBilling
        {
            public string Method => PaymentMethods.Bazaar;

            public List<string> Consumed { get; } = new List<string>();

            public List<StorePurchase> Owned { get; } = new List<StorePurchase>();

            public void Purchase(string sku, string developerPayload, Action<StorePurchaseResult> onComplete) => onComplete(StorePurchaseResult.Success("tok"));

            public void Consume(string purchaseToken, Action<bool> onComplete)
            {
                Consumed.Add(purchaseToken);
                onComplete(true);
            }

            public void GetPurchases(Action<IReadOnlyList<StorePurchase>> onComplete) => onComplete(Owned);
        }

        private readonly FakeClock _clock = new FakeClock();
        private readonly FakeTransport _http = new FakeTransport("http");

        private PaymentClient Make()
        {
            var options = new NakamaFarsiOptions { Host = "127.0.0.1", Port = 1, UseSocket = false, TimeoutSeconds = 1 };
            var client = new NakamaFarsiClient(options, Jwt.StoreWithSession(_clock.UtcNow), clock: _clock, httpTransport: _http, socketTransport: _http);
            client.ErrorCatalogRetryGap = TimeSpan.MaxValue;
            return new PaymentClient(client) { Delay = (w, ct) => Task.CompletedTask, RewardTimeout = TimeSpan.Zero, SubmitTimeout = TimeSpan.Zero };
        }

        [Fact]
        public async Task RewardNotGrantedIsAnErrorAndTheVerifiedPurchaseIsConsumed()
        {
            _http.Answers.Enqueue("{\"paymentId\":\"p1\",\"status\":\"store\",\"sku\":\"coins_100\",\"developerPayload\":\"p1\"}");
            _http.Answers.Enqueue("{\"paymentId\":\"p1\",\"status\":\"success\",\"rewardGranted\":false,\"error\":\"PRODUCT_ALREADY_BOUGHT\"}");
            _http.Answers.Enqueue("{\"paymentId\":\"p1\",\"status\":\"success\",\"rewardGranted\":false,\"error\":\"PRODUCT_ALREADY_BOUGHT\"}");
            var store = new Store();
            var r = await Make().BuyAsync("prod", PaymentMethods.Bazaar, store);
            Assert.Equal(PurchaseOutcome.RewardPending, r.Outcome);
            Assert.False(r.IsSuccess);
            Assert.Equal(PurchaseErrors.RewardPending, r.Error);
            Assert.Equal("PRODUCT_ALREADY_BOUGHT", r.ServerError);
            Assert.Equal(new[] { "tok" }, store.Consumed);
            Assert.Equal("economy_purchase_status", _http.Calls.Last().Id);
        }

        [Fact]
        public async Task RewardGrantedOnTheFollowUpIsASuccess()
        {
            _http.Answers.Enqueue("{\"paymentId\":\"p1\",\"status\":\"store\",\"sku\":\"coins_100\",\"developerPayload\":\"p1\"}");
            _http.Answers.Enqueue("{\"paymentId\":\"p1\",\"status\":\"success\",\"rewardGranted\":false,\"error\":\"REWARD_PENDING\"}");
            _http.Answers.Enqueue("{\"paymentId\":\"p1\",\"status\":\"success\",\"rewardGranted\":true,\"rewards\":[]}");
            var r = await Make().BuyAsync("prod", PaymentMethods.Bazaar, new Store());
            Assert.True(r.IsSuccess);
            Assert.True(r.RewardGranted);
        }

        [Fact]
        public async Task NonFinalSubmitAnswersAreNotConsumed()
        {
            _http.Answers.Enqueue("{\"paymentId\":\"p1\",\"status\":\"store\",\"sku\":\"coins_100\",\"developerPayload\":\"p1\"}");
            _http.Answers.Enqueue(new RpcServerException("{\"code\":\"STORE_MODE_CHANGED\",\"status\":503}", 503));
            var store = new Store();
            var r = await Make().BuyAsync("prod", PaymentMethods.Bazaar, store);
            Assert.Equal(PurchaseOutcome.Pending, r.Outcome);
            Assert.Empty(store.Consumed);

            _http.Answers.Enqueue("{\"paymentId\":\"p2\",\"status\":\"store\",\"sku\":\"coins_100\",\"developerPayload\":\"p2\"}");
            _http.Answers.Enqueue("{\"paymentId\":\"p2\",\"status\":\"pending\",\"error\":\"STORE_UNAVAILABLE\"}");
            r = await Make().BuyAsync("prod", PaymentMethods.Bazaar, store);
            Assert.Equal(PurchaseOutcome.Pending, r.Outcome);
            Assert.Empty(store.Consumed);
        }

        [Theory]
        [InlineData("STORE_CONFIGURATION_REJECTED", 503)]
        [InlineData("STORE_CONFIGURATION_REJECTED", 412)]
        [InlineData("METHOD_UNAVAILABLE", 503)]
        [InlineData("STORE_MODE_CHANGED", 400)]
        public void StoreNotReadyCodesAreNotRetryable(string code, int status)
        {
            var error = new ApiError(code, status, string.Empty);
            Assert.False(PaymentClient.IsRetryable(error));
            Assert.False(error.IsRetryable);
            Assert.True(PurchaseErrors.IsStoreNotReady(code));
        }

        [Fact]
        public void StoreUnavailableStaysRetryable()
        {
            Assert.True(PaymentClient.IsRetryable(new ApiError(PurchaseErrors.StoreUnavailable, 503, string.Empty)));
            Assert.True(new ApiError(PurchaseErrors.StoreUnavailable, 503, string.Empty).IsRetryable);
            Assert.True(PaymentClient.IsRetryable(ApiError.Network("down")));
        }

        [Fact]
        public async Task StoreConfigurationRejectedStopsAtOnceAndKeepsThePurchase()
        {
            _http.Answers.Enqueue("{\"paymentId\":\"p1\",\"status\":\"store\",\"sku\":\"fir_oil_100\",\"developerPayload\":\"p1\"}");
            _http.Answers.Enqueue(new RpcServerException("STORE_CONFIGURATION_REJECTED", 503));
            _http.Answers.Enqueue("{\"paymentId\":\"p1\",\"status\":\"success\",\"rewardGranted\":true}");
            var store = new Store();
            var payments = Make();
            payments.SubmitTimeout = TimeSpan.FromMinutes(1);
            var r = await payments.BuyAsync("prod", PaymentMethods.Bazaar, store);
            Assert.Equal(PurchaseOutcome.Pending, r.Outcome);
            Assert.True(r.IsStoreNotReady);
            Assert.Equal(PurchaseErrors.StoreConfigurationRejected, r.Error);
            Assert.Equal("p1", r.PaymentId);
            Assert.Empty(store.Consumed);
            Assert.Equal(new[] { "economy_purchase_start", "economy_purchase_submit" }, _http.Calls.Select(c => c.Id));
        }

        [Fact]
        public async Task ReviewStopsAtOnceOnStoreConfigurationRejected()
        {
            var store = new Store();
            store.Owned.Add(new StorePurchase("fir_oil_100", "tok-1", "p1"));
            _http.Answers.Enqueue(new RpcServerException("{\"code\":\"STORE_CONFIGURATION_REJECTED\",\"status\":412}", 400));
            _http.Answers.Enqueue("{\"items\":[]}");
            var payments = Make();
            payments.SubmitTimeout = TimeSpan.FromMinutes(1);
            var results = await payments.RecoverAsync(store);
            var one = Assert.Single(results);
            Assert.True(one.IsStoreNotReady);
            Assert.Empty(store.Consumed);
            Assert.Equal(new[] { "economy_purchase_review", "economy_payments_mine" }, _http.Calls.Select(c => c.Id));
        }

        [Fact]
        public async Task RecoverFollowsPaymentsWhoseRewardIsPending()
        {
            _http.Answers.Enqueue("{\"items\":[{\"paymentId\":\"p9\",\"status\":\"success\",\"rewardGranted\":false},{\"paymentId\":\"p8\",\"status\":\"success\",\"rewardGranted\":true}]}");
            _http.Answers.Enqueue("{\"paymentId\":\"p9\",\"status\":\"success\",\"rewardGranted\":true}");
            var results = await Make().RecoverAsync(new Store());
            var one = Assert.Single(results);
            Assert.Equal("p9", one.PaymentId);
            Assert.True(one.IsSuccess);
            Assert.Equal(new[] { "economy_payments_mine", "economy_purchase_status" }, _http.Calls.Select(c => c.Id));
        }

        [Fact]
        public async Task StartWithoutRewardFieldStaysASuccess()
        {
            _http.Answers.Enqueue("{\"paymentId\":\"g1\",\"status\":\"success\"}");
            var r = await Make().BuyAsync("prod", PaymentMethods.Coins);
            Assert.True(r.IsSuccess);
        }
    }
}
