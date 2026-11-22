using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Nakama;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Analytics;
using PolicePatrol.Sdk.Editor;
using PolicePatrol.Sdk.Inventory;
using PolicePatrol.Sdk.Stages;
using PolicePatrol.Sdk.Stats;
using Xunit;
using NF = NakamaFarsi.Sdk;

namespace PolicePatrol.Sdk.Tests
{
    public class ServerPayloadTests
    {
        private static string Fixture(string name) => File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Fixtures", name + ".json"));

        private static NF.RpcServerException ServerError(string name)
        {
            var body = Fixture(name);
            return new NF.RpcServerException(JObject.Parse(body).ToString(Formatting.None), (int)JObject.Parse(body)["status"]);
        }

        [Fact]
        public async Task ChaptersCarrySettingsRulesAndMilestoneIds()
        {
            var t = Harness.Start();
            t.Routes["campaign_chapters"] = p => Fixture("campaign_chapters");
            var r = await Harness.Call<PlayerProgress>(StageProvider.Get);
            Assert.True(r.IsSuccess, r.Error?.Code);
            var progress = r.Data;
            Assert.Equal(3, progress.MaxStars);
            Assert.NotNull(progress.ServerTime);

            var main = progress.Chapters.First(c => c.Key == "chapter-close-beta-01");
            Assert.Equal(ChapterKinds.Main, main.Kind);
            Assert.Equal("ChapterLocator_Sample", main.Settings.Locator);
            Assert.Equal(30, main.MaxStars);
            Assert.Equal(new[] { "1", "2", "3", "4", "5", "6" }, main.Milestones.Select(m => m.Id).ToArray());
            Assert.Equal(16.6667, main.Milestones[0].Percent);
            Assert.False(main.Milestones[0].Reached);
            Assert.Null(main.Milestones[0].PrizeKey);

            var s1 = main.Stages.First(s => s.Key == "chapter-close-beta-level-01");
            Assert.Equal("chapter-close-beta-01", s1.ChapterKey);
            Assert.Equal("M_BombingInPostEclectricity_V1", s1.UnityLevelId);
            Assert.Equal(StageContexts.Chapter, s1.Context);
            Assert.Equal(25, s1.MinSeconds);
            Assert.True(s1.NoReplayAfterWin);
            Assert.False(s1.Replayable);
            Assert.False(s1.CanStart);
            Assert.Equal(1, s1.Wins);
            Assert.Equal(25.8, s1.BestSeconds);
            Assert.Equal(900, s1.ClaimedXp);
            Assert.Equal(new[] { 0.2, 0.5, 1 }, s1.StarMultipliers);
            Assert.Empty(s1.RewardsLeft);
            Assert.False(string.IsNullOrEmpty(s1.Description));
            Assert.Null(s1.IconUrl);
            Assert.Equal("target", J.Str(s1.Metadata, "missionType"));

            var three = s1.StarRules.First(x => x.Stars == 3);
            Assert.Equal(new[] { StageFields.TimeSavedPercent, StageFields.HealthPercent, StageFields.TimesSeen }, three.Conditions.Select(c => c.Field).ToArray());
            Assert.True(three.Conditions[2].PassesWhenMissing);
            Assert.Equal("<=", three.Conditions[2].Op);

            Assert.Equal("base", s1.Settings.ResultRoute);
            Assert.True(s1.Settings.ShowRewardPanel);
            Assert.Equal("POITest_TriggerPoint", s1.Settings.StartPoint);
            Assert.False(string.IsNullOrEmpty(s1.Settings.Brief));
            var mission = s1.Settings.Missions.Single();
            Assert.Equal("ChCloseBeta_Lvl1", mission.Id);
            Assert.Equal("target", mission.Mode);
            Assert.Equal(180, mission.Timer);
            Assert.Equal(8, mission.ReachRadius);
            Assert.True(mission.ShowArrowGuidance);
            Assert.Equal("WeatherConfigCard_Mission_Spring-Noon-Clear", mission.Weather);
            Assert.Equal("Target_ChCloseBeta-Lvl1", mission.Targets.Single().SceneRef);
            Assert.True(mission.AcceptsCar("AudiQ2", "SUV"));

            var withEnemy = progress.Chapters.SelectMany(c => c.Stages).SelectMany(s => s.Settings.Missions).First(m => m.Enemies.Length > 0);
            Assert.True(withEnemy.Enemies[0].PathFollow);
            Assert.Equal(140, withEnemy.Enemies[0].SpeedMax);
            Assert.Equal("move", withEnemy.Enemies[0].StartMode);

            var poi = progress.PoiChapters("POI_Vilage_01").Single();
            Assert.True(poi.IsPoi);
            Assert.Equal("trigger", poi.Settings.StartMode);
            Assert.Equal(4, poi.Settings.TriggerRadius);
            Assert.Equal("sequential", poi.Settings.ProgressionMode);
            Assert.Equal("POI Card_Vilage_Sample", poi.Settings.PoiCard);

            var free = progress.FreeRideChapter;
            Assert.Equal(StageProvider.FreeRideChapterKey, free.Key);
            Assert.True(free.IsFreeRide);
            Assert.Equal(45, progress.FreeRideOffers.SecondsBeforeFirstOffer);
            Assert.Equal(12, progress.FreeRideOffers.SpawnAttempts);
            Assert.Equal(1.2, progress.FreeRideOffers.HostileShareMax);
            Assert.False(progress.FreeRideOffers.LogOffers);
            Assert.Null(main.FreeRideOffers);
            Assert.DoesNotContain(progress.Chapters, c => c.Key == StageProvider.FreeRideRewardsChapterKey);

            var ride = progress.FindByUnityLevel("M_DangerousChemicalC2", StageContexts.FreeRide);
            Assert.Equal("freeride-chapter-close-beta-level-02", ride.Key);
            Assert.Equal("freeride", ride.RewardGroup);
            Assert.Equal(300, ride.CooldownSeconds);
            Assert.True(ride.Replayable);
            Assert.Equal("chapter-close-beta-level-02", progress.FindByUnityLevel("M_DangerousChemicalC2", StageContexts.Chapter).Key);
        }

        [Fact]
        public async Task StartSendsTheVehicleAndReadsTheItem()
        {
            var t = Harness.Start();
            t.Routes["campaign_chapters"] = p => Fixture("campaign_chapters");
            t.Routes["economy_inventory"] = p => Fixture("economy_inventory.vehicle");
            t.Routes["campaign_attempt_start"] = p => Fixture("campaign_attempt_start.vehicle");
            await Harness.Call<PlayerInventory>(InventoryProvider.Get);
            var a = await Harness.Call<StageAttempt>(cb => StageProvider.Start("chapter-close-beta-level-01", "AudiQ2", cb));
            Assert.True(a.IsSuccess, a.Error?.Code);
            var sent = JObject.Parse(t.Calls.Last(c => c.Id == "campaign_attempt_start").Payload);
            Assert.Equal("audiq2", (string)sent["vehicleKey"]);
            Assert.Equal("audiq2", (string)sent["itemKey"]);
            Assert.Equal("AudiQ2", a.Data.Item.ItemKey);
            Assert.Equal("vehicle", a.Data.Item.ItemType);
            Assert.Equal(180, a.Data.TimeLimitSeconds);

            t.Routes["campaign_attempt_start"] = p => Fixture("campaign_attempt_start");
            var plain = await Harness.Call<StageAttempt>(cb => StageProvider.Start("chapter-close-beta-level-01", cb));
            Assert.Null(JObject.Parse(t.Calls.Last(c => c.Id == "campaign_attempt_start").Payload)["vehicleKey"]);
            Assert.Null(plain.Data.Item);
        }

        [Fact]
        public async Task StageErrorsGetTheProgressPrefix()
        {
            var t = Harness.Start();
            t.Routes["campaign_chapters"] = p => Fixture("campaign_chapters");
            t.Routes["campaign_attempt_start"] = p => ServerError("campaign_attempt_start.already_won.error");
            var won = await Harness.Call<StageAttempt>(cb => StageProvider.Start("chapter-close-beta-level-01", cb));
            Assert.Equal(StageErrorCodes.AlreadyWon, won.Error.Code);
            Assert.Equal("STAGE_ALREADY_WON", won.Error.ServerCode);

            t.Routes["campaign_attempt_start"] = p => ServerError("campaign_attempt_start.item_not_owned.error");
            var notOwned = await Harness.Call<StageAttempt>(cb => StageProvider.Start("chapter-close-beta-level-01", "SuzukiVitara", cb));
            Assert.Equal(StageErrorCodes.ItemNotOwned, notOwned.Error.Code);
            Assert.Equal("suzukivitara", (string)notOwned.Error.Meta["itemKey"]);

            foreach (var (server, mapped) in new[] { ("STAGE_ITEM_REQUIRED", StageErrorCodes.ItemRequired), ("STAGE_ITEM_NOT_ALLOWED", StageErrorCodes.ItemNotAllowed) })
            {
                t.Routes["campaign_attempt_start"] = p => new NF.RpcServerException("{\"code\":\"" + server + "\",\"status\":403,\"message\":\"x\",\"field\":\"vehicleKey\",\"lang\":\"en\"}", 403);
                var e = await Harness.Call<StageAttempt>(cb => StageProvider.Start("chapter-close-beta-level-01", "AudiQ2", cb));
                Assert.Equal(mapped, e.Error.Code);
                Assert.Equal(server, e.Error.ServerCode);
            }
        }

        [Fact]
        public async Task CompleteReadsCriteriaAndMilestoneIds()
        {
            var t = Harness.Start();
            t.Routes["campaign_attempt_complete"] = p => Fixture("campaign_attempt_complete");
            var r = await Harness.Call<StageResult>(cb => StageProvider.Complete("chapter-close-beta-level-01", "98faf3d6-bc68-489a-887a-937dcdc28244", true, 25.8, 81, cb));
            Assert.True(r.IsSuccess, r.Error?.Code);
            var res = r.Data;
            Assert.Equal(3, res.Stars);
            Assert.Equal(new[] { StageFields.TimeSavedPercent, StageFields.HealthPercent, StageFields.TimesSeen }, res.Criteria.Select(c => c.Field).ToArray());
            Assert.Equal(85.67, res.Criteria[0].Value);
            Assert.All(res.Criteria, c => Assert.Equal(3, c.Stars));
            Assert.Empty(res.MilestoneIds);
            Assert.Equal(85.67, res.TimeSavedPercent);
            Assert.Equal(25, res.MinSeconds);
            Assert.False(res.Replayable);
            Assert.Equal(0, res.PreviousBestStars);
            Assert.Equal("chapter-close-beta-01", res.ChapterKey);
            Assert.Equal(2, res.StarRules.Length);
            Assert.Equal(26.02, res.ServerSeconds);
            Assert.True(res.LeveledUp);
            Assert.Equal(2300, res.NextLevelXp);

            var withIds = JObject.Parse(Fixture("campaign_attempt_complete"));
            withIds["milestoneIds"] = new JArray("1", 2);
            withIds["criteria"][2]["value"] = null;
            t.Routes["campaign_attempt_complete"] = p => withIds.ToString();
            var again = await Harness.Call<StageResult>(cb => StageProvider.Complete("chapter-close-beta-level-01", "a", true, 30, 80, cb));
            Assert.Equal(new[] { "1", "2" }, again.Data.MilestoneIds);
            Assert.False(again.Data.Criteria[2].WasSent);
        }

        [Fact]
        public async Task StatsConfigHasThresholdsAndSplits()
        {
            var t = Harness.Start();
            t.Routes["analytics_config"] = p => Fixture("analytics_config");
            var r = await Harness.Call<StatsConfig>(StatsProvider.Config);
            Assert.True(r.IsSuccess, r.Error?.Code);
            Assert.Equal(3, r.Data.BigJumpHeight);
            Assert.Equal(20, r.Data.BigJumpLength);
            Assert.Equal(0.5, r.Data.MmOvertakeGap);
            Assert.Equal(1501, r.Data.NotificationCode);
            Assert.Equal(TrophyClaimModes.Auto, r.Data.ClaimMode);
            Assert.Equal(1501, StatsProvider.TrophyNotificationCode);
            var dist = r.Data.Stats.First(s => s.Key == "vehicle_distance_km");
            Assert.Equal(new[] { "vehicle", "vehicleClass" }, dist.SplitBy);
            Assert.Equal(StatPeriods.Total, dist.Period);
            Assert.Contains(r.Data.Stats, s => s.Period == StatPeriods.Day);
            Assert.Contains(r.Data.Events, e => e.Name == "jump");
            Assert.Contains(r.Data.Events.First(e => e.Name == "item_bought").Fields, f => f.Name == "itemKey" && f.Type == "string");
        }

        [Fact]
        public async Task StatsHaveTagsAndPeriods()
        {
            var t = Harness.Start();
            t.Routes["analytics_stats"] = p => Fixture("analytics_stats");
            var r = await Harness.Call<PlayerStat[]>(cb => StatsProvider.Mine(new[] { "vehicle_distance_km", "level_ups_day" }, cb));
            Assert.True(r.IsSuccess, r.Error?.Code);
            Assert.Contains("\"keys\":[\"vehicle_distance_km\",\"level_ups_day\"]", t.Calls.Last().Payload);
            var dist = r.Data.First(s => s.Key == "vehicle_distance_km");
            Assert.Equal(5, dist.Value);
            Assert.Equal(5, dist.Total);
            Assert.Equal(5, dist.Tag("vehicle=HyundaiSantafe").Current);
            Assert.Equal("SUV", dist.TagsOf("vehicleClass").Single().Label);
            Assert.Equal(5, dist.Tag("vehicle", "HyundaiSantafe").Total);
            var day = r.Data.First(s => s.Key == "level_ups_day");
            Assert.Equal(StatPeriods.Day, day.Period);
            Assert.Equal(2, day.Current);
            Assert.Equal(2, day.Value);

            var old = await Harness.Call<PlayerStat[]>(StatsProvider.Mine);
            Assert.DoesNotContain("keys", t.Calls.Last().Payload);
            Assert.Equal(old.Data.Length, r.Data.Length);
        }

        [Fact]
        public async Task TrophyPageAndClaim()
        {
            var t = Harness.Start();
            t.Routes["analytics_trophies"] = p => Fixture("analytics_trophies");
            var r = await Harness.Call<TrophyPage>(cb => StatsProvider.Trophies(TrophyGroups.Vehicle, cb));
            Assert.True(r.IsSuccess, r.Error?.Code);
            Assert.Contains("\"group\":\"vehicle\"", t.Calls.Last().Payload);
            var page = r.Data;
            Assert.Equal(6, page.Groups.Length);
            Assert.Equal(new TrophyTotals(220, 5, 1), page.Totals);
            Assert.Equal("sequential", page.UnlockOrder);
            var one = page.Find("distance_one_car");
            Assert.Equal(4, one.StepCount);
            Assert.Equal(1, one.Unlocked);
            Assert.Equal(0.1, one.Progress);
            Assert.Equal(2, one.NextStep.Step);
            Assert.NotNull(one.Steps[0].UnlockedAt);
            var cond = one.Steps[1].Conditions.Single();
            Assert.Equal("vehicle_distance_km", cond.Stat);
            Assert.Equal("vehicle", cond.TagKey);
            Assert.True(cond.IsAnyTag);
            Assert.Equal(50, cond.Target);
            Assert.Equal(5, cond.Current);
            Assert.False(cond.Met);
            Assert.True(one.Steps[1].Rewards.IsEmpty);

            var kills = page.Find("kills");
            Assert.True(kills.HasClaimable);
            Assert.True(kills.Steps[0].Claimable);
            Assert.Equal(TrophyClaimStatuses.Ready, kills.Steps[0].ClaimStatus);
            Assert.Equal(500, kills.Steps[0].Rewards.Currencies["coin"]);

            var goals = await Harness.Call<PlayerGoal[]>(StatsProvider.Goals);
            Assert.Contains(goals.Data, g => g.Key == "distance_one_car:1" && g.Completed);

            t.Routes["analytics_trophy_claim"] = p => Fixture("analytics_trophy_claim");
            var claim = await Harness.Call<TrophyClaim>(cb => StatsProvider.Claim("kills", 1, cb));
            Assert.Contains("\"trophy\":\"kills\"", t.Calls.Last().Payload);
            Assert.Contains("\"step\":1", t.Calls.Last().Payload);
            Assert.Equal(TrophyClaimStatuses.Granted, claim.Data.Status);
            Assert.Equal(500, claim.Data.Rewards.Currencies["coin"]);
            Assert.Equal("9abac33e-2124-4ab8-ab27-fc0385b7d555", claim.Data.StepId);

            t.Routes["analytics_trophy_claim"] = p => ServerError("analytics_trophy_claim.again.error");
            var again = await Harness.Call<TrophyClaim>(cb => StatsProvider.ClaimStep(kills.Steps[0].Id, cb));
            Assert.Contains("\"stepId\":\"9abac33e", t.Calls.Last().Payload);
            Assert.Equal(StatsErrorCodes.AlreadyClaimed, again.Error.Code);
        }

        [Fact]
        public async Task TrackReportKeepsTagRowsAndUnlocks()
        {
            var t = Harness.Start();
            t.Routes["analytics_track"] = p => Fixture("analytics_track");
            var r = await Harness.Call<StatsReport>(cb => StatsProvider.Report(new[] { new StatValue("kills", 12) }, "b-1", cb));
            Assert.True(r.IsSuccess, r.Error?.Code);
            Assert.Contains(r.Data.Stats, s => s.Key == "kills" && s.Tag == "gunClass=Handgun" && s.Current == 12);
            Assert.Contains(r.Data.Stats, s => s.Key == "kills" && s.Tag == null);
            Assert.Equal(r.Data.Unlocks.Length, r.Data.Trophies.Length);
            Assert.Contains(r.Data.Unlocks, u => u.TrophyKey == "kills" && u.Step == 1 && u.Claimable);
        }

        [Fact]
        public void NotificationBecomesATypedUnlock()
        {
            var list = JArray.Parse(Fixture("notifications.1501"));
            var kills = list.First(n => (string)n["content"]["trophyKey"] == "kills");
            var u = TrophyUnlock.FromNotification((int)kills["code"], (JObject)kills["content"]);
            Assert.Equal("kills", u.TrophyKey);
            Assert.Equal("gun", u.GroupKey);
            Assert.Equal(4, u.StepCount);
            Assert.True(u.Claimable);
            Assert.Equal(500, u.Rewards.Currencies["coin"]);
            Assert.Equal("Enemies destroyed · Bronze", u.Title);
            Assert.Null(TrophyUnlock.FromNotification(1501, new JObject { ["type"] = "other" }));
            Assert.Null(TrophyUnlock.FromNotification(7, new JObject()));
        }

        [Fact]
        public void TheSocketNotificationRaisesTrophyStepUnlocked()
        {
            Harness.Start();
            var list = JArray.Parse(Fixture("notifications.1501"));
            TrophyUnlock got = null;
            void On(TrophyUnlock u) => got = u;
            StatsProvider.TrophyStepUnlocked += On;
            try
            {
                var socket = PolicePatrolSdk.Client.Core.Socket;
                var field = socket.GetType().GetField("NotificationReceived", BindingFlags.Instance | BindingFlags.NonPublic);
                var raise = (Action<IApiNotification>)field.GetValue(socket);
                var first = list[0];
                raise(new FakeNotification((int)first["code"], first["content"].ToString(Formatting.None)));
                Assert.Equal("distance_one_car", got?.TrophyKey);
                got = null;
                raise(new FakeNotification(9, "{\"type\":\"gift\"}"));
                Assert.Null(got);
            }
            finally
            {
                StatsProvider.TrophyStepUnlocked -= On;
            }
        }

        [Fact]
        public async Task DesignEventHelpersCarryTheContext()
        {
            var t = Harness.Start();
            string sent = null;
            t.Routes["analytics_track"] = p =>
            {
                sent = p;
                return "{\"batchId\":\"x\",\"stats\":[],\"unlocked\":[]}";
            };
            PolicePatrolEvents.SetVehicle("HyundaiSantafe", "SUV");
            PolicePatrolEvents.SetGun("gun-handgun-mp5", "Handgun");
            PolicePatrolEvents.SetMission(PolicePatrolEvents.StoryMode, "chapter-close-beta-level-01");
            Assert.True(PolicePatrolEvents.Distance(1.25));
            Assert.True(PolicePatrolEvents.Kill(2));
            Assert.True(PolicePatrolEvents.RanOut(RanOutKind.Fuel));
            Assert.True(PolicePatrolEvents.Jump(3.4, 22, 1.2));
            Assert.True(PolicePatrolEvents.Overtake(0.35, true, 182));
            Assert.False(PolicePatrolEvents.Drift(0));
            Assert.True(await PolicePatrolAnalytics.Client.SendAllAsync());
            var body = JObject.Parse(sent);
            Assert.Equal("HyundaiSantafe", (string)body["context"]["vehicle"]);
            Assert.Equal("Handgun", (string)body["context"]["gunClass"]);
            Assert.Equal("story", (string)body["context"]["mode"]);
            var events = (JArray)body["events"];
            Assert.Contains(events, e => (string)e["id"] == "Vehicle:Distance" && (double)e["value"] == 1.25);
            Assert.Contains(events, e => (string)e["id"] == "Vehicle:RanOut:Fuel");
            Assert.Contains(events, e => (string)e["name"] == "jump" && (double)e["fields"]["height"] == 3.4);
            Assert.Contains(events, e => (string)e["name"] == "overtake" && (bool)e["fields"]["topSpeed"]);
            PolicePatrolEvents.ClearMission();
            PolicePatrolAnalytics.ClearContext();
        }

        [Fact]
        public async Task InventoryWithProfileHasCarsPartsSlotsAndStats()
        {
            var t = Harness.Start();
            t.Routes["economy_inventory"] = p => JObject.Parse(p)["type"]?.ToString() == "part" ? Fixture("economy_inventory.part.profile") : Fixture("economy_inventory.vehicle.profile");
            var r = await Harness.Call<PlayerInventory>(cb => InventoryProvider.Get(ItemTypes.Vehicle, true, cb));
            Assert.True(r.IsSuccess, r.Error?.Code);
            var sent = JObject.Parse(t.Calls.Last().Payload);
            Assert.True((bool)sent["withProfile"]);
            Assert.Equal("vehicle", (string)sent["type"]);
            var inv = r.Data;
            Assert.Equal(2, inv.OwnedCount);
            Assert.Equal(6, inv.TotalCount);
            Assert.Equal("Tiggo8", inv.Equipped["vehicle"]);
            Assert.True(inv.Equipped.ContainsKey("part:audiq2:colorring"));
            var car = inv.Find("AudiQ2");
            Assert.True(car.IsCar);
            Assert.Equal("SUV", car.CarProfile.CarClass);
            Assert.Equal("AudiQ2", car.CarProfile.GameId);
            Assert.Equal(180, car.CarProfile.Performance.MaxSpeedKmh);
            Assert.Equal(7000, car.CarProfile.Performance.EngineMaxRpm);
            Assert.Equal(50, car.CarProfile.UnlockGem);
            Assert.Equal(300000, car.CarProfile.Services["brake"].Coin);
            Assert.Equal(1.2, car.CarProfile.GarageMultiplier);
            Assert.Equal(16, car.CarProfile.Slots.Length);
            var body = car.CarProfile.Slot("colorbody");
            Assert.Equal("Customization", body.Group);
            Assert.Equal("Single", body.Selection);
            Assert.Contains(body.Default, body.Parts);
            Assert.Equal(181.1, car.Stat("speed").Total);
            Assert.Equal(1.1, car.Stats["speed"].Bonus);
            Assert.Equal("00431a06-c547-4d17-b8ee-cddba08f9ec0", car.Installed["colorring"]);
            Assert.Equal("آئودی کیو 2", car.Name);
            Assert.Null(car.PartProfile);
            Assert.NotNull(car.Profile);

            var parts = await Harness.Call<PlayerInventory>(cb => InventoryProvider.Get(ItemTypes.Part, true, cb));
            var part = parts.Data.Items.First(i => i.Key == "00431a06-c547-4d17-b8ee-cddba08f9ec0");
            Assert.True(part.IsPart);
            Assert.Equal("AudiQ2", part.ParentKey);
            Assert.Equal("AudiQ2", part.PartProfile.CarKey);
            Assert.Equal("colorring", part.PartProfile.Slot);
            Assert.Equal("part:audiq2:colorring", part.PartProfile.EquipSlot);
            Assert.Equal(1, part.PartProfile.Level);
            Assert.True(part.PartProfile.Sellable);
            Assert.Equal("878787", part.PartProfile.ConstParameters["Color"]);
            Assert.Contains("Customization", part.PartProfile.Tags);
            var upgrade = parts.Data.Items.First(i => i.PartProfile?.Parameters.Count > 0);
            Assert.NotNull(upgrade.PartProfile.Parameter(upgrade.PartProfile.Parameters.Keys.First()));
            Assert.Equal(25000, part.FinalPrices[0].Amount);

            var plain = await Harness.Call<PlayerInventory>(InventoryProvider.Get);
            Assert.Null(JObject.Parse(t.Calls.Last().Payload)["withProfile"]);
        }

        [Fact]
        public async Task EquipAndPartErrors()
        {
            var t = Harness.Start();
            t.Routes["economy_inventory"] = p => Fixture("economy_inventory.vehicle.profile");
            await Harness.Call<PlayerInventory>(cb => InventoryProvider.Get(ItemTypes.Vehicle, true, cb));
            t.Routes["economy_item_equip"] = p => Fixture("economy_item_equip");
            var eq = await Harness.Call<EquipChange>(cb => InventoryProvider.Equip("00431a06-c547-4d17-b8ee-cddba08f9ec0", cb));
            Assert.True(eq.IsSuccess, eq.Error?.Code);
            Assert.Equal("economy_item_equip", t.Calls.Last().Id);
            Assert.Equal("part:audiq2:colorring", eq.Data.Slot);
            Assert.True(eq.Data.Item.Equipped);
            Assert.Empty(eq.Data.Unequipped);

            var swapped = JObject.Parse(Fixture("economy_item_equip"));
            swapped["unequipped"] = new JArray("tiggo8");
            t.Routes["economy_item_equip"] = p => swapped.ToString();
            var swap = await Harness.Call<EquipChange>(cb => InventoryProvider.Equip("AudiQ2", cb));
            Assert.Contains("\"key\":\"audiq2\"", t.Calls.Last().Payload);
            Assert.Equal(new[] { "Tiggo8" }, swap.Data.Unequipped);

            t.Routes["economy_item_unequip"] = p => ServerError("economy_item_unequip.not_owned.error");
            var un = await Harness.Call<EquipChange>(cb => InventoryProvider.Unequip("AudiQ2", cb));
            Assert.Equal(InventoryErrorCodes.NotOwned, un.Error.Code);

            t.Routes["economy_item_buy"] = p => ServerError("economy_item_buy.requires_item.error");
            var buy = await Harness.Call<ItemChange>(cb => InventoryProvider.Buy("00431a06-c547-4d17-b8ee-cddba08f9ec0", cb, "r-1"));
            Assert.Equal(InventoryErrorCodes.RequiresItem, buy.Error.Code);
            t.Routes["economy_item_buy"] = p => ServerError("economy_item_buy.not_for_sale.error");
            var free = await Harness.Call<ItemChange>(cb => InventoryProvider.Buy("1009478e-9d7c-4691-92c0-940f818e18f6", cb, "r-2"));
            Assert.Equal(InventoryErrorCodes.NotForSale, free.Error.Code);
            t.Routes["economy_item_buy"] = p => new NF.RpcServerException("{\"code\":\"PART_VEHICLE_NOT_OWNED\",\"status\":409,\"message\":\"buy the car audiq2 first\",\"meta\":{\"vehicleKey\":\"audiq2\"},\"lang\":\"en\"}", 409);
            var car = await Harness.Call<ItemChange>(cb => InventoryProvider.Buy("00431a06-c547-4d17-b8ee-cddba08f9ec0", cb, "r-3"));
            Assert.Equal(InventoryErrorCodes.PartVehicleNotOwned, car.Error.Code);
            Assert.Equal("audiq2", (string)car.Error.Meta["vehicleKey"]);
        }

        [Fact]
        public void PushAnswerHasTheRouting()
        {
            var result = JsonConvert.DeserializeObject<AssetSyncResult>(Fixture("assets_push.dry_run"), SdkJson.Settings);
            Assert.True(result.DryRun);
            Assert.Equal(1, result.Updated);
            Assert.Equal(3, result.Unchanged);
            Assert.True(result.Routing.Enabled);
            Assert.Equal(1, result.Routing.Count(AssetRoutingActions.Updated));
            var row = result.Routing.Rows.Single();
            Assert.Equal("car", row.Kind);
            Assert.Equal("audiq2", row.ItemKey);
            Assert.Equal("profile.unlockGem", row.Changes.Single().Field);
            Assert.Equal(51, (int)row.Changes.Single().After);

            var merged = AssetRouting.Merge(new[]
            {
                result.Routing,
                new AssetRouting { Enabled = true, DryRun = true, Summary = new System.Collections.Generic.Dictionary<string, int> { ["pending"] = 1, ["updated"] = 2 },
                    Rows = new[] { new AssetRoutingRow { AssetId = "AudiQ2_ColorBody_DecalSport1-Yellow", Kind = "part", Action = AssetRoutingActions.Pending, Reason = "no VehicleCard lists it" } } },
                null,
            });
            Assert.Equal(3, merged.Count(AssetRoutingActions.Updated));
            Assert.Single(merged.Pending);
            Assert.Equal("Routing (dry run): 1 pending, 3 updated.", merged.Describe());
            Assert.Null(AssetRouting.Merge(new AssetRouting[] { null }));

            var off = JsonConvert.DeserializeObject<AssetSyncResult>("{\"created\":1,\"updated\":0,\"unchanged\":0,\"deleted\":0,\"items\":[]}", SdkJson.Settings);
            Assert.Null(off.Routing);
        }

        private sealed class FakeNotification : IApiNotification
        {
            public FakeNotification(int code, string content)
            {
                Code = code;
                Content = content;
            }

            public int Code { get; }

            public string Content { get; }

            public string CreateTime => "2026-11-22T05:07:43Z";

            public string Id => Guid.NewGuid().ToString();

            public bool Persistent => true;

            public string SenderId => string.Empty;

            public string Subject => "trophy";
        }
    }
}
