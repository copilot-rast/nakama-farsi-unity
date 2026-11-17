using System;
using PolicePatrol.Sdk.Content;

namespace PolicePatrol.Sdk.Catalog
{
    public sealed record Country(
        string Id,
        string Name,
        string Code,
        string IconId,
        ContentItem Icon,
        LocalizedValue[] Names,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
}
