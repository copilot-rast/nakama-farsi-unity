using System;

namespace PolicePatrol.Sdk.Stages
{
    public sealed record StageAttempt(string AttemptId, string StageKey, DateTimeOffset StartedAt, DateTimeOffset ExpiresAt);
}
