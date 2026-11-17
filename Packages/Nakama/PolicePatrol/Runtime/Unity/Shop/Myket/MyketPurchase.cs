using UnityEngine;

namespace PolicePatrol.Sdk.Unity
{
    internal sealed class MyketPurchase
    {
        public string ItemType { get; private set; }

        public string Sku { get; private set; }

        public string Token { get; private set; }

        public string Payload { get; private set; }

        public string Json { get; private set; }

        public string Signature { get; private set; }

        public static MyketPurchase Read(AndroidJavaObject purchase)
        {
            if (purchase == null)
            {
                return null;
            }

            var token = purchase.Call<string>("getToken");
            if (string.IsNullOrEmpty(token))
            {
                return null;
            }

            return new MyketPurchase
            {
                ItemType = purchase.Call<string>("getItemType"),
                Sku = purchase.Call<string>("getSku"),
                Token = token,
                Payload = purchase.Call<string>("getDeveloperPayload"),
                Json = purchase.Call<string>("getOriginalJson"),
                Signature = purchase.Call<string>("getSignature"),
            };
        }

        public AndroidJavaObject ToJava() =>
            new AndroidJavaObject(MyketBridge.PurchaseClass, string.IsNullOrEmpty(ItemType) ? MyketBridge.InApp : ItemType, Json ?? string.Empty, Signature ?? string.Empty);
    }
}
