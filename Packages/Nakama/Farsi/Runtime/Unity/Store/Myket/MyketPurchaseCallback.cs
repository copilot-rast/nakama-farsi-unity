using System;
using UnityEngine;

namespace NakamaFarsi.Sdk.Unity
{
    internal sealed class MyketPurchaseCallback : AndroidJavaProxy
    {
        private readonly Action<MyketReply, MyketPurchase> _onFinished;

        public MyketPurchaseCallback(Action<MyketReply, MyketPurchase> onFinished) : base(MyketBridge.ListenerPrefix + "OnIabPurchaseFinishedListener")
        {
            _onFinished = onFinished;
        }

        public void onIabPurchaseFinished(AndroidJavaObject result, AndroidJavaObject purchase)
        {
            var reply = MyketReply.Read(result);
            var data = reply.IsSuccess ? MyketPurchase.Read(purchase) : null;
            MainThreadQueue.Post(() => _onFinished(reply, data));
        }
    }
}
