using System;
using PolicePatrol.Sdk.Catalog;

namespace PolicePatrol.Sdk.Prizes
{
    public sealed record Prize(
        string Id,
        string Name,
        string PrizeGroupId,
        string Message,
        string Metadata,
        string CategoryId,
        Category Category,
        string[] TagIds,
        Tag[] Tags,
        bool IsRepeatable,
        PrizeItem[] PrizeItems,
        LocalizedValue[] Names,
        LocalizedValue[] Descriptions,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
}
