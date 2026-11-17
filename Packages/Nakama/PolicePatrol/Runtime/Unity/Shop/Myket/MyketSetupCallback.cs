using System;
using UnityEngine;

namespace PolicePatrol.Sdk.Unity
{
    internal sealed class MyketSetupCallback : AndroidJavaProxy
    {
        private readonly Action<bool, string> _onFinished;

        public MyketSetupCallback(Action<bool, string> onFinished) : base(MyketBridge.ListenerPrefix + "OnIabSetupFinishedListener")
        {
            _onFinished = onFinished;
        }

        public void onIabSetupFinished(AndroidJavaObject result)
        {
            var ok = MyketBridge.IsSuccess(result);
            var error = MyketBridge.Failure(result);
            MainThreadQueue.Post(() => _onFinished(ok, error));
        }
    }
}
