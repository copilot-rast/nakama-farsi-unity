using System;
using UnityEngine;

namespace PolicePatrol.Sdk.Unity
{
    internal sealed class PoolakeyConnectionCallback : AndroidJavaProxy
    {
        private readonly Action<bool, string> _onChange;

        public PoolakeyConnectionCallback(Action<bool, string> onChange) : base(PoolakeyBridge.CallbackPackage + "ConnectionCallback")
        {
            _onChange = onChange;
        }

        public void onConnect() => MainThreadQueue.Post(() => _onChange(true, null));

        public void onDisconnect() => MainThreadQueue.Post(() => _onChange(false, "Disconnected from Cafe Bazaar"));

        public void onFailure(string message, string stackTrace) => MainThreadQueue.Post(() => _onChange(false, PoolakeyBridge.Failure(message)));
    }
}
