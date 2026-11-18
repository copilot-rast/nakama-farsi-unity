using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PolicePatrol.Sdk.Payments;
using PolicePatrol.Sdk.Shop;
using Xunit;

namespace PolicePatrol.Sdk.Tests
{
    public class ShopTests
    {
        private const string PaymentId = "8a6a2d44-56a1-4a51-9d3e-7b1f3e3c0a11";

        private sealed class Store : IStoreBilling
        {
            public Store(string method = PaymentMethods.Bazaar) => Method = method;

            public string Method { get; }

            public List<string> Consumed { get; } = new List<string>();

            public List<StorePurchase> Owned { get; } = new List<StorePurchase>();

            public int Opened { get; private set; }

            public void Purchase(string sku, string developerPayload, Action<StorePurchaseResult> onComplete)
            {
                Opened++;
                onComplete(StorePurchaseResult.Success("tok"));
            }

            public void Consume(string purchaseToken, Action<bool> onComplete)
            {
                Consumed.Add(purchaseToken);
                onComplete(true);
            }

            public void GetPurchases(Action<IReadOnlyList<StorePurchase>> onComplete) => onComplete(Owned);
        }

        private static string Catalog(string method, bool subscription = false) =>
            "{\"products\":[{\"id\":\"prod\",\"key\":\"coins\",\"name\":\"Coins\",\"priceToman\":1000,\"finalToman\":800,\"paymentMethods\":[\"" + method + "\"],\"sku\":{\"" + method + "\":\"coins_100\"},\"isSubscription\":" + (subscription ? "true" : "false") + "}]}";

        private static PaymentPoller Poller() => new PaymentPoller((w, then) => then()) { RewardTimeout = TimeSpan.Zero, Timeout = TimeSpan.Zero };

        private static async Task<ShopItem> Item(ProductIAP shop)
        {
            var loaded = await Harness.Call<IReadOnlyList<ShopItem>>(shop.Load);
            return loaded.Data.Single();
        }

        [Fact]
        public async Task RewardNotGrantedBecomesAnErrorAfterTheStorePurchaseIsConsumed()
        {
            var t = Harness.Start();
            t.Routes["economy_catalog"] = p => Catalog("bazaar");
            t.Routes["economy_purchase_start"] = p => "{\"paymentId\":\"" + PaymentId + "\",\"status\":\"store\",\"sku\":\"coins_100\",\"developerPayload\":\"" + PaymentId + "\"}";
            t.Routes["economy_purchase_submit"] = p => "{\"paymentId\":\"" + PaymentId + "\",\"status\":\"success\",\"rewardGranted\":false,\"error\":\"REWARD_PENDING\"}";
            t.Routes["economy_purchase_status"] = p => "{\"paymentId\":\"" + PaymentId + "\",\"status\":\"success\",\"rewardGranted\":false,\"error\":\"REWARD_PENDING\"}";
            var store = new Store();
            var shop = new ProductIAP(store, Poller());
            var item = await Item(shop);
            Assert.Equal(800, item.FinalPrice);
            var r = await Harness.Call<Payment>(cb => shop.Buy(item, cb));
            Assert.False(r.IsSuccess);
            Assert.Equal(PaymentErrorCodes.RewardPending, r.Error.Code);
            Assert.Equal("REWARD_PENDING", r.Error.ServerCode);
            Assert.Equal(PaymentId, (string)r.Error.Meta["paymentId"]);
            Assert.Equal(new[] { "tok" }, store.Consumed);

            t.Routes["economy_purchase_status"] = p => "{\"paymentId\":\"" + PaymentId + "\",\"status\":\"success\",\"rewardGranted\":true}";
            r = await Harness.Call<Payment>(cb => shop.Buy(item, cb));
            Assert.True(r.IsSuccess);
            Assert.Equal(true, r.Data.RewardGranted);
        }

        [Fact]
        public async Task OnlyVerifiedReceiptsAreConsumed()
        {
            var t = Harness.Start();
            t.Routes["economy_catalog"] = p => Catalog("bazaar");
            t.Routes["economy_purchase_start"] = p => "{\"paymentId\":\"" + PaymentId + "\",\"status\":\"store\",\"sku\":\"coins_100\",\"developerPayload\":\"" + PaymentId + "\"}";
            t.Routes["economy_purchase_submit"] = p => "{\"paymentId\":\"" + PaymentId + "\",\"status\":\"pending\",\"error\":\"STORE_UNAVAILABLE\"}";
            var store = new Store();
            var shop = new ProductIAP(store, Poller());
            var item = await Item(shop);
            var r = await Harness.Call<Payment>(cb => shop.Buy(item, cb));
            Assert.True(r.IsSuccess);
            Assert.Equal(PaymentStatus.Pending, r.Data.Status);
            Assert.Empty(store.Consumed);

            t.Routes["economy_purchase_submit"] = p => new NakamaFarsi.Sdk.RpcServerException("{\"code\":\"STORE_MODE_CHANGED\",\"status\":503}", 503);
            r = await Harness.Call<Payment>(cb => shop.Buy(item, cb));
            Assert.Equal(PaymentErrorCodes.StoreModeChanged, r.Error.Code);
            Assert.Empty(store.Consumed);
        }

        [Fact]
        public async Task RecheckFollowsPaymentsWhoseRewardIsPending()
        {
            var t = Harness.Start();
            t.Routes["economy_payments_mine"] = p => "{\"items\":[{\"paymentId\":\"p9\",\"status\":\"success\",\"rewardGranted\":false},{\"paymentId\":\"p8\",\"status\":\"success\",\"rewardGranted\":true}]}";
            t.Routes["economy_purchase_status"] = p => p.Contains("p9") ? "{\"paymentId\":\"p9\",\"status\":\"success\",\"rewardGranted\":false,\"error\":\"REWARD_PENDING\"}" : "{}";
            var shop = new ProductIAP(new Store(), Poller());
            var tcs = new TaskCompletionSource<RecheckResult>();
            shop.RecheckPending(r => tcs.TrySetResult(r));
            var result = await tcs.Task.WaitAsync(TimeSpan.FromSeconds(10));
            Assert.Equal(new[] { "p9" }, result.RewardPendingPaymentIds);
            Assert.Contains(PaymentErrorCodes.RewardPending, result.PendingErrorCodes);
            Assert.Equal(1, t.Calls.Count(c => c.Id == "economy_purchase_status"));
        }
    
        [Fact]
        public async Task MyketNeverOpensSubscriptions()
        {
            var t = Harness.Start();
            t.Routes["economy_catalog"] = p => Catalog("myket", true);
            var store = new Store(PaymentMethods.Myket);
            var shop = new ProductIAP(store, Poller());
            var loaded = await Harness.Call<IReadOnlyList<ShopItem>>(shop.Load);
            Assert.Empty(loaded.Data);

            t.Routes["economy_catalog"] = p => Catalog("bazaar", true);
            var bazaarItem = await Item(new ProductIAP(new Store(), Poller()));
            var item = new ShopItem(bazaarItem.Product, PaymentMethods.Myket, "coins_100");
            var r = await Harness.Call<Payment>(cb => shop.Buy(item, cb));
            Assert.Equal(PaymentErrorCodes.SubscriptionNotSupported, r.Error.Code);
            Assert.Equal(0, store.Opened);
            Assert.DoesNotContain(t.Calls, c => c.Id == "economy_purchase_start");
        }
    

        [Fact]
        public async Task ACoinPurchaseWhoseRewardIsPendingIsNotASuccess()
        {
            var t = Harness.Start();
            t.Routes["economy_purchase_start"] = p => "{\"paymentId\":\"" + PaymentId + "\",\"status\":\"success\",\"rewardGranted\":false,\"error\":\"REWARD_PENDING\"}";
            var pending = await Harness.Call<InitiatePaymentResult>(cb => PaymentProvider.Initiate("p1", PaymentMethods.InApp, cb));
            Assert.False(pending.IsSuccess);
            Assert.Equal(PaymentErrorCodes.RewardPending, pending.Error.Code);
            Assert.Equal(PaymentId, (string)pending.Error.Meta["paymentId"]);

            t.Routes["economy_purchase_start"] = p => "{\"paymentId\":\"" + PaymentId + "\",\"status\":\"success\",\"rewards\":[]}";
            Assert.True((await Harness.Call<InitiatePaymentResult>(cb => PaymentProvider.Initiate("p1", PaymentMethods.InApp, cb))).IsSuccess);
        }
    

        [Fact]
        public async Task ProductsSayWhichMethodsNeedAPhone()
        {
            var t = Harness.Start();
            t.Routes["economy_catalog"] = p => "{\"products\":[{\"id\":\"prod\",\"key\":\"coins\",\"name\":\"Coins\",\"priceToman\":1000,\"paymentMethods\":[\"zarinpal\",\"bazaar\"],\"phoneRequiredFor\":[\"zarinpal\"],\"phoneVerified\":false}]}";
            var list = await Harness.Call<PagedResult<Product>>(cb => ShopProvider.List(ListQuery.Page(1, 10), null, null, cb));
            var product = list.Data.Items[0];
            Assert.Equal(new[] { PaymentMethods.Zarrinpal }, product.PhoneRequiredFor);
            Assert.False(product.PhoneVerified);
            Assert.True(product.NeedsPhoneFor(PaymentMethods.Zarrinpal));
            Assert.True(product.NeedsPhoneFor("zarinpal"));
            Assert.False(product.NeedsPhoneFor(PaymentMethods.Bazaar));
            Assert.False(new ShopItem(product, PaymentMethods.Bazaar, "coins_100").NeedsPhone);
        }
    }
}
