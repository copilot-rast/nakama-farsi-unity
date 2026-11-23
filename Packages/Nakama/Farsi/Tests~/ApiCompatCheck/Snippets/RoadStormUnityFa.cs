using System.Threading.Tasks;
using NakamaFarsi.Sdk;
using NakamaFarsi.Sdk.Generated;
using NakamaFarsi.Sdk.Unity;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ApiCompat.RoadStorm
{
    public sealed class Car
    {
        public Vector3 position;
        public string name;
        public float speedKmh;
    }

    public static class UnityFaSection3
    {
        public static async Task Race(NakamaFarsiClient client)
        {
            var cfg   = await client.Rpcs.Combatrace.ConfigAsync();
            var begin = await client.Rpcs.Combatrace.MatchBeginAsync(new CombatraceMatchBeginRequest { Room = "ranked" });
            var end   = await client.Rpcs.Combatrace.MatchEndAsync(new CombatraceMatchEndRequest {
                Ticket = begin.Ticket, Position = 1, Cars = 6, TimeMs = 84250, MaxKmh = 212.5 });
        }
    }

    public static class UnityFaSection5
    {
        public static async Task Content(NakamaFarsiClient client)
        {
            var pack = await client.Content.GetCatalogAsync(NakamaFarsiRunner.ContentPlatform(), Application.version);
            if (pack != null)
                await Addressables.LoadContentCatalogAsync(pack.CatalogUrl).Task;
        }
    }

    public static class UnityFaSection6
    {
        public static async Task Session(NakamaFarsiClient client)
        {
            await client.Insights.StartSessionAsync();
        }

        public static async Task Heatmap(NakamaFarsiClient client, CombatraceMatchBeginResponse begin, float time, Car car)
        {
            var race = client.Insights.NewRace("roadstorm_desert", begin.Ticket);
            race.Record(time, car.position.x, car.position.z, car.name, car.speedKmh);
            await race.UploadAsync();
        }
    }
}
