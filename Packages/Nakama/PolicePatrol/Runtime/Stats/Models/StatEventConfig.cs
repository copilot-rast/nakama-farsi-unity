namespace PolicePatrol.Sdk.Stats
{
    public sealed record StatEventConfig(string Name, StatEventField[] Fields);

    public sealed record StatEventField(string Name, string Type);
}
