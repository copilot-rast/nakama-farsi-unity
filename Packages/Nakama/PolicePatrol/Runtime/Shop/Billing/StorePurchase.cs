namespace PolicePatrol.Sdk.Shop
{
    public sealed class StorePurchase
    {
        public StorePurchase(string sku, string purchaseToken, string developerPayload, bool isSubscription = false)
        {
            Sku = sku;
            PurchaseToken = purchaseToken;
            DeveloperPayload = developerPayload;
            IsSubscription = isSubscription;
        }

        public string Sku { get; }

        public string PurchaseToken { get; }

        public string DeveloperPayload { get; }

        public bool IsSubscription { get; }
    }
}
