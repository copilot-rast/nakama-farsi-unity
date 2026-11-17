using PolicePatrol.Sdk.Shop;

namespace PolicePatrol.Sdk.Payments
{
    public sealed record PaymentPreview(
        decimal OriginalPrice,
        decimal FinalPayableAmount,
        Product Product);
}
