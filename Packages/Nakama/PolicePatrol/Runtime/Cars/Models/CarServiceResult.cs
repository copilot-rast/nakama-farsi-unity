using System;

namespace PolicePatrol.Sdk.Cars
{
    public sealed record CarServiceResult(DateTimeOffset? ServerTime, bool Replayed, bool AlreadyDone, bool Completed, CarPrice Charged, CarService Service, CarView Car)
    {
        public DateTimeOffset ReceivedAt { get; init; } = DateTimeOffset.UtcNow;

        public TimeSpan ServerOffset => ServerTime.HasValue ? ServerTime.Value - ReceivedAt : TimeSpan.Zero;
    }
}
