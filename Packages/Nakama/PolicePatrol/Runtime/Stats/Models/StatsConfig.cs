using System;
using System.Collections.Generic;

namespace PolicePatrol.Sdk.Stats
{
    public sealed record StatsConfig(int SendIntervalSeconds, StatConfig[] Stats)
    {
        private static readonly IReadOnlyDictionary<string, double> NoThresholds = new Dictionary<string, double>();

        public IReadOnlyDictionary<string, double> Thresholds { get; init; } = NoThresholds;

        public int NotificationCode { get; init; } = StatsProvider.DefaultTrophyNotificationCode;

        public string ClaimMode { get; init; }

        public string Day { get; init; }

        public StatEventConfig[] Events { get; init; } = Array.Empty<StatEventConfig>();

        public double BigJumpHeight => Threshold(StatsThresholds.BigJumpHeight, 3);

        public double BigJumpLength => Threshold(StatsThresholds.BigJumpLength, 20);

        public double MmOvertakeGap => Threshold(StatsThresholds.MmOvertakeGap, 0.5);

        public double Threshold(string key, double fallback = 0) => Thresholds != null && Thresholds.TryGetValue(key, out var v) ? v : fallback;
    }
}
