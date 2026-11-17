using System;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Content
{
    public sealed record ContentItem(
        string Id,
        string Name,
        string Key,
        string ContentPackId,
        string OwnerId,
        string OwnerType,
        string Type,
        string Access,
        JToken Metadata,
        string ContentUrl,
        string LanguageId,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
}
