using System.Collections.Generic;

namespace PolicePatrol.Sdk.Unity
{
    public interface IGoalCard
    {
        string GoalKey { get; }

        string Name { get; }

        string Description { get; }

        int Order { get; }

        string StageKey { get; }

        IReadOnlyList<GoalCardCondition> Conditions { get; }
    }
}
