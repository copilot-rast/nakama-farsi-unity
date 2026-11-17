using System.Collections.Generic;
using NakamaFarsi.Sdk.Analytics;

namespace PolicePatrol.Sdk.Analytics
{
    public static class PolicePatrolAnalytics
    {
        public static AnalyticsClient Client => PolicePatrolSdk.Client?.Core.Analytics;

        public static void SetContext(string key, string value) => Client?.SetContext(key, value);

        public static void ClearContext() => Client?.ClearContext();

        public static void SetCustomDimension(string key, string value) => Client?.SetCustomDimension(key, value);

        public static bool AddDesignEvent(string eventId, double? value = null, IDictionary<string, string> context = null) =>
            Client?.AddDesignEvent(eventId, value, context) ?? false;

        public static bool AddProgressionEvent(ProgressionStatus status, string progression01, string progression02 = null, string progression03 = null, int? score = null) =>
            Client?.AddProgressionEvent(status, progression01, progression02, progression03, score) ?? false;

        public static bool AddResourceEvent(ResourceFlow flow, string currency, double amount, string itemType, string itemId) =>
            Client?.AddResourceEvent(flow, currency, amount, itemType, itemId) ?? false;

        public static bool AddBusinessEvent(string currency, long amount, string itemType, string itemId, string cartType = null, string store = null, string receipt = null) =>
            Client?.AddBusinessEvent(currency, amount, itemType, itemId, cartType, store, receipt) ?? false;

        public static bool AddErrorEvent(ErrorSeverity severity, string message) => Client?.AddErrorEvent(severity, message) ?? false;

        public static void Flush() => Client?.Flush();
    }
}
