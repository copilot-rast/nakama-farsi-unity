using System;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Content;

namespace PolicePatrol.Sdk.Economy
{
    public sealed record Meta(
        string Id,
        string Name,
        string Key,
        JToken Metadata,
        string[] ContentIds,
        string[] ContentPackIds,
        double DefaultValue,
        JToken Settings,
        ContentItem[] Contents,
        ContentPack[] ContentPacks,
        LocalizedValue[] Names,
        LocalizedValue[] Descriptions,
        bool ServerOnly,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
}
