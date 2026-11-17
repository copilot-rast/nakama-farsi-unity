using System;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Content;

namespace PolicePatrol.Sdk.Economy
{
    public sealed record Currency(
        string Id,
        string Name,
        string Type,
        string Key,
        JToken Metadata,
        string[] ContentIds,
        string[] ContentPackIds,
        double DefaultValue,
        double StableValue,
        ContentItem[] Contents,
        ContentPack[] ContentPacks,
        LocalizedValue[] Names,
        LocalizedValue[] Descriptions,
        bool ServerOnly,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
}
