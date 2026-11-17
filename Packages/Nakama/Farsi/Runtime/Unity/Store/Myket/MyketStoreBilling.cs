using System;
using System.Collections.Generic;
using NakamaFarsi.Sdk.Payments;
using UnityEngine;

namespace NakamaFarsi.Sdk.Unity
{
    public sealed class MyketStoreBilling : IStoreBilling
    {
        private readonly string _rsaPublicKey;
        private readonly List<Action<string>> _waiting = new List<Action<string>>();
        private readonly Dictionary<string, MyketPurchase> _purchases = new Dictionary<string, MyketPurchase>();
        private AndroidJavaObject _helper;
        private bool _connected;
        private bool _connecting;

        public MyketStoreBilling(string rsaPublicKey)
        {
            _rsaPublicKey = rsaPublicKey ?? string.Empty;
            MainThreadQueue.Ensure();
        }

        public string Method => PaymentMethods.Myket;

        public void Purchase(string sku, string developerPayload, Action<StorePurchaseResult> onComplete) =>
            Connect(error =>
            {
                if (error != null)
                {
                    onComplete?.Invoke(StorePurchaseResult.Failed(error));
                    return;
                }

                try
                {
                    using (var activity = MyketBridge.Activity())
                    {
                        _helper.Call("launchPurchaseFlow", activity, sku, new MyketPurchaseCallback((reply, purchase) =>
                        {
                            if (reply.IsSuccess && purchase != null)
                            {
                                _purchases[purchase.Token] = purchase;
                                onComplete?.Invoke(StorePurchaseResult.Success(purchase.Token));
                                return;
                            }

                            onComplete?.Invoke(reply.IsCancelled ? StorePurchaseResult.Cancelled() : StorePurchaseResult.Failed(reply.Error));
                        }), developerPayload ?? string.Empty);
                    }
                }
                catch (Exception failure)
                {
                    onComplete?.Invoke(StorePurchaseResult.Failed("Myket billing is not available: " + failure.Message));
                }
            });

        public void Consume(string purchaseToken, Action<bool> onComplete)
        {
            if (string.IsNullOrEmpty(purchaseToken))
            {
                onComplete?.Invoke(false);
                return;
            }

            if (_purchases.TryGetValue(purchaseToken, out var known))
            {
                ConsumeKnown(known, onComplete);
                return;
            }

            Query(found =>
            {
                if (found && _purchases.TryGetValue(purchaseToken, out var purchase))
                {
                    ConsumeKnown(purchase, onComplete);
                    return;
                }

                onComplete?.Invoke(false);
            });
        }

        public void GetPurchases(Action<IReadOnlyList<StorePurchase>> onComplete) =>
            Query(found =>
            {
                var list = new List<StorePurchase>();
                if (found)
                {
                    foreach (var purchase in _purchases.Values)
                    {
                        list.Add(new StorePurchase(purchase.Sku, purchase.Token, purchase.Payload));
                    }
                }

                onComplete?.Invoke(list);
            });

        private void ConsumeKnown(MyketPurchase purchase, Action<bool> onComplete) =>
            Connect(error =>
            {
                if (error != null)
                {
                    onComplete?.Invoke(false);
                    return;
                }

                try
                {
                    using (var java = purchase.ToJava())
                    {
                        _helper.Call("consumeAsync", java, new MyketConsumeCallback(consumed =>
                        {
                            if (consumed)
                            {
                                _purchases.Remove(purchase.Token);
                            }

                            onComplete?.Invoke(consumed);
                        }));
                    }
                }
                catch (Exception)
                {
                    onComplete?.Invoke(false);
                }
            });

        private void Query(Action<bool> onComplete) =>
            Connect(error =>
            {
                if (error != null)
                {
                    onComplete(false);
                    return;
                }

                _helper.Call("queryInventoryAsync", new MyketInventoryCallback((ok, purchases) =>
                {
                    if (ok)
                    {
                        _purchases.Clear();
                        foreach (var purchase in purchases)
                        {
                            _purchases[purchase.Token] = purchase;
                        }
                    }

                    onComplete(ok);
                }));
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
                if (_helper == null)
                {
                    using (var activity = MyketBridge.Activity())
                    {
                        _helper = new AndroidJavaObject(MyketBridge.HelperClass, activity, _rsaPublicKey);
                    }
                }

                _helper.Call("startSetup", new MyketSetupCallback(OnConnectionChanged));
            }
            catch (Exception error)
            {
                OnConnectionChanged(false, "Myket billing is not available: " + error.Message);
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
