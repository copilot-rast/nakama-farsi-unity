using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Stages
{
    public sealed class ChapterSettings : SettingsBag
    {
        public static readonly ChapterSettings Empty = new ChapterSettings(null);

        public ChapterSettings(JObject raw) : base(raw)
        {
        }

        public string Poi => Str("poi");

        public string PoiCard => Str("poiCard");

        public string StartMode => Str("startMode");

        public double? TriggerRadius => Num("triggerRadius");

        public string ProgressionMode => Str("progressionMode");

        public string Locator => Str("locator");
    }
}
