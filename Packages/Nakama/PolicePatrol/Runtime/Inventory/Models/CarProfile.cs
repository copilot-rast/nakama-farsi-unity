using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Stages;

namespace PolicePatrol.Sdk.Inventory
{
    public sealed class CarProfile : SettingsBag
    {
        public CarProfile(JObject raw, Func<string, string> toGame = null) : base(raw)
        {
            toGame = toGame ?? (k => k);
            Performance = new CarPerformance(Raw["performance"] as JObject);
            var services = Raw["services"] as JObject ?? new JObject();
            Services = services.Properties().Where(p => p.Value is JObject).ToDictionary(
                p => p.Name,
                p => new CarServiceCost(J.Num(p.Value, "coin"), J.Num(p.Value, "gem"), J.Num(p.Value, "seconds")),
                StringComparer.Ordinal);
            GarageMultiplier = J.NumOrNull(services, "garageMultiplier");
            Slots = (Raw["slots"] as JArray ?? new JArray()).OfType<JObject>().Select(s => new CarSlot(
                J.Str(s, "key"), J.Str(s, "name"), J.Str(s, "title"), J.Str(s, "group"), J.Str(s, "selection"), J.Str(s, "collectionId"),
                Strings(s, "parts").Select(toGame).ToArray(), toGame(J.Str(s, "default")))).ToArray();
            DefaultParts = Strings(Raw, "defaultParts").Select(toGame).ToArray();
        }

        public string GameId => Str("gameId");

        public string CarName => Str("carName");

        public string CarClass => Str("carClass");

        public double UnlockGem => Num("unlockGem") ?? 0;

        public CarPerformance Performance { get; }

        public IReadOnlyDictionary<string, CarServiceCost> Services { get; }

        public double? GarageMultiplier { get; }

        public CarSlot[] Slots { get; }

        public string[] DefaultParts { get; }

        public CarSlot Slot(string key) => Slots.FirstOrDefault(s => s.Key == key);
    }
}
