using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NakamaFarsi.Sdk.Analytics;
using Newtonsoft.Json.Linq;
using Xunit;

namespace NakamaFarsi.Sdk.Tests
{
    public class AnalyticsTests
    {
        private readonly FakeClock _clock = new FakeClock();
        private readonly FakeCaller _rpc = new FakeCaller();
        private readonly MemoryKeyValueStore _store = new MemoryKeyValueStore();

        private AnalyticsClient Make()
        {
            var a = new AnalyticsClient(_rpc, _store, _clock, null, new AnalyticsOptions { AppVersion = "1.4.0", Platform = "android", Build = "b1" });
            a.ApplyConfig(new AnalyticsConfig { MaxBatch = 3, SendIntervalSeconds = 30, SessionTimeoutSeconds = 30, MaxDimensions = 2 });
            return a;
        }

        private List<JObject> Tracked() => _rpc.Calls.Where(c => c.Id == AnalyticsClient.TrackRpc).Select(c => JObject.Parse(c.Payload)).ToList();

        [Fact]
        public void ValidatesLikeGameAnalytics()
        {
            var a = Make();
            Assert.True(a.AddDesignEvent("Vehicle:Distance:SUV:SantaFe", 120));
            Assert.False(a.AddDesignEvent("A:B:C:D:E:F"));
            Assert.False(a.AddDesignEvent("Bad|Char"));
            Assert.False(a.AddDesignEvent("Empty::Part"));
            Assert.False(a.AddProgressionEvent(ProgressionStatus.Start, "Chapter1", null, "Stage3"));
            Assert.False(a.AddResourceEvent(ResourceFlow.Source, "coin", 0, "Stage", "Stage3"));
            Assert.False(a.AddBusinessEvent("irr", 100, "coins", "pack"));
            Assert.True(a.AddBusinessEvent("IRR", 500000, "coins", "pack_100", "shop", "bazaar", "order-1"));
            Assert.False(a.AddNamedEvent("Bad Name"));
            Assert.Equal(7, a.Dropped);
        }

        [Fact]
        public async Task EnvelopeCarriesSessionDeviceDimensionsAndContext()
        {
            var a = Make();
            a.StartSession();
            a.SetCustomDimension("tier", "vip");
            a.SetContext("vehicle", "SantaFe");
            a.SetContext("weather", "rain");
            a.AddDesignEvent("Vehicle:Distance:SUV:SantaFe", 120);
            a.AddProgressionEvent(ProgressionStatus.Complete, "Chapter1", "Stage3", score: 1200);
            Assert.True(await a.SendAllAsync());

            var batches = Tracked();
            Assert.Equal(2, batches.Count);
            var b = batches[1];
            Assert.StartsWith("b-", (string)b["batchId"]);
            Assert.Equal("1.4.0", (string)b["appVersion"]);
            Assert.Equal("android", (string)b["device"]["platform"]);
            Assert.Equal(1, (int)b["session"]["num"]);
            Assert.Equal("vip", (string)b["dimensions"]["tier"]);
            Assert.Equal("SantaFe", (string)b["context"]["vehicle"]);
            var events = (JArray)b["events"];
            Assert.Equal("design", (string)events[0]["type"]);
            Assert.Equal(120, (double)events[0]["value"]);
            Assert.Equal("Complete", (string)events[1]["status"]);
            Assert.Equal(1200, (int)events[1]["score"]);
            Assert.NotNull(events[1]["time"]);
            Assert.Equal("session", (string)batches[0]["events"][0]["type"]);
        }

        [Fact]
        public async Task ContextChangeSplitsBatchesAndPerEventOverride()
        {
            var a = Make();
            a.SetContext("stage", "Stage1");
            a.AddDesignEvent("Crash:Wall", 1);
            a.SetContext("stage", "Stage2");
            a.AddDesignEvent("Crash:Wall", 1);
            a.AddDesignEvent("Crash:Tree", 1, new Dictionary<string, string> { ["weather"] = "fog" });
            Assert.True(await a.SendAllAsync());
            var stages = Tracked().Select(b => (string)b["context"]?["stage"] + "/" + (string)b["context"]?["weather"]).ToList();
            Assert.Equal(new[] { "Stage1/", "Stage2/", "Stage2/fog" }, stages);
        }

        [Fact]
        public async Task SameBatchIdUntilTheServerAnswers()
        {
            var a = Make();
            a.AddDesignEvent("Kill:Zombie", 1);
            _rpc.Answers.Enqueue(new ApiException(ApiError.Network("offline")));
            Assert.False(await a.SendAllAsync());
            Assert.Equal(2, a.Queued);

            var b = Make();
            Assert.Equal(3, b.Queued);
            _rpc.Answers.Enqueue(new ApiException(new ApiError("ANALYTICS_RATE_LIMITED", 429, "", null, 10)));
            Assert.False(await b.SendAllAsync());
            _rpc.Answers.Enqueue("{\"batchId\":\"x\",\"duplicate\":false,\"received\":2,\"stored\":2}");
            Assert.True(await b.SendAllAsync());

            var ids = Tracked().Select(x => (string)x["batchId"]).ToList();
            Assert.Equal(4, ids.Count);
            Assert.Single(ids.Take(3).Distinct());
            Assert.NotEqual(ids[0], ids[3]);
            Assert.Equal(0, b.Queued);
        }

        [Fact]
        public async Task ValidationErrorsDropTheBatch()
        {
            var a = Make();
            a.AddDesignEvent("Kill:Zombie", 1);
            ApiError failed = null;
            var dropped = false;
            a.BatchFailed += (e, d) => { failed = e; dropped = d; };
            _rpc.Answers.Enqueue(new ApiException(new ApiError("ANALYTICS_BATCH_TOO_LARGE", 400, "")));
            Assert.False(await a.SendAllAsync());
            Assert.True(dropped);
            Assert.Equal("ANALYTICS_BATCH_TOO_LARGE", failed.Code);
            Assert.Equal(0, a.Queued);
        }

        [Fact]
        public void TickSendsOnIntervalOrFullBatch()
        {
            var a = Make();
            a.StartSession();
            a.Tick();
            Assert.Single(Tracked());
            a.AddDesignEvent("A", 1);
            a.Tick();
            Assert.Single(Tracked());
            _clock.Advance(31);
            a.Tick();
            Assert.Equal(2, Tracked().Count);
            a.AddDesignEvent("A", 1);
            a.AddDesignEvent("A", 1);
            a.AddDesignEvent("A", 1);
            a.Tick();
            Assert.Equal(3, Tracked().Count);
        }

        [Fact]
        public void SessionsFollowPauseAndRestart()
        {
            var a = Make();
            a.CanSend = () => false;
            a.StartSession();
            var first = a.SessionId;
            _clock.Advance(100);
            a.OnPause();
            _clock.Advance(10);
            a.OnResume();
            Assert.Equal(first, a.SessionId);
            _clock.Advance(50);
            a.OnPause();
            _clock.Advance(120);
            a.OnResume();
            Assert.NotEqual(first, a.SessionId);
            Assert.Equal(2, a.SessionNum);
            a.Persist();

            var ends = SessionEvents(_store).Where(e => (string)e["status"] == "end").ToList();
            Assert.Single(ends);
            Assert.Equal(160, (long)ends[0]["length"]);

            _clock.Advance(40);
            a.Tick();
            a.Persist();
            _clock.Advance(3600);
            var b = Make();
            b.CanSend = () => false;
            b.StartSession();
            Assert.Equal(3, b.SessionNum);
            b.Persist();
            var lengths = SessionEvents(_store).Where(e => (string)e["status"] == "end").Select(e => (long)e["length"]).ToList();
            Assert.Equal(new long[] { 160, 40 }, lengths);
        }

        private static IEnumerable<JObject> SessionEvents(MemoryKeyValueStore store)
        {
            var state = JObject.Parse(store.Get("nf.analytics.state"));
            return ((JArray)state["queue"]).Select(q => (JObject)q["e"]).Where(e => (string)e["type"] == "session");
        }

        [Fact]
        public void DimensionsAreCapped()
        {
            var a = Make();
            a.SetCustomDimension("a", "1");
            a.SetCustomDimension("b", "2");
            a.SetCustomDimension("c", "3");
            a.AddDesignEvent("X", 1);
            a.Persist();
            var dims = (JObject)((JArray)JObject.Parse(_store.Get("nf.analytics.state"))["queue"]).Last["d"];
            Assert.Equal(2, dims.Count);
        }

        [Fact]
        public async Task ConfigFromServer()
        {
            _rpc.Answers.Enqueue("{\"maxBatch\":20,\"sendIntervalSeconds\":15,\"stats\":[{\"key\":\"distance_km\",\"kind\":\"sum\",\"sendIntervalSeconds\":30}],\"typed\":{\"maxDimensions\":3,\"sessionTimeoutSeconds\":45,\"dimensions\":[{\"key\":\"tier\",\"values\":[\"vip\",\"free\"]}],\"contextKeys\":[{\"key\":\"vehicle\",\"values\":[]}],\"designRoots\":[{\"root\":\"Vehicle\",\"levels\":[{\"name\":\"metric\",\"values\":[\"Distance\"]}]}],\"resourceCurrencies\":[\"coin\",\"gem\"],\"resourceItemTypes\":[\"Stage\"],\"unknownDesign\":\"reject\"}}");
            var a = new AnalyticsClient(_rpc, _store, _clock);
            var c = await a.LoadConfigAsync();
            Assert.Equal(20, c.MaxBatch);
            Assert.Equal(45, c.SessionTimeoutSeconds);
            Assert.Equal("Vehicle", c.DesignRoots[0].Root);
            Assert.Equal("metric", c.DesignRoots[0].Levels[0].Key);
            Assert.True(c.Dimensions[0].Allows("vip"));
            Assert.False(c.Dimensions[0].Allows("gold"));
            Assert.Equal("sum", c.Stats["distance_km"].Kind);
            Assert.Equal("reject", c.UnknownDesign);
            Assert.True(_rpc.Calls[0].Options.ReadOnly);
        }

        [Fact]
        public async Task UnlockedStepsAreRaised()
        {
            var a = Make();
            JArray got = null;
            a.Unlocked += u => got = u;
            a.AddDesignEvent("Vehicle:Distance", 5);
            _rpc.Responder = (id, p) => "{\"batchId\":\"b\",\"received\":2,\"stored\":2,\"unlocked\":[{\"stepId\":\"s1\",\"trophyKey\":\"driver\",\"trophyName\":\"Driver\",\"step\":1}]}";
            Assert.True(await a.SendAllAsync());
            Assert.Equal("driver", (string)got[0]["trophyKey"]);
        }
    }
}
