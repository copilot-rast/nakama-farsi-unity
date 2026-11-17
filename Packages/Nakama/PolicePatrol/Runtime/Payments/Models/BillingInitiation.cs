namespace PolicePatrol.Sdk.Payments
{
    public sealed record BillingInitiation(
        string Id,
        decimal PayableAmount,
        decimal TotalAmount,
        string ProductName,
        string Sku,
        string DeveloperPayload);
}
