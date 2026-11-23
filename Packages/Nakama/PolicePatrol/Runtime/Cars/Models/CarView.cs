using System;
using System.Linq;

namespace PolicePatrol.Sdk.Cars
{
    public sealed record CarView(
        string VehicleKey,
        string GameId,
        string ItemId,
        bool Equipped,
        CarCondition Condition,
        string[] Critical,
        bool NeedsCriticalService,
        bool InService,
        bool Repairing,
        bool CanDrive,
        string ParkedPoi,
        CarService[] Services,
        CarQuote[] Quotes)
    {
        public string ServerKey { get; init; }

        public DateTimeOffset? UpdatedAt { get; init; }

        public int Percent(string slot) => Condition?.Get(slot) ?? 0;

        public CarQuote Quote(string slot) => Quotes?.FirstOrDefault(q => q.Slot == CarSlots.Normalize(slot));

        public CarService Running(string slot) => Services?.FirstOrDefault(s => s.IsRunning && s.Slot == CarSlots.Normalize(slot));

        public bool IsCritical(string slot) => Critical != null && Array.IndexOf(Critical, CarSlots.Normalize(slot)) >= 0;
    }
}
