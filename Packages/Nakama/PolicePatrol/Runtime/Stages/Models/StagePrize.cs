using PolicePatrol.Sdk.Prizes;

namespace PolicePatrol.Sdk.Stages
{
    public sealed record StagePrize(
        string PrizeKey,
        string PrizeGroupKey,
        string For,
        PrizeItem[] Items);
}
