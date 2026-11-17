using System;

namespace PolicePatrol.Sdk.Content
{
    public sealed record ContentPack(
        string Id,
        string Name,
        string Key,
        int ContentCount,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
}
