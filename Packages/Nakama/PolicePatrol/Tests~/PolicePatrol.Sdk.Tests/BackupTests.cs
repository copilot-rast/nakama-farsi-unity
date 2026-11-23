using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Backup;
using Xunit;
using NF = NakamaFarsi.Sdk;

namespace PolicePatrol.Sdk.Tests
{
    public class BackupTests
    {
        private static string Fixture(string name) => File.ReadAllText(Path.Combine(System.AppContext.BaseDirectory, "Fixtures", name + ".json"));

        [Fact]
        public async Task ListReadsKindsCountsAndLimits()
        {
            var t = Harness.Start();
            t.Routes["pp_backup_list"] = p => Fixture("pp_backup_list");
            var r = await Harness.Call<BackupList>(cb => BackupProvider.List("a-1", null, cb));
            Assert.True(r.IsSuccess, r.Error?.Code);
            var sent = JObject.Parse(t.Calls.Last(c => c.Id == "pp_backup_list").Payload);
            Assert.Equal("a-1", (string)sent["attemptId"]);
            Assert.Null(sent["mission"]);
            var list = r.Data;
            Assert.False(list.Unlimited);
            Assert.True(list.DebitOnArrival);
            Assert.Equal(3, list.CallsPerMission);
            Assert.Equal(60, list.SecondsBetweenCalls);
            Assert.Equal(1, list.CarsOutAtOnce);
            var ground = list.OfKind(BackupKinds.Ground).Single();
            Assert.Equal("backup_ground", ground.Key);
            Assert.True(ground.IsGround);
            Assert.Equal(4, ground.Count);
            Assert.Equal(3, ground.CallsLeft);
            Assert.True(list.CanCall(ground));
            Assert.Same(ground, list.For(BackupKinds.Ground, "Vitara"));
            var air = list.Find("backup_air");
            Assert.True(air.IsAir);
            Assert.False(list.CanCall(air));
            Assert.Null(list.For("swat", "x"));
        }

        [Fact]
        public async Task UseSendsTheRunAndReadsTheCall()
        {
            var t = Harness.Start();
            t.Routes["pp_backup_use"] = p => Fixture("pp_backup_use");
            var r = await Harness.Call<BackupList>(cb => BackupProvider.Use("backup_ground", "a-1", "req-1", "Vitara", null, cb));
            Assert.True(r.IsSuccess, r.Error?.Code);
            var sent = JObject.Parse(t.Calls.Last(c => c.Id == "pp_backup_use").Payload);
            Assert.Equal("backup_ground", (string)sent["key"]);
            Assert.Equal("a-1", (string)sent["attemptId"]);
            Assert.Equal("req-1", (string)sent["requestId"]);
            Assert.Equal("Vitara", (string)sent["unitId"]);
            Assert.Equal(1, r.Data.Use.Debited);
            Assert.False(r.Data.Use.Replayed);
            Assert.Equal("Vitara", r.Data.Use.UnitId);
            var ground = r.Data.Find("backup_ground");
            Assert.Equal(1, ground.Used);
            Assert.Equal(2, ground.CallsLeft);
            Assert.True(ground.SecondsUntilNextCall > 0);
            Assert.NotNull(ground.NextCallAt);
            Assert.False(r.Data.CanCall(ground));

            var auto = await Harness.Call<BackupList>(cb => BackupProvider.Use("backup_ground", "a-1", null, cb));
            Assert.False(string.IsNullOrEmpty((string)JObject.Parse(t.Calls.Last(c => c.Id == "pp_backup_use").Payload)["requestId"]));
        }

        [Fact]
        public async Task CooldownErrorKeepsTheServerCodeAndWait()
        {
            var t = Harness.Start();
            var body = Fixture("pp_backup_use.cooldown.error");
            t.Routes["pp_backup_use"] = p => new NF.RpcServerException(JObject.Parse(body).ToString(Formatting.None), (int)JObject.Parse(body)["status"]);
            var r = await Harness.Call<BackupList>(cb => BackupProvider.Use("backup_ground", "a-1", "req-2", cb));
            Assert.False(r.IsSuccess);
            Assert.Equal(BackupErrorCodes.Cooldown, r.Error.Code);
            Assert.True(r.Error.RetryAfterSeconds > 0);
        }
    }
}
