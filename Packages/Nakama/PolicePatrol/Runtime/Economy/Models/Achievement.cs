using System;
using PolicePatrol.Sdk.Content;

namespace PolicePatrol.Sdk.Economy
{
    public sealed record Achievement(
        string Id,
        string Name,
        string IconId,
        ContentItem Icon,
        string Key,
        string TaskId,
        LocalizedValue[] Names,
        LocalizedValue[] Descriptions,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
}
