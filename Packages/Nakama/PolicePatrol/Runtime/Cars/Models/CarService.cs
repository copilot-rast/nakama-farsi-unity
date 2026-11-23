using System;

namespace PolicePatrol.Sdk.Cars
{
    public sealed record CarService(
        string ServiceId,
        string Slot,
        string State,
        string Route,
        DateTimeOffset? StartedAt,
        DateTimeOffset? EndsAt,
        double Seconds,
        double SecondsLeft,
        double Gem,
        double GemToFinish,
        CarPrice Charged,
        double SkipGem,
        string Source)
    {
        public DateTimeOffset? FinishedAt { get; init; }

        public string FinishedBy { get; init; }

        public DateTimeOffset? ServerTime { get; init; }

        public DateTimeOffset ReceivedAt { get; init; } = DateTimeOffset.UtcNow;

        public bool IsRunning => State == CarServiceStates.Running;

        public TimeSpan ServerOffset => ServerTime.HasValue ? ServerTime.Value - ReceivedAt : TimeSpan.Zero;

        public DateTimeOffset? LocalEndsAt => IsRunning ? ReceivedAt.AddSeconds(Math.Max(0, SecondsLeft)) : (DateTimeOffset?)null;

        public double SecondsLeftAt(DateTimeOffset localNow) => IsRunning ? Math.Max(0, SecondsLeft - Math.Max(0, (localNow - ReceivedAt).TotalSeconds)) : 0;

        public double SecondsLeftNow => SecondsLeftAt(DateTimeOffset.UtcNow);

        public bool IsReadyAt(DateTimeOffset localNow) => !IsRunning || SecondsLeftAt(localNow) <= 0;

        public double Progress(DateTimeOffset localNow) => !IsRunning || Seconds <= 0 ? 1 : Math.Min(1, Math.Max(0, 1 - SecondsLeftAt(localNow) / Seconds));
    }
}
