using System;
using UnityEngine;

namespace NakamaFarsi.Sdk.Unity
{
    internal sealed class MyketConsumeCallback : AndroidJavaProxy
    {
        private readonly Action<bool> _onFinished;

        public MyketConsumeCallback(Action<bool> onFinished) : base(MyketBridge.ListenerPrefix + "OnConsumeFinishedListener")
        {
            _onFinished = onFinished;
        }

        public void onConsumeFinished(AndroidJavaObject purchase, AndroidJavaObject result)
        {
            var ok = MyketBridge.IsSuccess(result);
            MainThreadQueue.Post(() => _onFinished?.Invoke(ok));
        }
    }
}
