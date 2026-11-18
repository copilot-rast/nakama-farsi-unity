using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PolicePatrol.Sdk.Inventory;
using NF = NakamaFarsi.Sdk;
using Xunit;

namespace PolicePatrol.Sdk.Tests
{
    public class InventoryRetryTests
    {
        private static string RequestId(string payload) => Regex.Match(payload, "\"requestId\":\"([^\"]+)\"").Groups[1].Value;

        [Fact]
        public async Task RetriesOfTheSameBuyKeepTheirRequestIdUntilAFinalAnswer()
        {
            var t = Harness.Start();
            t.Routes["economy_item_buy"] = p => new NF.RpcServerException("{\"code\":\"INTERNAL\",\"status\":500}", 500);
            await Harness.Call<ItemChange>(cb => InventoryProvider.Buy("Tiggo8", cb));
            var first = RequestId(t.Calls.Last().Payload);
            await Harness.Call<ItemChange>(cb => InventoryProvider.Buy("Tiggo8", cb));
            Assert.Equal(first, RequestId(t.Calls.Last().Payload));

            t.Routes["economy_item_buy"] = p => "{\"item\":{\"key\":\"tiggo8\",\"owned\":true},\"paid\":[]}";
            var ok = await Harness.Call<ItemChange>(cb => InventoryProvider.Buy("Tiggo8", cb));
            Assert.True(ok.IsSuccess);
            Assert.Equal(first, RequestId(t.Calls.Last().Payload));
            await Harness.Call<ItemChange>(cb => InventoryProvider.Buy("Tiggo8", cb));
            Assert.NotEqual(first, RequestId(t.Calls.Last().Payload));

            t.Routes["economy_item_buy"] = p => new NF.RpcServerException("{\"code\":\"INSUFFICIENT_BALANCE\",\"status\":402}", 402);
            await Harness.Call<ItemChange>(cb => InventoryProvider.Buy("Tiggo8", cb));
            var failed = RequestId(t.Calls.Last().Payload);
            await Harness.Call<ItemChange>(cb => InventoryProvider.Buy("Tiggo8", cb));
            Assert.NotEqual(failed, RequestId(t.Calls.Last().Payload));
        }

        [Fact]
        public async Task GivenRequestIdsAreSentAsIs()
        {
            var t = Harness.Start();
            t.Routes["inventoryx_upgrade"] = p => new NF.RpcServerException("{\"code\":\"UPGRADE_MAXED\",\"status\":409}", 409);
            await Harness.Call<UpgradeChange>(cb => InventoryProvider.Upgrade("gun", "Power", 1, cb, "game-42"));
            Assert.Equal("game-42", RequestId(t.Calls.Last().Payload));
        }
    }
}
