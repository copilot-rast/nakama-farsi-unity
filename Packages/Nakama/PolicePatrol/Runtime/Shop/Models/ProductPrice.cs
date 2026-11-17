using PolicePatrol.Sdk.Economy;

namespace PolicePatrol.Sdk.Shop
{
    public sealed record ProductPrice(
        string CurrencyId,
        double? Amount,
        Currency Currency);
}
