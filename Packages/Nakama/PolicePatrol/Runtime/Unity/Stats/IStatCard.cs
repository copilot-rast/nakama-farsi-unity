namespace PolicePatrol.Sdk.Unity
{
    public interface IStatCard
    {
        string StatKey { get; }

        string Name { get; }

        string Kind { get; }

        double MaxPerMinute { get; }

        double MaxValue { get; }

        string OverLimit { get; }

        int SendIntervalSeconds { get; }
    }
}
