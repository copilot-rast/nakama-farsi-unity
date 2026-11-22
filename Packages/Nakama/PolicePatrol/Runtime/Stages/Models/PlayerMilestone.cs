namespace PolicePatrol.Sdk.Stages
{
    public sealed record PlayerMilestone(double Percent, StageReward[] Rewards, bool Claimed)
    {
        public string Id { get; init; }

        public bool Reached { get; init; }

        public string PrizeKey { get; init; }

        public string PrizeGroupKey { get; init; }
    }
}
