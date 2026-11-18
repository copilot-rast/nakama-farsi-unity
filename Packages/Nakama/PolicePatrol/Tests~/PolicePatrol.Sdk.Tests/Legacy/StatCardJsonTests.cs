using FluentAssertions;
using PolicePatrol.Sdk.Editor;
using PolicePatrol.Sdk.Unity;
using Xunit;

namespace PolicePatrol.Sdk.Tests;

public sealed class StatCardJsonTests
{
    private sealed class Stat : IStatCard
    {
        public string StatKey { get; init; } = " distance_km ";
        public string Name { get; init; } = "مسافت";
        public string Kind { get; init; } = "sum";
        public double MaxPerMinute { get; init; }
        public double MaxValue { get; init; }
        public string OverLimit { get; init; } = "";
        public int SendIntervalSeconds { get; init; }
    }

    private sealed class Goal : IGoalCard
    {
        public string GoalKey => "clean_chase";
        public string Name => "تعقیب تمیز";
        public string Description => null;
        public int Order => 3;
        public string StageKey => "chase_1";
        public IReadOnlyList<GoalCardCondition> Conditions { get; init; } = new List<GoalCardCondition>();
    }

    [Fact]
    public void A_stat_card_leaves_out_limits_it_does_not_set_so_the_panel_keeps_them()
    {
        var json = StatCardJson.Stat(new Stat());

        ((string)json["key"]!).Should().Be("distance_km");
        json.ContainsKey("maxPerMinute").Should().BeFalse();
        json.ContainsKey("sendIntervalSeconds").Should().BeFalse();
        json["overLimit"]!.Type.Should().Be(Newtonsoft.Json.Linq.JTokenType.Null);

        var limited = StatCardJson.Stat(new Stat { MaxPerMinute = 3, SendIntervalSeconds = 30 });
        ((double)limited["maxPerMinute"]!).Should().Be(3);
        ((int)limited["sendIntervalSeconds"]!).Should().Be(30);
    }

    [Fact]
    public void Goal_conditions_send_a_stat_with_a_number_or_a_field_with_its_typed_value()
    {
        var json = StatCardJson.Goal(new Goal
        {
            Conditions = new List<GoalCardCondition>
            {
                new() { stat = "distance_km", op = "gte", number = 10, valueType = GoalValueType.Text, text = "ignored" },
                new() { field = "car", op = "eq", valueType = GoalValueType.Text, text = "bugatti" },
                new() { field = "noDamage", op = "eq", valueType = GoalValueType.Boolean, flag = true },
                null,
            },
        });

        var conditions = json["conditions"]!;
        conditions.Should().HaveCount(3);
        ((double)conditions[0]!["value"]!).Should().Be(10);
        conditions[0]!["field"]!.Type.Should().Be(Newtonsoft.Json.Linq.JTokenType.Null);
        ((string)conditions[1]!["value"]!).Should().Be("bugatti");
        ((bool)conditions[2]!["value"]!).Should().BeTrue();
        ((string)json["stageKey"]!).Should().Be("chase_1");
    }
}
