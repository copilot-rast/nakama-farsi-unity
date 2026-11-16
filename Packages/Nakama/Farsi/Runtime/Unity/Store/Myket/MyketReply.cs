using UnityEngine;

namespace NakamaFarsi.Sdk.Unity
{
    internal sealed class MyketReply
    {
        public bool IsSuccess { get; private set; }

        public bool IsCancelled { get; private set; }

        public string Error { get; private set; }

        public static MyketReply Read(AndroidJavaObject result) => new MyketReply
        {
            IsSuccess = MyketBridge.IsSuccess(result),
            IsCancelled = MyketBridge.IsCancel(result),
            Error = MyketBridge.Failure(result),
        };
    }
}
