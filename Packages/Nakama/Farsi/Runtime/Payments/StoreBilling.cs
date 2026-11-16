using System;
using System.Collections.Generic;

namespace NakamaFarsi.Sdk.Payments
{
    public static class PaymentMethods
    {
        public const string Coins = "in_app";
        public const string ZarinPal = "zarinpal";
        public const string Zibal = "zibal";
        public const string Bazaar = "bazaar";
        public const string Myket = "myket";

        public static bool IsStore(string method) => method == Bazaar || method == Myket;

        public static bool IsGateway(string method) => method == ZarinPal || method == Zibal;
    }

    public sealed class StoreConfig
    {
        public string Method { get; set; }
        public bool Sandbox { get; set; }
        public string RsaPublicKey { get; set; }
        public string PackageName { get; set; }
    }

    public interface IStoreBilling
    {
        string Method { get; }

        void Purchase(string sku, string developerPayload, Action<StorePurchaseResult> onComplete);

        void Consume(string purchaseToken, Action<bool> onComplete);

        void GetPurchases(Action<IReadOnlyList<StorePurchase>> onComplete);
    }

    public interface ISubscriptionStoreBilling
    {
        void Subscribe(string sku, string developerPayload, Action<StorePurchaseResult> onComplete);
    }

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

    public enum StoreChoice
    {
        TestStore,
        Bazaar,
        Myket,
        PluginMissing,
        Unsupported,
    }

    public static class StoreSelector
    {
        public static StoreChoice Choose(string method, StoreConfig config, bool onAndroidDevice, bool storePluginInstalled)
        {
            if (config == null || config.Sandbox || !onAndroidDevice)
            {
                return StoreChoice.TestStore;
            }

            StoreChoice store;
            switch (method)
            {
                case PaymentMethods.Bazaar:
                    store = StoreChoice.Bazaar;
                    break;
                case PaymentMethods.Myket:
                    store = StoreChoice.Myket;
                    break;
                default:
                    return StoreChoice.Unsupported;
            }

            return storePluginInstalled ? store : StoreChoice.PluginMissing;
        }
    }

    public static class SandboxPurchaseToken
    {
        public const string Prefix = "sandbox-";

        public static string Create(string developerPayload)
        {
            if (string.IsNullOrWhiteSpace(developerPayload))
            {
                throw new ArgumentException("A sandbox purchase needs the developer payload", nameof(developerPayload));
            }

            return Prefix + developerPayload + "-" + Guid.NewGuid().ToString("N");
        }

        public static string PayloadOf(string purchaseToken)
        {
            if (purchaseToken == null || !purchaseToken.StartsWith(Prefix, StringComparison.Ordinal))
            {
                return null;
            }

            var body = purchaseToken.Substring(Prefix.Length);
            var split = body.LastIndexOf('-');
            return split <= 0 || split == body.Length - 1 ? null : body.Substring(0, split);
        }
    }

    public sealed class TestStoreBilling : IStoreBilling
    {
        private readonly object _lock = new object();
        private readonly List<StorePurchase> _owned = new List<StorePurchase>();

        public TestStoreBilling(string method = PaymentMethods.Bazaar)
        {
            Method = method;
        }

        public string Method { get; }

        public Func<string, bool> Approve { get; set; } = _ => true;

        public void Purchase(string sku, string developerPayload, Action<StorePurchaseResult> onComplete)
        {
            if (Approve != null && !Approve(sku))
            {
                onComplete?.Invoke(StorePurchaseResult.Cancelled());
                return;
            }

            var token = SandboxPurchaseToken.Create(developerPayload);
            lock (_lock)
            {
                _owned.Add(new StorePurchase(sku, token, developerPayload));
            }

            onComplete?.Invoke(StorePurchaseResult.Success(token));
        }

        public void Consume(string purchaseToken, Action<bool> onComplete)
        {
            bool removed;
            lock (_lock)
            {
                removed = _owned.RemoveAll(p => p.PurchaseToken == purchaseToken) > 0;
            }

            onComplete?.Invoke(removed);
        }

        public void GetPurchases(Action<IReadOnlyList<StorePurchase>> onComplete)
        {
            StorePurchase[] list;
            lock (_lock)
            {
                list = _owned.ToArray();
            }

            onComplete?.Invoke(list);
        }
    }
}

namespace NakamaFarsi.Sdk.Payments
{
    public static class PaymentDeepLink
    {
        public static bool Matches(string url, string prefix)
        {
            var root = Root(prefix);
            if (string.IsNullOrEmpty(url) || root.Length == 0 || !url.StartsWith(root, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (url.Length == root.Length)
            {
                return true;
            }

            var next = url[root.Length];
            return next == '?' || next == '/' || next == '#';
        }

        public static string PaymentIdOf(string url)
        {
            var q = url == null ? -1 : url.IndexOf('?');
            if (q < 0)
            {
                return null;
            }

            foreach (var part in url.Substring(q + 1).Split('&', '#'))
            {
                var eq = part.IndexOf('=');
                if (eq > 0 && (part.Substring(0, eq) == "paymentId" || part.Substring(0, eq) == "payment"))
                {
                    return Uri.UnescapeDataString(part.Substring(eq + 1));
                }
            }

            return null;
        }

        private static string Root(string prefix)
        {
            var value = (prefix ?? string.Empty).Trim();
            var end = value.IndexOfAny(new[] { '?', '{', '#' });
            return (end < 0 ? value : value.Substring(0, end)).TrimEnd('/');
        }
    }
}
