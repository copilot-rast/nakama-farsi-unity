using System;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Economy
{
    public sealed record Streak(
        string Id,
        string Name,
        string Key,
        string[] EventIds,
        int DurationDays,
        JToken Metadata,
        FreezeTokenConfig FreezeToken,
        LocalizedValue[] Names,
        LocalizedValue[] Descriptions,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
}
