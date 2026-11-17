using System;

namespace PolicePatrol.Sdk.Catalog
{
    public sealed record TypeDefinition(
        string Id,
        string KeyType,
        string Name,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
}
