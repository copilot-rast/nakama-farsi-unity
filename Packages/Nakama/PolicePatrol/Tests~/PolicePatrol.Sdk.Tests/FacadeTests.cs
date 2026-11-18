using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Auth;
using PolicePatrol.Sdk.Economy;
using PolicePatrol.Sdk.Inventory;
using PolicePatrol.Sdk.Stages;
using PolicePatrol.Sdk.Stats;
using PolicePatrol.Sdk.Users;
using NF = NakamaFarsi.Sdk;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace PolicePatrol.Sdk.Tests
{
    public class FacadeTests
    {
        private const string Inventory = "{\"level\":2,\"items\":[" +
            "{\"key\":\"tiggo8\",\"type\":\"vehicle\",\"name\":\"Tiggo 8\",\"isStarter\":true,\"owned\":true,\"locked\":false,\"canBuy\":false,\"sort\":1,\"metadata\":{\"gameId\":\"Tiggo8\"},\"services\":[{\"key\":\"fuel\",\"name\":\"Fuel\",\"currencyKey\":\"coin\",\"unitPrice\":10,\"maxUnits\":100}]}," +
            "{\"key\":\"toyotahilux\",\"type\":\"vehicle\",\"name\":\"Hilux\",\"owned\":false,\"locked\":true,\"canBuy\":false,\"unlockLevel\":3,\"price\":{\"currencyKey\":\"coin\",\"amount\":1950000},\"unlockPrices\":[{\"currencyKey\":\"gem\",\"amount\":40}],\"metadata\":{\"gameId\":\"ToyotaHilux\"}}," +
            "{\"key\":\"gun-handgun-bereta92\",\"type\":\"gun\",\"name\":\"Beretta\",\"owned\":true,\"tracks\":[{\"key\":\"Power\",\"name\":\"Power\",\"level\":1,\"maxLevel\":2,\"nextPrice\":{\"currencyKey\":\"coin\",\"amount\":1000}}],\"metadata\":{\"gameId\":\"gun-handgun-bereta92\"}}]}";

        [Fact]
        public async Task NotInitialized()
        {
            PolicePatrolSdk.Shutdown();
            var r = await Harness.Call<CurrentUser>(ProfileProvider.GetMe);
            Assert.Equal(ApiError.NotInitializedCode, r.Error.Code);
        }

        [Fact]
        public async Task InventoryKeepsUnityIds()
        {
            var t = Harness.Start();
            t.Routes["economy_item_buy"] = p => "{\"item\":{\"key\":\"toyotahilux\",\"owned\":true,\"metadata\":{\"gameId\":\"ToyotaHilux\"}},\"paid\":[{\"currencyKey\":\"coin\",\"amount\":1950000}]}";
            var early = await Harness.Call<ItemChange>(cb => InventoryProvider.Buy("ToyotaHilux", cb));
            Assert.True(early.IsSuccess);
            Assert.Contains("\"key\":\"toyotahilux\"", t.Calls.Last().Payload);
            Assert.Equal("ToyotaHilux", early.Data.Item.Key);
            Assert.Equal(1950000, early.Data.Paid[0].Amount);

            t.Routes["economy_inventory"] = p => Inventory;
            var inv = await Harness.Call<PlayerInventory>(InventoryProvider.Get);
            Assert.Equal(2, inv.Data.Level);
            var tiggo = inv.Data.Items.Single(i => i.Key == "Tiggo8");
            Assert.True(tiggo.Owned);
            Assert.Equal("fuel", tiggo.Services[0].Key);
            var hilux = inv.Data.Items.Single(i => i.Key == "ToyotaHilux");
            Assert.False(hilux.Unlocked);
            Assert.Equal(3, hilux.UnlockLevel);
            Assert.Equal("gem", hilux.UnlockPrices[0].CurrencyId);
            Assert.Equal(1950000, hilux.Prices[0].Amount);
            var gun = inv.Data.Items.Single(i => i.Type == "gun");
            Assert.Equal("Power", gun.Upgrades[0].Key);
            Assert.Equal(1000, gun.Upgrades[0].NextPrice.Amount);

            t.Routes["economy_item_use"] = p => "{\"service\":\"fuel\",\"units\":5,\"paid\":[{\"currencyKey\":\"coin\",\"amount\":50}]}";
            var svc = await Harness.Call<ServiceResult>(cb => InventoryProvider.Service("Tiggo8", "fuel", 5, "r-1", cb));
            Assert.Contains("\"key\":\"tiggo8\"", t.Calls.Last().Payload);
            Assert.Contains("\"requestId\":\"r-1\"", t.Calls.Last().Payload);
            Assert.Equal("Tiggo8", svc.Data.ItemKey);
        }

        [Fact]
        public async Task ErrorsKeepTheirOldCodes()
        {
            var t = Harness.Start();
            t.Routes["economy_item_buy"] = p => new NF.RpcServerException("{\"code\":\"INSUFFICIENT_BALANCE\",\"status\":402,\"message\":\"سکه کافی نیست\",\"meta\":{\"currency\":\"coin\"}}", 402);
            var r = await Harness.Call<ItemChange>(cb => InventoryProvider.Buy("Tiggo8", cb));
            Assert.Equal(InventoryErrorCodes.NotEnough, r.Error.Code);
            Assert.Equal("INSUFFICIENT_BALANCE", r.Error.ServerCode);
            Assert.Equal("سکه کافی نیست", r.Error.Message);
            Assert.Equal(402, r.Error.Status);

            t.Routes["account_phone_request"] = p => new NF.RpcServerException("{\"code\":\"PHONE_CHECK_RATE_LIMITED\",\"status\":429,\"message\":\"صبر کنید\",\"retryAfterSeconds\":40}", 429);
            var phone = await Harness.Call<OtpChallenge>(cb => AuthProvider.RequestPhoneChange("09120000000", cb));
            Assert.Equal(ApiError.TooManyRequestsCode, phone.Error.Code);
            Assert.Equal(40, phone.Error.RetryAfterSeconds);

            t.Routes["account_phone_verify"] = p => new NF.RpcServerException("{\"code\":\"OTP_INVALID_CODE\",\"status\":400,\"message\":\"کد اشتباه است\"}", 400);
            var verify = await Harness.Call<CurrentUser>(cb => AuthProvider.VerifyPhoneChange("12345", cb));
            Assert.Equal("AUTH_INVALID_CODE", verify.Error.Code);

            var add = await Harness.Call<UserCurrency>(cb => CurrencyProvider.Add("coin", 10, cb));
            Assert.Equal(CurrencyProvider.ServerOnlyCode, add.Error.Code);

            var network = Harness.Start();
            network.Routes["economy_balances"] = p => new NF.RpcTransportException("reset", true);
            var down = await Harness.Call<UserCurrency>(cb => CurrencyProvider.GetByKey("coin", cb));
            Assert.True(down.Error.IsNetworkError);
        }

        [Fact]
        public async Task ProfileAndBalances()
        {
            var t = Harness.Start();
            t.Routes["account_me"] = p => "{\"id\":\"u-1\",\"username\":\"vEJVhZbffZ\",\"isGuest\":true,\"phone\":\"\",\"phoneVerified\":false,\"deviceId\":\"dev-1\",\"lang\":\"fa\",\"createdAt\":\"2026-11-15T08:29:30Z\"}";
            var me = await Harness.Call<CurrentUser>(ProfileProvider.GetMe);
            Assert.True(me.Data.IsGuest);
            Assert.False(me.Data.HasUsername);
            Assert.False(me.Data.PhoneNumberVerified);
            Assert.Equal("dev-1", me.Data.DeviceId);

            t.Routes["economy_balances"] = p => "{\"wallet\":{\"coin\":120,\"gem\":3},\"items\":[],\"metas\":{\"xp\":900,\"level\":2}}";
            var coin = await Harness.Call<UserCurrency>(cb => CurrencyProvider.GetByKey("coin", cb));
            Assert.Equal(120, coin.Data.Value);
            Assert.Equal("coin", coin.Data.Currency.Key);
            var metas = await Harness.Call<PagedResult<UserMeta>>(cb => MetaProvider.List(1, 100, cb));
            Assert.Equal(900, metas.Data.Items.Single(m => m.Meta.Key == "xp").Value);

            t.Routes["account_rules"] = p => "{\"usernameMin\":3,\"usernameMax\":20,\"passwordMin\":7,\"passwordMax\":30}";
            var rules = await Harness.Call<AccountRules>(ProfileProvider.AccountRules);
            Assert.Equal(30, rules.Data.PasswordMaxLength);
        }

        [Fact]
        public async Task StagesAndFreeRide()
        {
            var t = Harness.Start();
            t.Routes["campaign_chapters"] = p => "{\"xp\":900,\"level\":2,\"chapters\":[{\"key\":\"chapter-close-beta-01\",\"name\":\"C1\",\"unlocked\":true,\"starPercent\":0.5,\"milestones\":[{\"percent\":50,\"claimed\":false,\"rewards\":[{\"currencyKey\":\"gem\",\"amount\":5}]}],\"stages\":[{\"key\":\"s1\",\"name\":\"Stage 1\",\"unlocked\":true,\"bestStars\":2,\"rewards\":[{\"currencyKey\":\"coin\",\"amount\":100}],\"xp\":50,\"timeLimitSeconds\":120}]}],\"freeride\":[{\"key\":\"freeride-chapter-close-beta-level-02\",\"name\":\"Free 2\",\"rewards\":[{\"currencyKey\":\"coin\",\"amount\":1}],\"cooldownSeconds\":600,\"dailyRewardLimit\":5}]}";
            var progress = await Harness.Call<PlayerProgress>(StageProvider.Get);
            Assert.Equal(900, progress.Data.Xp);
            Assert.Equal(2, progress.Data.Chapters.Length);
            Assert.Equal(100, progress.Data.Chapters[0].Stages[0].Rewards[0].Amount);
            Assert.Equal(StageProvider.FreeRideChapterKey, progress.Data.Chapters[1].Key);

            var attempt = await Harness.Call<StageAttempt>(cb => StageProvider.Start("freeride-chapter-close-beta-level-02", cb));
            Assert.StartsWith("freeride:", attempt.Data.AttemptId);
            t.Routes["campaign_freeride_claim"] = p => "{\"key\":\"freeride-chapter-close-beta-level-02\",\"rewards\":[{\"currencyKey\":\"coin\",\"amount\":1}],\"xpGained\":3,\"xp\":903,\"level\":2}";
            var free = await Harness.Call<StageResult>(cb => StageProvider.Complete("freeride-chapter-close-beta-level-02", attempt.Data.AttemptId, true, 60, null, cb));
            Assert.Equal(3, free.Data.XpGained);
            Assert.Equal("campaign_freeride_claim", t.Calls.Last().Id);

            t.Routes["campaign_attempt_start"] = p => "{\"attemptId\":\"a-1\",\"stageKey\":\"s1\",\"startedAt\":\"2026-11-15T10:00:00Z\",\"expiresAt\":\"2026-11-16T10:00:00Z\"}";
            t.Routes["campaign_attempt_complete"] = p => "{\"stageKey\":\"s1\",\"success\":true,\"stars\":3,\"bestStars\":3,\"rewards\":[{\"currencyKey\":\"coin\",\"amount\":100}],\"xpGained\":50,\"xp\":950,\"level\":3,\"levels\":[{\"from\":2,\"to\":3}],\"trophies\":[{\"trophyKey\":\"driver\",\"trophyName\":\"Driver\",\"stepName\":\"Bronze\",\"stepCount\":3}]}";
            var a = await Harness.Call<StageAttempt>(cb => StageProvider.Start("s1", cb));
            var done = await Harness.Call<StageResult>(cb => StageProvider.Complete("s1", a.Data.AttemptId, true, 74.2, 81, new System.Collections.Generic.Dictionary<string, object> { ["car"] = "bugatti" }, cb));
            Assert.True(done.Data.LeveledUp);
            Assert.Equal(3, done.Data.Stars);
            Assert.Equal("driver", done.Data.Trophies[0].GoalKey);
            Assert.Contains("\"car\":\"bugatti\"", t.Calls.Last().Payload);

            t.Routes["campaign_attempt_complete"] = p => new NF.RpcServerException("{\"code\":\"STAGE_FINISHED_TOO_FAST\",\"status\":400}", 400);
            var fast = await Harness.Call<StageResult>(cb => StageProvider.Complete("s1", "a-1", true, 1, null, cb));
            Assert.Equal(StageErrorCodes.TooFast, fast.Error.Code);
        }

        [Fact]
        public async Task StatsBecomeDesignEvents()
        {
            var t = Harness.Start();
            PolicePatrol.Sdk.Analytics.PolicePatrolAnalytics.SetContext("vehicle", "SantaFe");
            t.Routes["analytics_track"] = p => "{\"batchId\":\"r1\",\"stats\":[{\"key\":\"distance_km\",\"sent\":1.5,\"accepted\":1.5,\"value\":10,\"status\":\"accepted\"}],\"unlocked\":[{\"trophyKey\":\"km10\",\"trophyName\":\"10 km\",\"stepCount\":1}]}";
            var r = await Harness.Call<StatsReport>(cb => StatsProvider.Report(new[] { new StatValue("distance_km", 1.5), new StatValue("ghost", 1) }, "r1", cb));
            var sent = JObject.Parse(t.Calls.Last().Payload);
            Assert.Equal("r1", (string)sent["batchId"]);
            Assert.Equal("design", (string)sent["events"][0]["type"]);
            Assert.Equal("distance_km", (string)sent["events"][0]["id"]);
            Assert.Equal("SantaFe", (string)sent["context"]["vehicle"]);
            Assert.Equal(StatReportStatuses.Unknown, r.Data.Stats.Single(s => s.Key == "ghost").Status);
            Assert.Equal("km10", r.Data.Trophies[0].GoalKey);

            t.Routes["analytics_trophies"] = p => "{\"groups\":[{\"key\":\"\",\"trophies\":[{\"key\":\"driver\",\"name\":\"Driver\",\"contextKey\":\"stage_3\",\"steps\":[{\"step\":1,\"name\":\"Bronze\",\"unlocked\":true,\"conditions\":[{\"stat\":\"distance_km\",\"op\":\">=\",\"value\":10,\"current\":10,\"met\":true}]},{\"step\":2,\"name\":\"Silver\",\"unlocked\":false,\"conditions\":[]}]}]}]}";
            var goals = await Harness.Call<PlayerGoal[]>(StatsProvider.Goals);
            Assert.Equal(new[] { "driver:1", "driver:2" }, goals.Data.Select(g => g.Key));
            Assert.True(goals.Data[0].Completed);
            Assert.Equal("stage_3", goals.Data[0].StageKey);
            Assert.True(goals.Data[0].Conditions[0].Met);

            t.Routes["analytics_config"] = p => "{\"sendIntervalSeconds\":30,\"stats\":[{\"key\":\"top_speed\",\"kind\":\"max\",\"sendIntervalSeconds\":10}]}";
            var config = await Harness.Call<StatsConfig>(StatsProvider.Config);
            var tracker = new StatTracker(config.Data);
            tracker.Add("top_speed", 120);
            tracker.Add("top_speed", 214);
            var reported = new TaskCompletionSource<StatsReport>();
            tracker.Reported += x => reported.TrySetResult(x);
            tracker.Flush();
            await reported.Task.WaitAsync(System.TimeSpan.FromSeconds(5));
            Assert.Equal(214, (double)JObject.Parse(t.Calls.Last().Payload)["events"][0]["value"]);
        }

        [Fact]
        public async Task PasswordFlowsUseTheAccountRpcs()
        {
            var t = Harness.Start();
            var token = Harness.Jwt(DateTimeOffset.UtcNow.AddHours(1));
            t.Routes["account_password_login"] = p => "{\"token\":\"" + token + "\",\"userId\":\"u-1\",\"username\":\"p\",\"loginKey\":\"\"}";
            var login = await Harness.Call<LoginResponse>(cb => AuthProvider.LoginWithPhone("09121234567", "secret123", cb));
            Assert.True(login.IsSuccess, login.Error?.ToString());
            Assert.Contains("\"phone\":\"09121234567\"", t.Calls.Last().Payload);
            Assert.Contains("\"password\":\"secret123\"", t.Calls.Last().Payload);

            t.Routes["account_password_login"] = p => new NF.RpcServerException("{\"code\":\"AUTH_INVALID_CREDENTIALS\",\"status\":403,\"message\":\"x\"}", 403);
            var wrong = await Harness.Call<LoginResponse>(cb => AuthProvider.LoginWithPhone("09121234567", "bad", cb));
            Assert.Equal("AUTH_INVALID_CREDENTIALS", wrong.Error.Code);

            var early = await Harness.Call<LoginResponse>(cb => AuthProvider.ResetPassword("12345", "newpass99", cb));
            Assert.Equal(ApiError.OtpNotRequested.Code, early.Error.Code);

            t.Routes["account_password_forgot"] = p => "{\"purpose\":\"reset\",\"phone\":\"+989121234567\",\"resendAfter\":60,\"sent\":true}";
            var forgot = await Harness.Call<OtpChallenge>(cb => AuthProvider.ForgotPassword("09121234567", cb));
            Assert.True(forgot.IsSuccess, forgot.Error?.ToString());
            Assert.True(AuthProvider.HasPendingOtp);

            var otp = await Harness.Call<LoginResponse>(cb => AuthProvider.VerifyOtp("12345", OtpChannel.Phone, cb));
            Assert.Equal(ApiError.OtpNotRequested.Code, otp.Error.Code);

            t.Routes["account_password_reset"] = p => "{\"token\":\"" + token + "\",\"userId\":\"u-1\",\"username\":\"p\"}";
            var reset = await Harness.Call<LoginResponse>(cb => AuthProvider.ResetPassword("12345", "newpass99", cb));
            Assert.True(reset.IsSuccess, reset.Error?.ToString());
            var sent = JObject.Parse(t.Calls.Last().Payload);
            Assert.Equal("+989121234567", (string)sent["phone"]);
            Assert.Equal("12345", (string)sent["code"]);
            Assert.Equal("newpass99", (string)sent["newPassword"]);
            Assert.False(AuthProvider.HasPendingOtp);

            t.Routes["account_password_set"] = p => "{\"ok\":true}";
            Assert.True((await Harness.Call<OkResponse>(cb => AuthProvider.SetPassword("secret123", cb))).IsSuccess);
            t.Routes["account_password_change"] = p => new NF.RpcServerException("{\"code\":\"AUTH_INVALID_CURRENT_PASSWORD\",\"status\":403}", 403);
            var change = await Harness.Call<OkResponse>(cb => AuthProvider.UpdatePassword("old", "secret123", cb));
            Assert.Equal("AUTH_INVALID_CURRENT_PASSWORD", change.Error.Code);
            Assert.Contains("\"currentPassword\":\"old\"", t.Calls.Last().Payload);
        }
    }
}
