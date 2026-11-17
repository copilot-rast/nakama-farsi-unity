using System;

namespace PolicePatrol.Sdk.Economy
{
    public sealed record UserCurrency(
        string Id,
        string UserId,
        string CurrencyId,
        double Value,
        Currency Currency,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
}
