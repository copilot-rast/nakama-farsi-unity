using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Stages;

namespace PolicePatrol.Sdk.Inventory
{
    public sealed class CarPerformance : SettingsBag
    {
        public CarPerformance(JObject raw) : base(raw)
        {
        }

        public double MaxSpeedKmh => Num("maxSpeedKmh") ?? 0;

        public double EngineMaxRpm => Num("engineMaxRPM") ?? 0;

        public double EngineMaxTorque => Num("engineMaxTorque") ?? 0;

        public double MaxBrakeTorque => Num("maxBrakeTorque") ?? 0;

        public double MaxSteerAngleDegree => Num("maxSteerAngleDegree") ?? 0;

        public double SteerSpeed => Num("steerSpeed") ?? 0;

        public double NitroDuration => Num("nitroDuration") ?? 0;

        public double NitroMaxSpeed => Num("nitroMaxSpeed") ?? 0;

        public double OffroadPerformance => Num("offroadPerformance") ?? 0;

        public double WheelWidth => Num("wheelWidth") ?? 0;
    }
}
