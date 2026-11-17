using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Stats
{
    public sealed record GoalCondition(string Stat, string Field, string Op, JToken Value, double? Current, bool Met);
}
