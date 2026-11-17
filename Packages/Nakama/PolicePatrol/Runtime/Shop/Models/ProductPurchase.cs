using System;

namespace PolicePatrol.Sdk.Shop
{
    public sealed record ProductPurchase(string ProductId, string ProductKey, int Count, DateTimeOffset LastPurchasedAt);
}
