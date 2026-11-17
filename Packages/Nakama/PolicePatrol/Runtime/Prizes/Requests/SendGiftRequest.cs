namespace PolicePatrol.Sdk.Prizes
{
    public sealed record SendGiftRequest(
        string TargetUserId,
        string PrizeId,
        string EventId,
        string Metadata);
}
