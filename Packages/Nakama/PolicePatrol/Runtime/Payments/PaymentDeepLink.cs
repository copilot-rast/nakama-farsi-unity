using System;

namespace PolicePatrol.Sdk.Payments
{
    public static class PaymentDeepLink
    {
        public const string DefaultPrefix = "rastaar://payment";

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

        private static string Root(string prefix)
        {
            var value = (prefix ?? string.Empty).Trim();
            var end = value.IndexOfAny(new[] { '?', '{', '#' });
            return (end < 0 ? value : value.Substring(0, end)).TrimEnd('/');
        }
    }
}
