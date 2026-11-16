using System;
using UnityEngine;

namespace NakamaFarsi.Sdk.Unity
{
    internal sealed class PoolakeyConsumeCallback : AndroidJavaProxy
    {
        private readonly Action<bool> _onComplete;

        public PoolakeyConsumeCallback(Action<bool> onComplete) : base(PoolakeyBridge.CallbackPackage + "ConsumeCallback")
        {
            _onComplete = onComplete;
        }

        public void onSuccess() => MainThreadQueue.Post(() => _onComplete?.Invoke(true));

        public void onFailure(string message, string stackTrace) => MainThreadQueue.Post(() => _onComplete?.Invoke(false));
    }
}
