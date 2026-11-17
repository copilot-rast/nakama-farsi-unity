using System;

namespace PolicePatrol.Sdk.Unity
{
    [Serializable]
    public sealed class GoalCardCondition
    {
        public string stat;

        public string field;

        public string op = "gte";

        public GoalValueType valueType;

        public double number;

        public string text;

        public bool flag;
    }
}
