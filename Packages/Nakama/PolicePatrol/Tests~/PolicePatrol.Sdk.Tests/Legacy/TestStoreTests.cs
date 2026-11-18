using FluentAssertions;
using PolicePatrol.Sdk.Payments;
using PolicePatrol.Sdk.Shop;
using Xunit;

namespace PolicePatrol.Sdk.Tests;

public sealed class TestStoreTests : IDisposable
{
    private const string PaymentId = "6f1c2a9e-3b4d-4c5e-8f70-1a2b3c4d5e6f";

    public void Dispose() => PolicePatrolSdk.Shutdown();

    private sealed class LedgerStore : IStoreBilling
    {
        public LedgerStore(TestStoreLedger ledger) => Ledger = ledger;

        public TestStoreLedger Ledger { get; }

        public bool AppClosesBeforeServerAnswers { get; set; }

        public string Method => PaymentMethods.Bazaar;

        public void Purchase(string sku, string developerPayload, Action<StorePurchaseResult> onComplete) =>
            onComplete(Ledger.Pay(sku, developerPayload, AppClosesBeforeServerAnswers));

        public void Consume(string purchaseToken, Action<bool> onComplete) => onComplete(Ledger.Consume(purchaseToken));

        public void GetPurchases(Action<IReadOnlyList<StorePurchase>> onComplete) => onComplete(Ledger.Unconsumed);
    }

    [Fact]
    public void Create_embeds_the_developer_payload_and_PayloadOf_reads_it_back()
    {
        var token = SandboxPurchaseToken.Create(PaymentId);

        token.Should().MatchRegex("^sandbox-" + PaymentId + "-[0-9a-f]{32}$");
        SandboxPurchaseToken.PayloadOf(token).Should().Be(PaymentId);
        SandboxPurchaseToken.Create(PaymentId).Should().NotBe(token);
    }

    [Theory]
    [InlineData("tok-123")]
    [InlineData("sandbox-")]
    [InlineData("sandbox-abc-")]
    [InlineData("sandbox--abc")]
    [InlineData(null)]
    public void PayloadOf_rejects_tokens_that_are_not_sandbox_tokens(string token) =>
        SandboxPurchaseToken.PayloadOf(token).Should().BeNull();

    [Fact]
    public void Pay_keeps_the_purchase_until_it_is_consumed_and_saves_every_change()
    {
        string saved = null;
        var ledger = new TestStoreLedger(null, json => saved = json);

        var paid = ledger.Pay("test_coins", PaymentId);

        paid.IsSuccess.Should().BeTrue();
        SandboxPurchaseToken.PayloadOf(paid.PurchaseToken).Should().Be(PaymentId);
        var restored = new TestStoreLedger(saved);
        restored.Unconsumed.Should().ContainSingle().Which.Should().BeEquivalentTo(new { Sku = "test_coins", paid.PurchaseToken, DeveloperPayload = PaymentId });

        ledger.Consume(paid.PurchaseToken).Should().BeTrue();
        new TestStoreLedger(saved).Unconsumed.Should().BeEmpty();
    }

    [Fact]
    public void A_broken_saved_ledger_starts_empty() =>
        new TestStoreLedger("{not json").Unconsumed.Should().BeEmpty();

    [Fact]
    public async Task App_closed_before_the_server_answered_is_recovered_by_RecheckPending()
    {
        var transport = Harness.Start();
        transport.Routes["economy_purchase_start"] = _ => "{\"paymentId\":\"" + PaymentId + "\",\"sku\":\"test_coins\",\"developerPayload\":\"" + PaymentId + "\",\"status\":\"pending\"}";
        transport.Routes["economy_purchase_submit"] = _ => "{\"paymentId\":\"" + PaymentId + "\",\"status\":\"success\",\"rewardGranted\":true}";
        var store = new LedgerStore(new TestStoreLedger()) { AppClosesBeforeServerAnswers = true };
        var shop = new ProductIAP(store);

        var bought = await Harness.Call<Payment>(cb => shop.Buy(Item(), cb));
        var paidToken = store.Ledger.Unconsumed.Should().ContainSingle().Which.PurchaseToken;
        var rechecked = new TaskCompletionSource<RecheckResult>();
        shop.RecheckPending(result => rechecked.TrySetResult(result));
        var recheck = await rechecked.Task.WaitAsync(TimeSpan.FromSeconds(10));

        bought.Error.Code.Should().Be(ProductIAP.PurchaseFailedCode);
        bought.Error.Message.Should().Be(TestStoreLedger.SimulatedNetworkFailure);
        transport.Calls.Select(r => r.Id).Should().Equal("economy_purchase_start", "economy_purchase_submit");
        transport.Calls[1].Payload.Should().Contain(paidToken);
        recheck.Confirmed.Should().Be(1);
        store.Ledger.Unconsumed.Should().BeEmpty();
    }

    private static ShopItem Item() =>
        new(new Product("p-1", "Pack", "pack", true, 20, 40000, null, null, null, null, null, null, null, new[] { "bazaar" }, new Dictionary<string, string> { ["bazaar"] = "test_coins" }, false, "prize-1", null, null, null, null, DateTimeOffset.UnixEpoch, DateTimeOffset.UnixEpoch), "bazaar", "test_coins");
}
