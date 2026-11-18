using PolicePatrol.Sdk;
using PolicePatrol.Sdk.Payments;
using PolicePatrol.Sdk.Unity;
using UnityEngine;

public class PolicePatrolZarrinpalSample : MonoBehaviour
{
    [SerializeField] private string productId = "product-id";
    [SerializeField] private string deepLinkPrefix = PaymentDeepLink.DefaultPrefix;

    private void Start()
    {
        PolicePatrolPayments.DeepLinkPrefix = deepLinkPrefix;
        PolicePatrolPayments.ResumePending(Show, destroyCancellationToken);
    }

    public void Buy() => PolicePatrolPayments.PayWithZarrinpal(productId, Show, cancellationToken: destroyCancellationToken);

    private static void Show(ApiResult<Payment> result)
    {
        if (!result.IsSuccess && result.Error.Code == PaymentErrorCodes.RewardPending)
        {
            Debug.Log($"Payment {result.Error.Meta?["paymentId"]} is paid; the reward is still being granted. It is checked again on the next launch.");
            return;
        }

        if (!result.IsSuccess)
        {
            Debug.LogWarning($"Payment could not be checked: {result.Error.Code}");
            return;
        }

        switch (result.Data.Status)
        {
            case PaymentStatus.Success:
                Debug.Log($"Paid {result.Data.FinalPrice} for {result.Data.ProductId}; the reward is already granted on the server.");
                break;
            case PaymentStatus.Pending:
                Debug.Log($"Payment {result.Data.Id} is still pending. It is checked again on the next launch.");
                break;
            default:
                Debug.LogWarning($"Payment {result.Data.Id} ended as {result.Data.Status}.");
                break;
        }
    }
}
