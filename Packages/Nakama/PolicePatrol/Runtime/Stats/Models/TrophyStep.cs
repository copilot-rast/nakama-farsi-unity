using System;

namespace PolicePatrol.Sdk.Stats
{
    public sealed record TrophyStep(
        string Id,
        int Step,
        string Name,
        string IconUrl,
        bool Unlocked,
        DateTimeOffset? UnlockedAt,
        bool Available,
        double Progress,
        TrophyCondition[] Conditions,
        TrophyReward Rewards,
        string ClaimMode,
        string ClaimStatus,
        bool Claimable);
}
