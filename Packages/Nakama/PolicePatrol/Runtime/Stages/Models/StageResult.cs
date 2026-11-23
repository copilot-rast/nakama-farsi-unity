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

        public string ChapterKey { get; init; }

        public int PreviousBestStars { get; init; }

        public StageCriterion[] Criteria { get; init; } = System.Array.Empty<StageCriterion>();

        public string[] MilestoneIds { get; init; } = System.Array.Empty<string>();

        public double? TimeSavedPercent { get; init; }

        public double? MinSeconds { get; init; }

        public bool? Replayable { get; init; }

        public StarRule[] StarRules { get; init; } = System.Array.Empty<StarRule>();

        public double? ServerSeconds { get; init; }

        public TrophyUnlock[] Unlocks { get; init; } = System.Array.Empty<TrophyUnlock>();

        public Cars.CarWear CarWear { get; init; }

        public bool IsRewardLimited => !string.IsNullOrEmpty(RewardLimited);
    }
}
