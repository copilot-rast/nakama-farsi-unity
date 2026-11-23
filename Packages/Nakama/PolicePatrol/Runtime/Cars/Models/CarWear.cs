using System.Collections.Generic;

namespace PolicePatrol.Sdk.Cars
{
    public sealed record CarWear(
        string VehicleKey,
        bool Applied,
        bool Replayed,
        CarCondition Before,
        CarCondition After,
        IReadOnlyDictionary<string, double> Wear,
        bool NeedsCriticalService,
        string[] Critical)
    {
        public double WearOf(string slot) => Wear != null && Wear.TryGetValue(CarSlots.Normalize(slot) ?? string.Empty, out var v) ? v : 0;
    }
}
