using System;

namespace PolicePatrol.Sdk.Cars
{
    public sealed record CarAdoptTicket(string Slot, long StartedAtTicks, double Seconds, double Gem)
    {
        public static CarAdoptTicket From(string slot, DateTime startedAtUtc, double seconds, double gem) =>
            new CarAdoptTicket(slot, startedAtUtc.Kind == DateTimeKind.Local ? startedAtUtc.ToUniversalTime().Ticks : startedAtUtc.Ticks, seconds, gem);
    }
}
