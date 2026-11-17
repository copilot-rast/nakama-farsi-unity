using System;
using System.Collections.Generic;
using NakamaFarsi.Sdk.Payments;
using UnityEngine;

namespace NakamaFarsi.Sdk.Unity
{
    public sealed class BazaarStoreBilling : IStoreBilling, ISubscriptionStoreBilling
    {
        private const string InApp = "inApp";
        private const string Subscription = "subscription";

        private readonly string _rsaPublicKey;
        private readonly List<Action<string>> _waiting = new List<Action<string>>();
        private AndroidJavaObject _bridge;
        private bool _connected;
        private bool _connecting;

        public BazaarStoreBilling(string rsaPublicKey)
        {
            _rsaPublicKey = rsaPublicKey ?? string.Empty;
            MainThreadQueue.Ensure();
        }

        public string Method => PaymentMethods.Bazaar;

        public void Purchase(string sku, string developerPayload, Action<StorePurchaseResult> onComplete) =>
            Start(InApp, sku, developerPayload, onComplete);

        public void Subscribe(string sku, string developerPayload, Action<StorePurchaseResult> onComplete) =>
            Start(Subscription, sku, developerPayload, onComplete);

        public void Consume(string purchaseToken, Action<bool> onComplete) =>
            Connect(error =>
            {
                if (error != null)
                {
                    onComplete?.Invoke(false);
                    return;
                }

                _bridge.Call("consume", purchaseToken, new PoolakeyConsumeCallback(onComplete));
            });

        public void GetPurchases(Action<IReadOnlyList<StorePurchase>> onComplete) =>
            Connect(error =>
            {
                if (error != null)
                {
                    onComplete?.Invoke(Array.Empty<StorePurchase>());
                    return;
                }

                _bridge.Call("getPurchases", InApp, new PoolakeyPurchasesCallback(false, products =>
                    _bridge.Call("getPurchases", Subscription, new PoolakeyPurchasesCallback(true, subscriptions =>
                    {
                        var all = new List<StorePurchase>(products);
                        all.AddRange(subscriptions);
                        onComplete?.Invoke(all);
                    }))));
            });

        private void Start(string type, string sku, string developerPayload, Action<StorePurchaseResult> onComplete) =>
            Connect(error =>
            {
                if (error != null)
                {
                    onComplete?.Invoke(StorePurchaseResult.Failed(error));
                    return;
                }

                _bridge.Call("purchase", type, sku, developerPayload ?? string.Empty, (string)null, new PoolakeyPaymentCallback(onComplete));
            });

        private void Connect(Action<string> then)
        {
            if (_connected)
            {
                then(null);
                return;
            }

            _waiting.Add(then);
            if (_connecting)
            {
                return;
            }

            _connecting = true;
            try
            {
                if (_bridge == null)
                {
                    _bridge = PoolakeyBridge.Instance();
                }

                _bridge.Call("connect", _rsaPublicKey, new PoolakeyConnectionCallback(OnConnectionChanged));
            }
            catch (Exception error)
            {
                OnConnectionChanged(false, "Cafe Bazaar billing is not available: " + error.Message);
            }
        }

        private void OnConnectionChanged(bool connected, string error)
        {
            _connected = connected;
            _connecting = false;
            if (_waiting.Count == 0)
            {
                return;
            }

            var waiting = _waiting.ToArray();
            _waiting.Clear();
            foreach (var next in waiting)
            {
                next(connected ? null : error);
            }
        }
    }
}
