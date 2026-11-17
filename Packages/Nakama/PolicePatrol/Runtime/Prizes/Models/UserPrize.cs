using System;

namespace PolicePatrol.Sdk.Prizes
{
    public sealed record UserPrize(
        string Id,
        string UserId,
        string PrizeId,
        string Type,
        string EventId,
        string Error,
        bool IsClaimed,
        string Metadata,
        Prize Prize,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
}
