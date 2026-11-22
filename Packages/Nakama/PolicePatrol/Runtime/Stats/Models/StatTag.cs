namespace PolicePatrol.Sdk.Stats
{
    public sealed record StatTag(string Tag, string Key, string Label, double Value, double Current, double Total, double Best);
}
