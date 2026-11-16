using System;
using System.Text.RegularExpressions;

namespace NakamaFarsi.Sdk.Analytics
{
    public static class AnalyticsValidator
    {
        public const int MaxIdParts = 5;
        public const int MaxPartLength = 64;
        public const int MaxMessageLength = 8192;

        private static readonly Regex Part = new Regex("^[A-Za-z0-9 _.()!?-]{1,64}$", RegexOptions.CultureInvariant);
        private static readonly Regex Currency = new Regex("^[A-Z]{3}$", RegexOptions.CultureInvariant);
        private static readonly Regex Key = new Regex("^[A-Za-z][A-Za-z0-9_]{0,39}$", RegexOptions.CultureInvariant);
        private static readonly Regex LegacyName = new Regex("^[a-z][a-z0-9_.]{1,63}$", RegexOptions.CultureInvariant);

        public static string DesignId(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return "design id is empty";
            }

            var parts = id.Split(':');
            if (parts.Length > MaxIdParts)
            {
                return "design id has more than " + MaxIdParts + " parts";
            }

            foreach (var p in parts)
            {
                var e = IdPart(p);
                if (e != null)
                {
                    return e;
                }
            }

            return null;
        }

        public static string IdPart(string part, bool optional = false)
        {
            if (string.IsNullOrEmpty(part))
            {
                return optional ? null : "id part is empty";
            }

            return Part.IsMatch(part) ? null : "id part \"" + part + "\" must be 1-64 of A-Z a-z 0-9 space _ . ( ) ! ? -";
        }

        public static string Progression(string p1, string p2, string p3)
        {
            if (string.IsNullOrEmpty(p1))
            {
                return "progression needs p1";
            }

            if (string.IsNullOrEmpty(p2) && !string.IsNullOrEmpty(p3))
            {
                return "progression p3 needs p2";
            }

            return IdPart(p1) ?? IdPart(p2, true) ?? IdPart(p3, true);
        }

        public static string Resource(string currency, double amount, string itemType, string item)
        {
            if (!(amount > 0) || double.IsInfinity(amount))
            {
                return "resource amount must be above 0";
            }

            return IdPart(currency) ?? IdPart(itemType) ?? IdPart(item);
        }

        public static string Business(string currency, long amount, string itemType, string item, string cartType)
        {
            if (string.IsNullOrEmpty(currency) || !Currency.IsMatch(currency))
            {
                return "business currency must be an ISO 4217 code like IRR or USD";
            }

            if (amount < 0)
            {
                return "business amount must be 0 or more (minor units)";
            }

            if (cartType != null && cartType.Length > 32)
            {
                return "cart type is longer than 32";
            }

            return IdPart(itemType) ?? IdPart(item) ?? (string.IsNullOrEmpty(cartType) ? null : IdPart(cartType));
        }

        public static string Error(string message) =>
            message != null && message.Length > MaxMessageLength ? "error message is longer than " + MaxMessageLength : null;

        public static string DimensionOrContextKey(string key) =>
            key != null && Key.IsMatch(key) ? null : "key must start with a letter and hold up to 40 of A-Z a-z 0-9 _";

        public static string Value(string value) =>
            value == null || (value.Length >= 1 && value.Length <= 64) ? null : "value must be 1-64 characters";

        public static string LegacyEventName(string name) =>
            name != null && LegacyName.IsMatch(name) ? null : "event name must match ^[a-z][a-z0-9_.]{1,63}$";

        public static bool IsNumber(double v) => !double.IsNaN(v) && !double.IsInfinity(v);

        public static string Lower(ProgressionStatus s) => s.ToString();

        public static string Name(ErrorSeverity s) => s.ToString().ToLowerInvariant();

        internal static void Require(string error, string field)
        {
            if (error != null)
            {
                throw new ArgumentException(error, field);
            }
        }
    }
}
