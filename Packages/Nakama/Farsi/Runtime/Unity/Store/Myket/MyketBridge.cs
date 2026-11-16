using System;
using UnityEngine;

namespace NakamaFarsi.Sdk.Unity
{
    internal static class MyketBridge
    {
        public const string HelperClass = "ir.myket.billingclient.IabHelper";
        public const string ListenerPrefix = HelperClass + "$";
        public const string PurchaseClass = "ir.myket.billingclient.util.Purchase";
        public const string InApp = "inapp";
        public const int UserCanceled = 1;
        public const int HelperUserCancelled = -1005;

        public static bool IsInstalled()
        {
            if (Application.platform != RuntimePlatform.Android)
            {
                return false;
            }

            try
            {
                using (new AndroidJavaClass(HelperClass))
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static AndroidJavaObject Activity()
        {
            using (var player = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                return player.GetStatic<AndroidJavaObject>("currentActivity");
            }
        }

        public static bool IsSuccess(AndroidJavaObject result) => result != null && result.Call<bool>("isSuccess");

        public static bool IsCancel(AndroidJavaObject result)
        {
            if (result == null)
            {
                return false;
            }

            var code = result.Call<int>("getResponse");
            return code == UserCanceled || code == HelperUserCancelled;
        }

        public static string Failure(AndroidJavaObject result)
        {
            var message = result?.Call<string>("getMessage");
            return string.IsNullOrWhiteSpace(message) ? "Myket did not answer" : message;
        }
    }
}
