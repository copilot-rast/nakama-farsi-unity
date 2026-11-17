namespace PolicePatrol.Sdk.Stats
{
    public sealed record StatsBacklog(StatBatch[] Batches, StatValue[] Pending);
}
