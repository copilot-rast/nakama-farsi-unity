using System.Linq;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Stages
{
    public sealed class StageSettings : SettingsBag
    {
        public static readonly StageSettings Empty = new StageSettings(null);

        public StageSettings(JObject raw) : base(raw)
        {
            Missions = (Raw["missions"] as JArray ?? new JArray()).OfType<JObject>().Select(m => new StageMission(m)).ToArray();
        }

        public string UnityLevelId => Str("unityLevelId");

        public string Context => Str("context");

        public string Brief => Str("brief");

        public string Message => Str("message");

        public string ResultRoute => Str("resultRoute");

        public bool? ShowExperiencePanel => Flag("showExperiencePanel");

        public bool? ShowRewardPanel => Flag("showRewardPanel");

        public string StartPoint => Str("startPoint");

        public StageMission[] Missions { get; }

        public bool AcceptsCar(string car, string carClass) => Missions.All(m => m.AcceptsCar(car, carClass));
    }
}
