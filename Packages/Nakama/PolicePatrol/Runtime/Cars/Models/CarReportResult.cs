using System;

namespace PolicePatrol.Sdk.Cars
{
    public sealed record CarReportResult(DateTimeOffset? ServerTime, bool Changed, CarView Car)
    {
        public DateTimeOffset ReceivedAt { get; init; } = DateTimeOffset.UtcNow;

        public TimeSpan ServerOffset => ServerTime.HasValue ? ServerTime.Value - ReceivedAt : TimeSpan.Zero;
    }
}
