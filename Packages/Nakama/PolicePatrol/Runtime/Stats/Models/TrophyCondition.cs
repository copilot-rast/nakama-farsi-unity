using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Stats
{
    public sealed record TrophyCondition(string Stat, string Tag, string StatName, string Event, string Field, string Op, JToken Value, double? Current, bool? Met)
    {
        public double? Target => Value != null && (Value.Type == JTokenType.Integer || Value.Type == JTokenType.Float) ? (double?)(double)Value : null;

        public string TagKey => string.IsNullOrEmpty(Tag) ? null : Tag.Split('=')[0];

        public string TagValue => string.IsNullOrEmpty(Tag) || Tag.IndexOf('=') < 0 ? null : Tag.Substring(Tag.IndexOf('=') + 1);

        public bool IsAnyTag => TagValue == "*";
    }
}
