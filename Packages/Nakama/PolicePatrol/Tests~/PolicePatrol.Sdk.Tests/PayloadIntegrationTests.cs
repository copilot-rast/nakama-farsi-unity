using System;
using System.Linq;
using System.Threading.Tasks;
using NakamaFarsi.Sdk;
using PolicePatrol.Sdk.Analytics;
using PolicePatrol.Sdk.Auth;
using PolicePatrol.Sdk.Inventory;
using PolicePatrol.Sdk.Stages;
using PolicePatrol.Sdk.Stats;
using Xunit;

namespace PolicePatrol.Sdk.Tests
{
    public class PayloadIntegrationTests : IDisposable
    {
        public void Dispose()
        {
            PolicePatrolAnalytics.ClearContext();
            PolicePatrolSdk.Shutdown();
        }

        private static async Task SignIn(bool socket)
        {
            PolicePatrolSdk.Shutdown();
            var device = "payload-" + Guid.NewGuid().ToString("N");
            var options = new SdkOptions(Environment.GetEnvironmentVariable("NF_IT_URL"), "it", false, 15, "fa")
            {
                ServerKey = Environment.GetEnvironmentVariable("NF_IT_KEY") ?? "defaultkey",
                UseSocket = socket,
                DeviceId = device,
            };
            PolicePatrolSdk.Initialize(options, new NakamaFarsiClient(PolicePatrolSdk.CoreOptions(options)));
            var login = await Harness.Call<LoginResponse>(cb => AuthProvider.DeviceIdLogin(device, cb));
            Assert.True(login.IsSuccess, login.Error?.Code);
        }

        private static Task<ApiResult<T>> Long<T>(Action<Action<ApiResult<T>>> call)
        {
            var tcs = new TaskCompletionSource<ApiResult<T>>(TaskCreationOptions.RunContinuationsAsynchronously);
            call(r => tcs.TrySetResult(r));
            return tcs.Task.WaitAsync(TimeSpan.FromSeconds(60));
        }

        [IntegrationFact]
        public async Task StagesStatsTrophiesAndCarsOnTheServer()
        {
            await SignIn(true);
            await PolicePatrolSdk.Client.Core.Socket.ConnectAsync();

            var config = await Harness.Call<StatsConfig>(StatsProvider.Config);
            Assert.True(config.IsSuccess, config.Error?.Code);
            Assert.True(config.Data.Thresholds.Count >= 3);
            Assert.Contains(config.Data.Stats, s => s.Key == "vehicle_distance_km" && s.SplitBy.Contains("vehicle"));

            var progress = await Harness.Call<PlayerProgress>(StageProvider.Get);
            Assert.True(progress.IsSuccess, progress.Error?.Code);
            var stage = progress.Data.FindStage("chapter-close-beta-level-01");
            Assert.Equal("M_BombingInPostEclectricity_V1", stage.UnityLevelId);
            Assert.NotEmpty(stage.StarRules);
            Assert.NotEmpty(stage.Settings.Missions);
            Assert.True(stage.MinSeconds > 0);
            Assert.All(progress.Data.Chapters.First(c => c.Key == "chapter-close-beta-01").Milestones, m => Assert.False(string.IsNullOrEmpty(m.Id)));
            Assert.True(progress.Data.FreeRideOffers.SecondsBetweenOffers > 0);
            Assert.NotEmpty(progress.Data.PoiChapters());

            TrophyUnlock pushed = null;
            void On(TrophyUnlock u) => pushed = pushed ?? u;
            StatsProvider.TrophyStepUnlocked += On;
            try
            {
                PolicePatrolEvents.SetVehicle("HyundaiSantafe", "SUV");
                PolicePatrolEvents.SetGun("gun-handgun-mp5", "Handgun");
                PolicePatrolEvents.SetMission(PolicePatrolEvents.FreeRideMode);
                Assert.True(PolicePatrolEvents.Distance(5));
                Assert.True(PolicePatrolEvents.Kill(12));
                Assert.True(PolicePatrolEvents.Jump(3.4, 22, 1.2));
                Assert.True(PolicePatrolEvents.Overtake(0.3, true, 182));
                Assert.True(await PolicePatrolAnalytics.Client.SendAllAsync());
                for (var i = 0; i < 50 && pushed == null; i++)
                {
                    await Task.Delay(100);
                }

                Assert.NotNull(pushed);
                Assert.Equal(4, pushed.StepCount);
            }
            finally
            {
                StatsProvider.TrophyStepUnlocked -= On;
            }

            var stats = await Harness.Call<PlayerStat[]>(cb => StatsProvider.Mine(new[] { "vehicle_distance_km", "kills", "jumps" }, cb));
            Assert.True(stats.IsSuccess, stats.Error?.Code);
            Assert.Equal(5, stats.Data.First(s => s.Key == "vehicle_distance_km").Tag("vehicle=HyundaiSantafe").Value);
            Assert.Equal(12, stats.Data.First(s => s.Key == "kills").Tag("gunClass", "Handgun").Value);

            var page = await Harness.Call<TrophyPage>(cb => StatsProvider.Trophies(TrophyGroups.Vehicle, cb));
            Assert.True(page.IsSuccess, page.Error?.Code);
            var one = page.Data.Find("distance_one_car");
            Assert.True(one.Steps[0].Unlocked);
            Assert.Equal(0.1, one.Progress, 3);
            Assert.True(one.Steps[1].Conditions[0].IsAnyTag);

            var gun = await Harness.Call<TrophyPage>(cb => StatsProvider.Trophies(TrophyGroups.Gun, cb));
            var claimable = gun.Data.Groups.SelectMany(g => g.Trophies).SelectMany(t => t.Steps.Select(s => (t, s))).FirstOrDefault(x => x.s.Claimable);
            if (claimable.s != null)
            {
                var claim = await Harness.Call<TrophyClaim>(cb => StatsProvider.Claim(claimable.t.Key, claimable.s.Step, cb));
                Assert.True(claim.IsSuccess, claim.Error?.Code);
                Assert.Equal(TrophyClaimStatuses.Granted, claim.Data.Status);
                var twice = await Harness.Call<TrophyClaim>(cb => StatsProvider.ClaimStep(claim.Data.StepId, cb));
                Assert.Equal(StatsErrorCodes.AlreadyClaimed, twice.Error.Code);
            }

            var cars = await Harness.Call<PlayerInventory>(cb => InventoryProvider.Get(ItemTypes.Vehicle, true, cb));
            Assert.True(cars.IsSuccess, cars.Error?.Code);
            var audi = cars.Data.Find("AudiQ2");
            Assert.True(audi.IsCar);
            Assert.Equal("SUV", audi.CarProfile.CarClass);
            Assert.NotEmpty(audi.CarProfile.Slots);
            Assert.True(audi.Stat("speed").Total >= audi.CarProfile.Performance.MaxSpeedKmh);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var parts = await Long<PlayerInventory>(cb => InventoryProvider.Get(ItemTypes.Part, true, cb));
            Assert.True(parts.IsSuccess, parts.Error?.Code);
            Assert.True(watch.Elapsed < TimeSpan.FromSeconds(5), "the part list over the socket took " + watch.Elapsed);
            var part = parts.Data.Items.First(i => i.IsPart && i.ParentKey == "AudiQ2");
            Assert.Equal("AudiQ2", part.PartProfile.CarKey);
            var equip = await Harness.Call<EquipChange>(cb => InventoryProvider.Equip(part.Key, cb));
            Assert.Equal(InventoryErrorCodes.NotOwned, equip.Error.Code);

            var tiggo = cars.Data.Items.First(i => i.Owned && i.Type == ItemTypes.Vehicle);
            var attempt = await Harness.Call<StageAttempt>(cb => StageProvider.Start(stage.Key, tiggo.Key, cb));
            Assert.True(attempt.IsSuccess, attempt.Error?.Code);
            await Task.Delay(TimeSpan.FromSeconds((stage.MinSeconds ?? 0) + 1));
            var result = await Harness.Call<StageResult>(cb => StageProvider.Complete(stage.Key, attempt.Data.AttemptId, true, (stage.MinSeconds ?? 0) + 0.5, 81,
                new System.Collections.Generic.Dictionary<string, object> { [StageFields.TimesSeen] = 0, [StageFields.Vehicle] = tiggo.Key }, cb));
            Assert.True(result.IsSuccess, result.Error?.Code);
            Assert.Equal(3, result.Data.Criteria.Length);
            Assert.Contains(result.Data.Criteria, c => c.Field == StageFields.HealthPercent && c.Value == 81);
            Assert.True(result.Data.TimeSavedPercent > 0);
            Assert.NotNull(result.Data.Replayable);
            Assert.NotEmpty(result.Data.StarRules);
        }
    }
}
