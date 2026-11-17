using System;

namespace PolicePatrol.Sdk.Economy
{
    public sealed record UserStreak(
        string Id,
        string UserId,
        string StreakId,
        int Value,
        int FreezeToken,
        bool FreezeAvailable,
        DateTimeOffset? FreezeLastUsedAt,
        DateTimeOffset? FreezeNextAvailableAt,
        StreakHighValue HighValue,
        DateTimeOffset LastUpdated,
        Streak Streak,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
}
