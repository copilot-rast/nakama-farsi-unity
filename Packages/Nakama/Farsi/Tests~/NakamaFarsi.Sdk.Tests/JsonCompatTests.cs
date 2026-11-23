using NakamaFarsi.Sdk.Generated;
using Xunit;

namespace NakamaFarsi.Sdk.Tests
{
    public class JsonCompatTests
    {
        private const string OldServerMatchEnd = "{\"ticket\":\"t1\",\"accepted\":true,\"position\":1,\"rewards\":{\"pits\":120,\"oil\":5,\"trophies\":30},\"payouts\":[],\"trophies\":530}";

        private const string NewServerMatchEnd = "{\"ticket\":\"t1\",\"accepted\":true,\"position\":1,\"rewards\":{\"pits\":120,\"oil\":5,\"trophies\":30,\"xp\":100,\"killPits\":15,\"futureReward\":7},\"payouts\":[],\"trophies\":530,"
            + "\"xp\":1240,\"level\":4,\"leagueMultiplier\":1.2,\"levelUps\":[4],\"leagueName\":{\"fa\":\"نقره\"},\"nextLeagueAt\":null,\"futureField\":{\"a\":[1,2]}}";

        [Fact]
        public void TheNewSdkReadsAnOldServerAnswer()
        {
            var r = SdkJson.Response<CombatraceMatchEndResponse>(OldServerMatchEnd);
            Assert.True(r.Accepted);
            Assert.Equal(120, r.Rewards.Pits);
            Assert.Equal(530, r.Trophies);
            Assert.Null(r.Xp);
            Assert.Null(r.Level);
            Assert.Null(r.LevelUps);
            Assert.Null(r.LeagueMultiplier);
            Assert.Null(r.Rewards.Xp);
        }

        [Fact]
        public void TheNewSdkReadsANewServerAnswer()
        {
            var r = SdkJson.Response<CombatraceMatchEndResponse>(NewServerMatchEnd);
            Assert.Equal(1240, r.Xp);
            Assert.Equal(4, r.Level);
            Assert.Equal(1.2, r.LeagueMultiplier);
            Assert.Equal(new long?[] { 4 }, r.LevelUps);
            Assert.Equal("نقره", (string)r.LeagueName["fa"]);
            Assert.Null(r.NextLeagueAt);
            Assert.True(r.Extra.ContainsKey("futureField"));
            Assert.Equal(15, r.Rewards.KillPits);
            Assert.True(r.Rewards.Extra.ContainsKey("futureReward"));
        }

        [Fact]
        public void FieldsTheSdkDoesNotKnowStayInExtraAndRaw()
        {
            var r = SdkJson.Response<CombatraceConfigResponse>("{\"game\":\"roadstorm\",\"settings\":{\"maxCars\":6,\"futureSetting\":5,\"newBlock\":{\"x\":1}},\"rooms\":[],\"brandNew\":true}");
            Assert.Equal(6, r.Settings.MaxCars);
            Assert.Equal(5, (int)r.Settings.Extra["futureSetting"]);
            Assert.True(r.Extra.ContainsKey("brandNew"));
            Assert.True((bool)r.Raw["brandNew"]);
        }

        [Fact]
        public void AFieldWhoseTypeChangedIsSkippedNotFatal()
        {
            string skipped = null;
            void OnSkip(string path, string message) => skipped = path;
            SdkJson.MemberSkipped += OnSkip;
            try
            {
                var r = SdkJson.Response<CombatraceMatchEndResponse>("{\"ticket\":\"t1\",\"accepted\":true,\"position\":{\"rank\":1},\"trophies\":530}");
                Assert.Equal("t1", r.Ticket);
                Assert.Null(r.Position);
                Assert.Equal(530, r.Trophies);
                Assert.StartsWith("position", skipped);
                Assert.Equal(1, (int)r.Raw["position"]["rank"]);
            }
            finally
            {
                SdkJson.MemberSkipped -= OnSkip;
            }
        }

        [Fact]
        public void NewOptionalRequestFieldsAreNotSentWhenUnset()
        {
            var body = SdkJson.Serialize(new CombatraceMatchEndRequest { Ticket = "t1", Position = 1, Cars = 6, TimeMs = 84250, MaxKmh = 212.5 });
            Assert.Equal("{\"cars\":6,\"maxKmh\":212.5,\"position\":1,\"ticket\":\"t1\",\"timeMs\":84250}", body);
        }
    }
}
