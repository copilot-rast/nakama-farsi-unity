namespace PolicePatrol.Sdk.Stages
{
    public sealed record StageCondition(string Field, string Op, double Value, string Missing)
    {
        public bool PassesWhenMissing => Missing == "pass";
    }
}
