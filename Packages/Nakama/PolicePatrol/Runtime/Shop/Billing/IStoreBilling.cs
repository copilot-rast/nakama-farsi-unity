using System;
using System.Collections.Generic;

namespace PolicePatrol.Sdk.Shop
{
    public interface IStoreBilling
    {
        string Method { get; }

        void Purchase(string sku, string developerPayload, Action<StorePurchaseResult> onComplete);

        void Consume(string purchaseToken, Action<bool> onComplete);

        void GetPurchases(Action<IReadOnlyList<StorePurchase>> onComplete);
    }
}
