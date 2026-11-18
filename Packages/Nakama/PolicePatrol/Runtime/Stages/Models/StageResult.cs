using PolicePatrol.Sdk.Stats;

namespace PolicePatrol.Sdk.Stages
{
    public sealed record StageResult(
        string StageKey,
        bool Success,
        int Stars,
        int BestStars,
        GrantedReward[] Rewards,
        int XpGained,
        long Xp,
        int Level,
        bool LeveledUp,
        long? NextLevelXp,
        GrantedReward[] MilestoneRewards,
        string RewardLimited,
        Trophy[] Trophies = null)
    {
        public System.DateTimeOffset? NextRewardAt { get; init; }

        public int? RewardsLeftToday { get; init; }

        public StagePrize[] Prizes { get; init; } = System.Array.Empty<StagePrize>();

        public StagePrize[] PendingPrizes { get; init; } = System.Array.Empty<StagePrize>();

        public bool IsRewardLimited => !string.IsNullOrEmpty(RewardLimited);
    }
}
