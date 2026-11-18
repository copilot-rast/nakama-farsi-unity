using FluentAssertions;
using PolicePatrol.Sdk.Payments;
using PolicePatrol.Sdk.Shop;
using Xunit;

namespace PolicePatrol.Sdk.Tests;

public sealed class StoreSelectorTests
{
    private static readonly StoreConfig Live = new(PaymentMethods.Bazaar, false, "rsa");
    private static readonly StoreConfig Sandbox = new(PaymentMethods.Bazaar, true, "rsa");

    [Theory]
    [InlineData(true, true, StoreChoice.TestStore)]
    [InlineData(false, false, StoreChoice.TestStore)]
    [InlineData(false, true, StoreChoice.TestStore)]
    public void The_test_store_is_used_in_sandbox_and_off_device(bool sandbox, bool pluginInstalled, StoreChoice expected)
    {
        StoreSelector.Choose(PaymentMethods.Bazaar, sandbox ? Sandbox : Live, onAndroidDevice: sandbox, pluginInstalled).Should().Be(expected);
    }

    [Fact]
    public void A_live_bazaar_build_on_a_device_uses_bazaar_only_when_poolakey_is_in_the_build()
    {
        StoreSelector.Choose(PaymentMethods.Bazaar, Live, true, true).Should().Be(StoreChoice.Bazaar);
        StoreSelector.Choose(PaymentMethods.Bazaar, Live, true, false).Should().Be(StoreChoice.PluginMissing);
    }

    [Fact]
    public void A_live_myket_build_on_a_device_uses_myket_only_when_the_myket_library_is_in_the_build()
    {
        var live = Live with { Method = PaymentMethods.Myket };
        StoreSelector.Choose(PaymentMethods.Myket, live, true, true).Should().Be(StoreChoice.Myket);
        StoreSelector.Choose(PaymentMethods.Myket, live, true, false).Should().Be(StoreChoice.PluginMissing);
        StoreSelector.Choose(PaymentMethods.Myket, Sandbox with { Method = PaymentMethods.Myket }, true, false).Should().Be(StoreChoice.TestStore);
    }

    [Fact]
    public void A_store_the_sdk_has_no_billing_for_is_unsupported()
    {
        StoreSelector.Choose("google", Live with { Method = "google" }, true, true).Should().Be(StoreChoice.Unsupported);
    }
}
