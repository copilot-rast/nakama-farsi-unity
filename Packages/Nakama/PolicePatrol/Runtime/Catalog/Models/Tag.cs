using System;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Content;

namespace PolicePatrol.Sdk.Catalog
{
    public sealed record Tag(
        string Id,
        string Name,
        string Key,
        string KeyType,
        string IconId,
        ContentItem Icon,
        LocalizedValue[] Names,
        LocalizedValue[] Descriptions,
        JToken Metadata,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
}
