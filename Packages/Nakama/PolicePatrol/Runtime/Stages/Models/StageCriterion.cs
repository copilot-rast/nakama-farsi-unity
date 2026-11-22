namespace PolicePatrol.Sdk.Stages
{
    public sealed record StageCriterion(string Field, double? Value, int Stars)
    {
        public bool WasSent => Value.HasValue;
    }
}
