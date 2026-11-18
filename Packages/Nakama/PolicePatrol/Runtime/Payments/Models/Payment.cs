using System;
using PolicePatrol.Sdk.Shop;

namespace PolicePatrol.Sdk.Payments
{
    public sealed record Payment(
        string Id,
        string UserId,
        string TargetType,
        string ProductId,
        decimal OriginalPrice,
        decimal FinalPrice,
        decimal Amount,
        string PaymentMethod,
        string Status,
        string GatewayTransactionId,
        string GatewayAuthority,
        string ErrorMessage,
        string GiftCode,
        int? GiftDiscountPercent,
        string RefId,
        Product Product,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt)
    {
        public bool? RewardGranted { get; init; }

        public bool IsRewardPending => Status == PaymentStatus.Success && RewardGranted == false;
    }
}
