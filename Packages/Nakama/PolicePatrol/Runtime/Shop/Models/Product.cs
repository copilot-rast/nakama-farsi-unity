using System;
using System.Collections.Generic;
using PolicePatrol.Sdk.Catalog;
using PolicePatrol.Sdk.Prizes;

namespace PolicePatrol.Sdk.Shop
{
    public sealed record Product(
        string Id,
        string Name,
        string Key,
        bool IsActive,
        double DiscountPercent,
        double FinalPrice,
        string ContentsId,
        string Metadata,
        string CategoryId,
        Category Category,
        string[] TagIds,
        Tag[] Tags,
        ProductPrice Price,
        string[] PaymentMethodSupport,
        Dictionary<string, string> Sku,
        bool IsSubscription,
        string PrizeId,
        Prize Prize,
        string[] AssetIds,
        LocalizedValue[] Names,
        LocalizedValue[] Descriptions,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt,
        LocalizedValue[] PurchaseMessages = null,
        string MediaSource = null,
        string MediaAssetId = null,
        ProductMedia Icon = null,
        ProductMedia Cover = null,
        int MinLevel = 0,
        bool HasDiscount = false,
        int? MaxLevel = null,
        bool? Owned = null,
        bool? LevelLocked = null,
        bool IsOneTime = false,
        bool CheckContents = false,
        string IconAddress = null,
        string CoverAddress = null);
}
