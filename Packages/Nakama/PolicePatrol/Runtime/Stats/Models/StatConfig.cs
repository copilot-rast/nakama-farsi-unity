using System;

namespace PolicePatrol.Sdk.Stats
{
    public sealed record StatConfig(string Key, string Kind, int SendIntervalSeconds)
    {
        public string Period { get; init; } = StatPeriods.Total;

        public string[] SplitBy { get; init; } = Array.Empty<string>();
    }
}
