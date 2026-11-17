using System.Linq;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Unity;

namespace PolicePatrol.Sdk.Editor
{
    public static class StatCardJson
    {
        public static JObject Stat(IStatCard card)
        {
            var json = new JObject
            {
                ["key"] = (card.StatKey ?? string.Empty).Trim(),
                ["name"] = card.Name ?? string.Empty,
                ["kind"] = Text(card.Kind),
                ["overLimit"] = Text(card.OverLimit),
            };
            if (card.MaxPerMinute > 0)
            {
                json["maxPerMinute"] = card.MaxPerMinute;
            }

            if (card.MaxValue > 0)
            {
                json["maxValue"] = card.MaxValue;
            }

            if (card.SendIntervalSeconds > 0)
            {
                json["sendIntervalSeconds"] = card.SendIntervalSeconds;
            }

            return json;
        }

        public static JObject Goal(IGoalCard card) => new JObject
        {
            ["key"] = (card.GoalKey ?? string.Empty).Trim(),
            ["name"] = card.Name ?? string.Empty,
            ["description"] = card.Description ?? string.Empty,
            ["order"] = card.Order,
            ["stageKey"] = card.StageKey ?? string.Empty,
            ["conditions"] = new JArray((card.Conditions ?? new GoalCardCondition[0]).Where(c => c != null).Select(Condition)),
        };

        public static JObject Condition(GoalCardCondition condition)
        {
            var useStat = !string.IsNullOrWhiteSpace(condition.stat);
            return new JObject
            {
                ["stat"] = useStat ? condition.stat.Trim() : JValue.CreateNull(),
                ["field"] = useStat ? JValue.CreateNull() : (condition.field ?? string.Empty).Trim(),
                ["op"] = string.IsNullOrWhiteSpace(condition.op) ? "gte" : condition.op.Trim(),
                ["value"] = useStat || condition.valueType == GoalValueType.Number
                    ? new JValue(condition.number)
                    : condition.valueType == GoalValueType.Boolean ? new JValue(condition.flag) : new JValue(condition.text ?? string.Empty),
            };
        }

        private static JToken Text(string value) =>
            string.IsNullOrWhiteSpace(value) ? JValue.CreateNull() : new JValue(value.Trim());
    }
}
