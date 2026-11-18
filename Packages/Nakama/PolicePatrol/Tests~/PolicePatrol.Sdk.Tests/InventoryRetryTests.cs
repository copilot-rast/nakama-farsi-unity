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
    
        [Fact]
        public async Task CurrenciesComeFromTheWalletEvenWithStorageItems()
        {
            var t = Harness.Start();
            t.Routes["economy_balances"] = p => "{\"wallet\":{\"coin\":120,\"gem\":3},\"items\":[{\"key\":\"badge\",\"value\":1}]}";
            var coin = await Harness.Call<Economy.UserCurrency>(cb => Economy.CurrencyProvider.GetByKey("coin", cb));
            Assert.Equal(120, coin.Data.Value);
            var all = await Harness.Call<PagedResult<Economy.UserCurrency>>(cb => Economy.CurrencyProvider.List(1, 10, cb));
            Assert.Equal(new[] { "coin", "gem" }, all.Data.Items.Select(i => i.Currency.Key).OrderBy(k => k));
        }
    
        [Fact]
        public async Task ItemsCarryTheTagDiscountedPrice()
        {
            var t = Harness.Start();
            t.Routes["economy_inventory"] = p => "{\"level\":1,\"items\":[{\"key\":\"hilux\",\"price\":{\"currencyKey\":\"coin\",\"amount\":1000},\"finalPrice\":{\"currencyKey\":\"coin\",\"amount\":800},\"discountPercent\":20},{\"key\":\"tiggo\",\"price\":{\"currencyKey\":\"coin\",\"amount\":500}}]}";
            var inv = await Harness.Call<PlayerInventory>(InventoryProvider.Get);
            var hilux = inv.Data.Items.Single(i => i.Key == "hilux");
            Assert.Equal(1000, hilux.Prices[0].Amount);
            Assert.Equal(800, hilux.FinalPrices[0].Amount);
            Assert.True(hilux.HasDiscount);
            var tiggo = inv.Data.Items.Single(i => i.Key == "tiggo");
            Assert.Equal(500, tiggo.FinalPrices[0].Amount);
            Assert.False(tiggo.HasDiscount);
        }
    
        [Fact]
        public async Task ServerOwnedStagesKeepTheServerCode()
        {
            var t = Harness.Start();
            t.Routes["campaign_attempt_complete"] = p => new NF.RpcServerException("{\"code\":\"STAGE_SERVER_OWNED\",\"status\":403,\"meta\":{\"owner\":\"cup\"}}", 403);
            var r = await Harness.Call<Stages.StageResult>(cb => Stages.StageProvider.Complete("s1", "a1", true, 30, 90, cb));
            Assert.Equal(Stages.StageErrorCodes.ServerOwned, r.Error.Code);
            Assert.Equal("cup", (string)r.Error.Meta["owner"]);
        }
    
        [Fact]
        public async Task FreeRideLimitsAreAResultNotAnError()
        {
            var t = Harness.Start();
            t.Routes["campaign_chapters"] = p => "{\"xp\":10,\"level\":1,\"chapters\":[],\"freeride\":[{\"key\":\"city\",\"name\":\"City\",\"xp\":5,\"cooldownSeconds\":600}]}";
            var attempt = await Harness.Call<Stages.StageAttempt>(cb => Stages.StageProvider.Start("city", cb));
            Assert.DoesNotContain(t.Calls, c => c.Id == "campaign_attempt_start");

            t.Routes["campaign_freeride_claim"] = p => new NF.RpcServerException("{\"code\":\"REWARD_LIMITED\",\"status\":409,\"meta\":{\"reason\":\"cooldown\",\"nextRewardAt\":\"2026-11-18T10:00:00Z\",\"rewardsLeftToday\":2}}", 409);
            var limited = await Harness.Call<Stages.StageResult>(cb => Stages.StageProvider.Complete("city", attempt.Data.AttemptId, true, 60, null, cb));
            Assert.True(limited.IsSuccess);
            Assert.True(limited.Data.IsRewardLimited);
            Assert.Equal(Stages.StageErrorCodes.LimitedCooldown, limited.Data.RewardLimited);
            Assert.Equal(new System.DateTimeOffset(2026, 11, 18, 10, 0, 0, System.TimeSpan.Zero), limited.Data.NextRewardAt);
            Assert.Equal(2, limited.Data.RewardsLeftToday);

            t.Routes["campaign_freeride_claim"] = p => "{\"key\":\"city\",\"rewards\":[{\"currencyKey\":\"coin\",\"amount\":50}],\"xpGained\":5,\"xp\":15,\"level\":1,\"nextRewardAt\":\"2026-11-18T10:10:00Z\",\"rewardsLeftToday\":1}";
            var paid = await Harness.Call<Stages.StageResult>(cb => Stages.StageProvider.Complete("city", attempt.Data.AttemptId, true, 60, null, cb));
            Assert.False(paid.Data.IsRewardLimited);
            Assert.Equal(5, paid.Data.XpGained);
            Assert.Equal(15, paid.Data.Xp);
            Assert.Equal(1, paid.Data.RewardsLeftToday);
        }
    }
}
