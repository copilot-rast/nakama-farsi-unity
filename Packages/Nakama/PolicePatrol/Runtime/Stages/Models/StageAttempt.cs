using System;

namespace PolicePatrol.Sdk.Stages
{
    public sealed record StageAttempt(string AttemptId, string StageKey, DateTimeOffset StartedAt, DateTimeOffset ExpiresAt)
    {
        public StageItem Item { get; init; }

        public double? TimeLimitSeconds { get; init; }
    }
}
