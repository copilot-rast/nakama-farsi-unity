using System;
using System.Linq;
using Newtonsoft.Json.Linq;

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
        int? RewardsLeftToday)
    {
        public int MinLevel { get; init; }

        public string ChapterKey { get; init; }

        public string Description { get; init; }

        public string IconUrl { get; init; }

        public string Address { get; init; }

        public JObject Metadata { get; init; } = new JObject();

        public StageLock[] Locks { get; init; } = Array.Empty<StageLock>();

        public int Wins { get; init; }

        public double? BestSeconds { get; init; }

        public StageReward[] Claimed { get; init; } = Array.Empty<StageReward>();

        public int ClaimedXp { get; init; }

        public double[] StarMultipliers { get; init; } = Array.Empty<double>();

        public StarRule[] StarRules { get; init; } = Array.Empty<StarRule>();

        public string StarTemplate { get; init; }

        public double? MinSeconds { get; init; }

        public bool NoReplayAfterWin { get; init; }

        public bool Replayable { get; init; } = true;

        public StageSettings Settings { get; init; } = StageSettings.Empty;

        public string UnityLevelId => Settings.UnityLevelId ?? J.Str(Metadata, "unityLevelId");

        public string Context => Settings.Context ?? J.Str(Metadata, "context");

        public bool CanStart => Unlocked && Replayable;

        public StageReward[] RewardsLeft => (Rewards ?? Array.Empty<StageReward>())
            .Select(r => new StageReward(r.CurrencyId, Math.Max(0, r.Amount - (Claimed ?? Array.Empty<StageReward>()).Where(c => c.CurrencyId == r.CurrencyId).Sum(c => c.Amount))))
            .Where(r => r.Amount > 0)
            .ToArray();
    }
}
