namespace PolicePatrol.Sdk.Stats
{
    public sealed record StatsConfig(int SendIntervalSeconds, StatConfig[] Stats);
}
