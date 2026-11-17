namespace PolicePatrol.Sdk.Shop
{
    public sealed class StorePurchaseResult
    {
        private StorePurchaseResult(bool isSuccess, bool isCancelled, string purchaseToken, string error)
        {
            IsSuccess = isSuccess;
            IsCancelled = isCancelled;
            PurchaseToken = purchaseToken;
            Error = error;
        }

        public bool IsSuccess { get; }

        public bool IsCancelled { get; }

        public string PurchaseToken { get; }

        public string Error { get; }

        public static StorePurchaseResult Success(string purchaseToken) => new StorePurchaseResult(true, false, purchaseToken, null);

        public static StorePurchaseResult Cancelled() => new StorePurchaseResult(false, true, null, null);

        public static StorePurchaseResult Failed(string error) => new StorePurchaseResult(false, false, null, error);
    }
}
