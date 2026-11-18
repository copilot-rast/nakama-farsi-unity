using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakamaFarsi.Sdk.Content;
using NakamaFarsi.Sdk.Generated;
using NakamaFarsi.Sdk.Insights;
using Newtonsoft.Json.Linq;
using Xunit;

namespace NakamaFarsi.Sdk.Tests
{
    public class InsightsTests
    {
        private static string Unzip(string b64)
        {
            using (var gz = new GZipStream(new MemoryStream(System.Convert.FromBase64String(b64)), CompressionMode.Decompress))
            using (var r = new StreamReader(gz, Encoding.UTF8))
            {
                return r.ReadToEnd();
            }
        }

        [Fact]
        public async Task SessionStartsPingsPausesAndEndsWithForegroundSeconds()
        {
            var clock = new FakeClock();
            var caller = new FakeCaller { Responder = (id, payload) => "{\"status\":\"open\",\"pingSeconds\":30,\"timeoutSeconds\":120}" };
            var insights = new InsightsClient(new NakamaFarsiRpcs(caller), clock) { Device = new InsightsDevice { AppVersion = "1.0.4", Platform = "android" } };
            await insights.StartSessionAsync();
            Assert.True(insights.Running);
            Assert.Equal(30, insights.PingSeconds);
            var start = JObject.Parse(caller.Calls[0].Payload);
            Assert.Equal("insights_session", caller.Calls[0].Id);
            Assert.Equal("start", (string)start["event"]);
            Assert.Equal("1.0.4", (string)start["appVersion"]);
            clock.Advance(31);
            insights.Tick();
            await Task.Delay(20);
            Assert.Equal("ping", (string)JObject.Parse(caller.Calls[1].Payload)["event"]);
            insights.OnPause();
            clock.Advance(60);
            insights.OnResume();
            clock.Advance(9);
            await insights.EndSessionAsync();
            var end = JObject.Parse(caller.Calls.Last().Payload);
            Assert.Equal("end", (string)end["event"]);
            Assert.Equal(40.0, (double)end["seconds"], 1);
            Assert.False(insights.Running);
        }

        [Fact]
        public async Task HeatmapUploadsGzipCsvPartsUnderTheLimit()
        {
            var caller = new FakeCaller { Responder = (id, payload) => "{\"accepted\":" + (Unzip((string)JObject.Parse(payload)["data"]).Split('\n').Length - 2) + "}" };
            var race = new InsightsClient(new NakamaFarsiRpcs(caller)).NewRace("roadstorm_quick", "ticket-1");
            var rnd = new System.Random(1);
            for (var i = 0; i < 6000; i++)
            {
                race.Record(i * 0.5f, (float)(rnd.NextDouble() * 1000), (float)(rnd.NextDouble() * 1000), "bot" + (i % 6), 120.5f);
            }

            race.MaxPartBytes = 8 * 1024;
            var accepted = await race.UploadAsync();
            Assert.Equal(6000, accepted);
            Assert.True(caller.Calls.Count > 1);
            for (var i = 0; i < caller.Calls.Count; i++)
            {
                var p = JObject.Parse(caller.Calls[i].Payload);
                Assert.Equal("insights_heatmap", caller.Calls[i].Id);
                Assert.Equal(i, (int)p["part"]);
                Assert.Equal("csv.gz", (string)p["format"]);
                Assert.True(((string)p["data"]).Length <= 8 * 1024);
                Assert.StartsWith("t,x,z,player,kmh\n", Unzip((string)p["data"]));
            }
        }

        [Fact]
        public async Task CatalogFillsTheRemoteLoadPathValues()
        {
            var caller = new FakeCaller { Responder = (id, payload) => "{\"platform\":\"Android\",\"pack\":{\"id\":\"p1\",\"version\":\"rs-1\",\"baseUrl\":\"https://cdn/v2/content/files/p1\",\"catalogUrl\":\"https://cdn/v2/content/files/p1/catalog_1.json\",\"catalogHash\":\"abc\"}}" };
            var content = new ContentClient(new NakamaFarsiRpcs(caller));
            var pack = await content.GetCatalogAsync("Android", "1.0.4");
            Assert.Equal("rs-1", pack.Version);
            Assert.Equal("https://cdn/v2/content/files/p1", NakamaFarsiContent.BaseUrl);
            Assert.Equal("abc", NakamaFarsiContent.CatalogHash);
            Assert.Equal("content_catalog", caller.Calls[0].Id);
            Assert.Equal("iOS", ContentClient.PlatformName("IPhonePlayer"));
        }
    }
}
