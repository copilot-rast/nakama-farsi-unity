using System;

namespace PolicePatrol.Sdk.Shop
{
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
}
