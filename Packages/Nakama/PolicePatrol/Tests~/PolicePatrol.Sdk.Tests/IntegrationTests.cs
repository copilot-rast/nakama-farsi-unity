using System;
using System.Linq;
using System.Threading.Tasks;
using NakamaFarsi.Sdk;
using PolicePatrol.Sdk.Analytics;
using PolicePatrol.Sdk.Auth;
using PolicePatrol.Sdk.Economy;
using PolicePatrol.Sdk.FairPlay;
using PolicePatrol.Sdk.Inventory;
using PolicePatrol.Sdk.Stages;
using PolicePatrol.Sdk.Stats;
using PolicePatrol.Sdk.Users;
using Xunit;
using Xunit.Abstractions;

namespace PolicePatrol.Sdk.Tests
{
    public sealed class IntegrationFactAttribute : FactAttribute
    {
        public IntegrationFactAttribute()
        {
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("NF_IT_URL")))
            {
                Skip = "set NF_IT_URL (e.g. http://127.0.0.1:7650) to run against a server with the Police Patrol seed";
            }
        }
    }

    public class IntegrationTests : IDisposable
    {
        private readonly ITestOutputHelper _out;

        public IntegrationTests(ITestOutputHelper output)
        {
            _out = output;
        }

        public void Dispose() => PolicePatrolSdk.Shutdown();

        private static void Start(bool socket)
        {
            var options = new SdkOptions(Environment.GetEnvironmentVariable("NF_IT_URL"), "it", false, 15, "fa")
            {
                ServerKey = Environment.GetEnvironmentVariable("NF_IT_KEY") ?? "defaultkey",
                UseSocket = socket,
            };
            PolicePatrolSdk.Initialize(options, new NakamaFarsiClient(PolicePatrolSdk.CoreOptions(options)));
        }

        [IntegrationFact]
        public async Task GuideFlows()
        {
            foreach (var socket in new[] { true, false })
            {
                Start(socket);
                var device = "pp-sdk-it-" + Guid.NewGuid().ToString("N");
                Assert.False(AuthProvider.IsLoggedIn);
                var login = await Harness.Call<LoginResponse>(cb => AuthProvider.DeviceIdLogin(device, cb));
                Assert.True(login.IsSuccess, login.Error?.ToString());
                Assert.True(AuthProvider.IsLoggedIn);
                if (socket)
                {
                    await PolicePatrolSdk.Client.Core.Socket.ConnectAsync();
                    Assert.True(PolicePatrolSdk.Client.Core.Socket.IsConnected);
                }

                var me = await Harness.Call<CurrentUser>(ProfileProvider.GetMe);
                Assert.True(me.IsSuccess, me.Error?.ToString());
                Assert.True(me.Data.IsGuest);
                Assert.Equal(device, me.Data.DeviceId);

                var rules = await Harness.Call<AccountRules>(ProfileProvider.AccountRules);
                Assert.True(rules.IsSuccess, rules.Error?.ToString());

                var coin = await Harness.Call<UserCurrency>(cb => CurrencyProvider.GetByKey("coin", cb));
                Assert.True(coin.IsSuccess, coin.Error?.ToString());

                var inv = await Harness.Call<PlayerInventory>(InventoryProvider.Get);
                Assert.True(inv.IsSuccess, inv.Error?.ToString());
                _out.WriteLine("items: " + string.Join(", ", inv.Data.Items.Select(i => i.Key + (i.Owned ? "*" : string.Empty))));
                if (inv.Data.Items.Any(i => i.Key == "Tiggo8"))
                {
                    Assert.True(inv.Data.Items.Single(i => i.Key == "Tiggo8").Owned);
                    var buy = await Harness.Call<ItemChange>(cb => InventoryProvider.Buy("ToyotaHilux", cb));
                    Assert.False(buy.IsSuccess);
                    _out.WriteLine("buy ToyotaHilux: " + buy.Error.Code + " (" + buy.Error.ServerCode + ") " + buy.Error.Message);
                    Assert.StartsWith("INVENTORY_", buy.Error.Code);
                }

                var progress = await Harness.Call<PlayerProgress>(StageProvider.Get);
                Assert.True(progress.IsSuccess, progress.Error?.ToString());
                _out.WriteLine("chapters: " + string.Join(", ", progress.Data.Chapters.Select(c => c.Key + "(" + c.Stages.Length + ")")));

                var stats = await Harness.Call<PlayerStat[]>(StatsProvider.Mine);
                Assert.True(stats.IsSuccess, stats.Error?.ToString());
                var goals = await Harness.Call<PlayerGoal[]>(StatsProvider.Goals);
                Assert.True(goals.IsSuccess, goals.Error?.ToString());
                var report = await Harness.Call<StatsReport>(cb => StatsProvider.Report(new[] { new StatValue("distance_km", 0.5) }, cb));
                Assert.True(report.IsSuccess, report.Error?.ToString());

                var local = await Harness.Call<LocalStateReceived>(cb => FairPlayProvider.ReportLocalState(new[] { new LocalBalance("coin", 0) }, new[] { "Tiggo8" }, cb));
                Assert.True(local.IsSuccess, local.Error?.ToString());

                PolicePatrolAnalytics.SetContext("vehicle", "SantaFe");
                Assert.True(PolicePatrolAnalytics.AddDesignEvent("Vehicle:Distance:SUV:SantaFe", 1.2));
                Assert.True(await PolicePatrolSdk.Client.Core.Analytics.SendAllAsync());

                var logout = await Harness.Call<OkResponse>(cb => AuthProvider.Logout(cb));
                Assert.True(logout.IsSuccess);
                Assert.False(AuthProvider.IsLoggedIn);
            }
        }
    }
}
