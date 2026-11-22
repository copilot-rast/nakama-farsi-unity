using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Stages
{
    public sealed class StageEnemy : SettingsBag
    {
        public StageEnemy(JObject raw) : base(raw)
        {
        }

        public string Config => Str("config");

        public string Vehicle => Str("vehicle");

        public double? SpeedMax => Num("speedMax");

        public double? Health => Num("health");

        public double? AntiBulletPercent => Num("antiBulletPercent");

        public double? PowerAttackPercent => Num("powerAttackPercent");

        public double? SelfDefensePercent => Num("selfDefensePercent");

        public string StartMode => Str("startMode");

        public double? SeenZone => Num("seenZone");

        public double? EscapeZone => Num("escapeZone");

        public bool? PathFollow => Flag("pathFollow");

        public bool? AllowGun => Flag("allowGun");
    }
}
