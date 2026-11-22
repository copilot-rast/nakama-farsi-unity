namespace PolicePatrol.Sdk.Stats
{
    public sealed record StatsReport(StatReportRow[] Stats, Trophy[] Trophies)
    {
        public TrophyUnlock[] Unlocks { get; init; } = System.Array.Empty<TrophyUnlock>();

        public bool Duplicate { get; init; }
    }
}
