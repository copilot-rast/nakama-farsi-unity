using System;

namespace PolicePatrol.Sdk.Economy
{
    public sealed record UserMeta(
        string Id,
        string UserId,
        string MetaId,
        double Value,
        Meta Meta,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
}
