using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Stages
{
    public sealed class FreeRideOfferSettings : SettingsBag
    {
        public static readonly FreeRideOfferSettings Defaults = new FreeRideOfferSettings(null);

        public FreeRideOfferSettings(JObject raw) : base(raw)
        {
        }

        public double SecondsBeforeFirstOffer => Num("secondsBeforeFirstOffer") ?? 45;

        public double SecondsBetweenOffers => Num("secondsBetweenOffers") ?? 120;

        public double SecondsToDecide => Num("secondsToDecide") ?? 20;

        public double NearestSpawnDistance => Num("nearestSpawnDistance") ?? 150;

        public double FurthestSpawnDistance => Num("furthestSpawnDistance") ?? 400;

        public int SpawnAttempts => (int)(Num("spawnAttempts") ?? 12);

        public double OfferWithin => Num("offerWithin") ?? 70;

        public double AutoAcceptWithin => Num("autoAcceptWithin") ?? 12;

        public double SecondsWorthOffering => Num("secondsWorthOffering") ?? 120;

        public double TakeAwayBeyond => Num("takeAwayBeyond") ?? 500;

        public double EndTargetWithin => Num("endTargetWithin") ?? 2500;

        public double ClearRadius => Num("clearRadius") ?? 7;

        public double HostileShareMin => Num("hostileShareMin") ?? 0.7;

        public double HostileShareMax => Num("hostileShareMax") ?? 1.2;

        public bool LogOffers => Flag("logOffers") ?? false;
    }
}
