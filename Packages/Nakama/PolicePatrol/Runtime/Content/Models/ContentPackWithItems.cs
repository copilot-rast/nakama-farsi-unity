using System;

namespace PolicePatrol.Sdk.Content
{
    public sealed record ContentPackWithItems(
        string Id,
        string Name,
        string Key,
        ContentItem[] Items,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
}
