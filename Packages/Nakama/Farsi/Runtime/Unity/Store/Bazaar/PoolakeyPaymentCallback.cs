using System;
using NakamaFarsi.Sdk.Payments;
using UnityEngine;

namespace NakamaFarsi.Sdk.Unity
{
    internal sealed class PoolakeyPaymentCallback : AndroidJavaProxy
    {
        private readonly Action<StorePurchaseResult> _onComplete;

        public PoolakeyPaymentCallback(Action<StorePurchaseResult> onComplete) : base(PoolakeyBridge.CallbackPackage + "PaymentCallback")
        {
            _onComplete = onComplete;
        }

        public void onStart()
        {
        }

        public void onCancel() => MainThreadQueue.Post(() => _onComplete?.Invoke(StorePurchaseResult.Cancelled()));

        public void onSuccess(
            string orderId,
            string purchaseToken,
            string payload,
            string packageName,
            int purchaseState,
            long purchaseTime,
            string productId,
            string originalJson,
            string dataSignature) =>
            MainThreadQueue.Post(() => _onComplete?.Invoke(StorePurchaseResult.Success(purchaseToken)));

        public void onFailure(string message, string stackTrace) =>
            MainThreadQueue.Post(() => _onComplete?.Invoke(StorePurchaseResult.Failed(PoolakeyBridge.Failure(message))));
    }
}
