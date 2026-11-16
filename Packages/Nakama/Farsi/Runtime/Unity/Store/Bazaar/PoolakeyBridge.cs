using System;
using UnityEngine;

namespace NakamaFarsi.Sdk.Unity
{
    internal static class PoolakeyBridge
    {
        public const string BridgeClass = "com.farsitel.bazaar.PoolakeyBridge";
        public const string CallbackPackage = "com.farsitel.bazaar.callback.";

        public static bool IsInstalled()
        {
            if (Application.platform != RuntimePlatform.Android)
            {
                return false;
            }

            try
            {
                using (new AndroidJavaClass(BridgeClass))
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static AndroidJavaObject Instance()
        {
            using (var bridgeClass = new AndroidJavaClass(BridgeClass))
            {
                return bridgeClass.CallStatic<AndroidJavaObject>("getInstance");
            }
        }

        public static string Failure(string message) => string.IsNullOrWhiteSpace(message) ? "Cafe Bazaar did not answer" : message;
    }
}
