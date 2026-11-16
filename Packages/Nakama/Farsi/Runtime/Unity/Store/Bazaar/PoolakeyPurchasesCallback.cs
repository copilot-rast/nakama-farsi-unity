using System;
using System.Collections.Generic;
using NakamaFarsi.Sdk.Payments;
using UnityEngine;

namespace NakamaFarsi.Sdk.Unity
{
    internal sealed class PoolakeyPurchasesCallback : AndroidJavaProxy
    {
        private readonly bool _subscriptions;
        private readonly Action<IReadOnlyList<StorePurchase>> _onComplete;

        public PoolakeyPurchasesCallback(bool subscriptions, Action<IReadOnlyList<StorePurchase>> onComplete) : base(PoolakeyBridge.CallbackPackage + "PurchasesCallback")
        {
            _subscriptions = subscriptions;
            _onComplete = onComplete;
        }

        public void onSuccess(AndroidJavaObject purchases)
        {
            var list = new List<StorePurchase>();
            var size = purchases.Call<int>("size");
            for (var index = 0; index < size; index++)
            {
                using (var entity = purchases.Call<AndroidJavaObject>("get", index))
                {
                    list.Add(new StorePurchase(
                        entity.Get<string>("productId"),
                        entity.Get<string>("purchaseToken"),
                        entity.Get<string>("payload"),
                        _subscriptions));
                }
            }

            MainThreadQueue.Post(() => _onComplete?.Invoke(list));
        }

        public void onFailure(string message, string stackTrace) =>
            MainThreadQueue.Post(() => _onComplete?.Invoke(Array.Empty<StorePurchase>()));
    }
}
