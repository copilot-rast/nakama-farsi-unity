using System;

namespace PolicePatrol.Sdk.Stats
{
    public sealed record PlayerGoal(
        string Key,
        string Name,
        string Description,
        int Order,
        string StageKey,
        string PrizeId,
        bool Completed,
        DateTimeOffset? CompletedAt,
        GoalCondition[] Conditions);
}
