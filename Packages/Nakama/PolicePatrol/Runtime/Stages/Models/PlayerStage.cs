using System;

namespace PolicePatrol.Sdk.Stages
{
    public sealed record PlayerStage(
        string Key,
        string Name,
        int Order,
        string Mode,
        bool Unlocked,
        int BestStars,
        int Completions,
        StageReward[] Rewards,
        int Xp,
        double? TimeLimitSeconds,
        string RewardGroup,
        int CooldownSeconds,
        int DailyRewardLimit,
        DateTimeOffset? NextRewardAt,
        int? RewardsLeftToday);
}
