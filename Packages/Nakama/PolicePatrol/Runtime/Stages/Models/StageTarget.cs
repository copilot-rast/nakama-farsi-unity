using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Stages
{
    public sealed class StageTarget : SettingsBag
    {
        public StageTarget(JObject raw) : base(raw)
        {
        }

        public string Type => Str("type");

        public string SceneRef => Str("sceneRef");

        public string VehicleConfig => Str("vehicleConfig");
    }
}
