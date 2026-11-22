using System;
using System.Linq;

namespace PolicePatrol.Sdk.Stats
{
    public sealed record PlayerStat(string Key, string Name, string Kind, double Total, double Best, DateTimeOffset? LastReportedAt)
    {
        public string Period { get; init; } = StatPeriods.Total;

        public string[] SplitBy { get; init; } = Array.Empty<string>();

        public double Value { get; init; }

        public double Current { get; init; }

        public StatTag[] Tags { get; init; } = Array.Empty<StatTag>();

        public StatTag Tag(string tag) => Tags?.FirstOrDefault(t => t.Tag == tag);

        public StatTag Tag(string key, string label) => Tags?.FirstOrDefault(t => t.Key == key && t.Label == label);

        public StatTag[] TagsOf(string key) => (Tags ?? Array.Empty<StatTag>()).Where(t => t.Key == key).ToArray();
    }
}
