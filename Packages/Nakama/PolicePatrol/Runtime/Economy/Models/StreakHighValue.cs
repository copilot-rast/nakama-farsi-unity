using System;

namespace PolicePatrol.Sdk.Economy
{
    public sealed record StreakHighValue(
        int Value,
        DateTimeOffset? UpdatedAt);
}
