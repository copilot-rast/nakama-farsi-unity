using System;

namespace PolicePatrol.Sdk.Shop
{
    public interface ISubscriptionStoreBilling
    {
        void Subscribe(string sku, string developerPayload, Action<StorePurchaseResult> onComplete);
    }
}
