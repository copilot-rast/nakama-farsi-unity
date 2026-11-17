using System;
using System.Collections.Generic;
using UnityEngine;

namespace PolicePatrol.Sdk.Unity
{
    internal sealed class MyketInventoryCallback : AndroidJavaProxy
    {
        private readonly Action<bool, IReadOnlyList<MyketPurchase>> _onFinished;

        public MyketInventoryCallback(Action<bool, IReadOnlyList<MyketPurchase>> onFinished) : base(MyketBridge.ListenerPrefix + "QueryInventoryFinishedListener")
        {
            _onFinished = onFinished;
        }

        public void onQueryInventoryFinished(AndroidJavaObject result, AndroidJavaObject inventory)
        {
            var list = new List<MyketPurchase>();
            var ok = MyketBridge.IsSuccess(result) && inventory != null;
            if (ok)
            {
                using (var all = inventory.Call<AndroidJavaObject>("getAllPurchases"))
                {
                    var size = all.Call<int>("size");
                    for (var index = 0; index < size; index++)
                    {
                        using (var purchase = all.Call<AndroidJavaObject>("get", index))
                        {
                            var data = MyketPurchase.Read(purchase);
                            if (data != null)
                            {
                                list.Add(data);
                            }
                        }
                    }
                }
            }

            MainThreadQueue.Post(() => _onFinished(ok, list));
        }
    }
}
