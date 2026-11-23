using System;

namespace PolicePatrol.Sdk.Cars
{
    public sealed record CarAdoptResult(
        DateTimeOffset? ServerTime,
        bool Adopted,
        bool AlreadyAdopted,
        string Mode,
        bool TicketsTrusted,
        CarAdoptApplied[] Applied,
        string[] Skipped,
        int IgnoredServices,
        CarView[] Cars)
    {
        public DateTimeOffset ReceivedAt { get; init; } = DateTimeOffset.UtcNow;

        public TimeSpan ServerOffset => ServerTime.HasValue ? ServerTime.Value - ReceivedAt : TimeSpan.Zero;
    }
}
