using System.Linq;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Stages
{
    public sealed class StageMission : SettingsBag
    {
        public StageMission(JObject raw) : base(raw)
        {
            Targets = (Raw["targets"] as JArray ?? new JArray()).OfType<JObject>().Select(t => new StageTarget(t)).ToArray();
            Enemies = (Raw["enemies"] as JArray ?? new JArray()).OfType<JObject>().Select(e => new StageEnemy(e)).ToArray();
        }

        public string Id => Str("id");

        public string Mode => Str("mode");

        public string Spawn => Str("spawn");

        public string Weather => Str("weather");

        public double? Timer => Num("timer");

        public double? ReachRadius => Num("reachRadius");

        public bool? ShowArrowGuidance => Flag("showArrowGuidance");

        public double? HideArrowWithin => Num("hideArrowWithin");

        public double? EscapeAlarmSeconds => Num("escapeAlarmSeconds");

        public double? TimeoutWarningSeconds => Num("timeoutWarningSeconds");

        public string[] AcceptedCarClasses => Strings("acceptedCarClasses");

        public string[] AcceptedCars => Strings("acceptedCars");

        public string[] ExcludedCars => Strings("excludedCars");

        public double? SeenDistance => Num("seenDistance");

        public double? EscapeDistance => Num("escapeDistance");

        public double? EscortTimer => Num("escortTimer");

        public double? MaxDistanceFromPlayer => Num("maxDistanceFromPlayer");

        public StageTarget[] Targets { get; }

        public StageEnemy[] Enemies { get; }

        public bool AcceptsCar(string car, string carClass)
        {
            if (ExcludedCars.Any(x => string.Equals(x, car, System.StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            var cars = AcceptedCars;
            var classes = AcceptedCarClasses;
            if (cars.Length == 0 && classes.Length == 0)
            {
                return true;
            }

            return cars.Any(x => string.Equals(x, car, System.StringComparison.OrdinalIgnoreCase))
                || classes.Any(x => string.Equals(x, carClass, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
