using System;
using PolicePatrol.Sdk;
using PolicePatrol.Sdk.Payments;
using PolicePatrol.Sdk.Unity;
using UnityEngine;

public class PolicePatrolStoreBillingSample : MonoBehaviour
{
    [SerializeField] private string productId = "product-id";
    [SerializeField] private string paymentMethod = PaymentMethods.Bazaar;

    public void Buy()
    {
        PaymentProvider.InitiateBilling(productId, paymentMethod, initiation =>
        {
            if (!initiation.IsSuccess)
            {
                Debug.LogWarning($"Billing could not start: {initiation.Error.Code}");
                return;
            }

            var billing = initiation.Data;
            PurchaseInStore(billing.Sku, billing.DeveloperPayload, purchaseToken => Submit(billing.Id, purchaseToken));
        });
    }

    protected virtual void PurchaseInStore(string sku, string developerPayload, Action<string> onPurchased)
    {
        Debug.LogWarning($"Buy {sku} with Poolakey (Bazaar) or the Myket SDK here, pass \"{developerPayload}\" as the developer payload, then call onPurchased with the purchase token.");
    }

    protected virtual void ConsumeInStore(string purchaseToken)
    {
        Debug.Log("Consume the purchase in the store SDK here, only after the server verified the receipt.");
    }

    protected void Submit(string paymentId, string purchaseToken)
    {
        PolicePatrolPayments.SubmitBilling(paymentId, purchaseToken, result =>
        {
            if (PaymentPoller.IsVerified(result))
            {
                ConsumeInStore(purchaseToken);
                if (result.IsSuccess)
                {
                    Debug.Log($"Payment {result.Data.Id} is paid and the reward is granted.");
                    return;
                }

                Debug.Log($"Payment {result.Error.Meta?["paymentId"]} is paid; the reward ({result.Error.ServerCode}) is still being granted. Show \"your purchase is on its way\" and follow it with PaymentPoller.WaitForReward.");
                return;
            }

            if (result.IsSuccess)
            {
                Debug.LogWarning($"Payment {result.Data.Id} is {result.Data.Status}. Keep the purchase unconsumed and submit it again later.");
                return;
            }

            if (PaymentPoller.IsRetryable(result.Error))
            {
                Debug.LogWarning("The store or the network is down. Keep the purchase unconsumed and call Submit again later with the same payment id and token.");
                return;
            }

            switch (result.Error.Code)
            {
                case PaymentErrorCodes.AlreadyProcessed:
                    ConsumeInStore(purchaseToken);
                    break;
                case PaymentErrorCodes.StoreModeChanged:
                    Debug.LogWarning("The store mode changed on the server. Keep the purchase unconsumed and submit it again later.");
                    break;
                case PaymentErrorCodes.DeveloperPayloadMismatch:
                    Debug.LogWarning("The purchase was made with a different developer payload. Start again with InitiateBilling.");
                    break;
                default:
                    Debug.LogWarning($"The server rejected the purchase: {result.Error.Code}");
                    break;
            }
        }, destroyCancellationToken);
    }
}
