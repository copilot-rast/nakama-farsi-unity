using System;
using PolicePatrol.Sdk.Content;

namespace PolicePatrol.Sdk.Catalog
{
    public sealed record Language(
        string Id,
        string Name,
        string IconId,
        ContentItem Icon,
        LocalizedValue[] Names,
        LocalizedValue[] Descriptions,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
}
