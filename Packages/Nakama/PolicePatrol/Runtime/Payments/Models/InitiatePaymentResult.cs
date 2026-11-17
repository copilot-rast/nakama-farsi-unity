namespace PolicePatrol.Sdk.Payments
{
    public sealed record InitiatePaymentResult(
        string PaymentId,
        string GatewayUrl,
        string Authority);
}
