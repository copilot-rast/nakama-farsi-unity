using System;

namespace PolicePatrol.Sdk.Editor
{
    public static class MyketGradle
    {
        public const string Library = "ir.myket:billing:2.2";
        public const string Repository = "https://maven.myket.ir";
        public const string MarketId = "ir.mservices.market";
        public const string SdkVersion = "2.2";
        private const string PlaceholderMarker = "marketApplicationId";
        private const string DefaultConfig = "defaultConfig {";

        public static string DependenciesXml() =>
            "<dependencies>\n"
            + "  <androidPackages>\n"
            + "    <androidPackage spec=\"" + Library + "\">\n"
            + "      <repositories>\n"
            + "        <repository>" + Repository + "</repository>\n"
            + "      </repositories>\n"
            + "    </androidPackage>\n"
            + "  </androidPackages>\n"
            + "</dependencies>\n";

        public static string ProguardRules() =>
            "-keep class ir.myket.billingclient.** { *; }\n"
            + "-keep interface ir.myket.billingclient.** { *; }\n"
            + "-keep class com.android.vending.billing.** { *; }\n"
            + "-keep interface com.android.vending.billing.** { *; }\n";

        public static string AddPlaceholders(string buildGradle)
        {
            if (buildGradle == null || buildGradle.Contains(PlaceholderMarker))
            {
                return buildGradle;
            }

            var at = buildGradle.IndexOf(DefaultConfig, StringComparison.Ordinal);
            if (at < 0)
            {
                return buildGradle;
            }

            var line = "\n        manifestPlaceholders += [marketApplicationId: '" + MarketId
                + "', marketBindAddress: '" + MarketId + ".InAppBillingService.BIND', marketPermission: '" + MarketId
                + ".BILLING', sdkVersion: '" + SdkVersion + "']";
            var end = at + DefaultConfig.Length;
            return buildGradle.Substring(0, end) + line + buildGradle.Substring(end);
        }

        public static string AddRepository(string settingsGradle)
        {
            if (settingsGradle == null || settingsGradle.Contains(Repository))
            {
                return settingsGradle;
            }

            var block = settingsGradle.IndexOf("dependencyResolutionManagement", StringComparison.Ordinal);
            var from = block < 0 ? 0 : block;
            var at = settingsGradle.IndexOf("mavenCentral()", from, StringComparison.Ordinal);
            if (at < 0)
            {
                return settingsGradle;
            }

            var end = at + "mavenCentral()".Length;
            return settingsGradle.Substring(0, end) + "\n        maven { url '" + Repository + "' }" + settingsGradle.Substring(end);
        }

        public static string AddProguard(string rules)
        {
            var current = rules ?? string.Empty;
            if (current.Contains("ir.myket.billingclient"))
            {
                return current;
            }

            return current + (current.Length == 0 || current.EndsWith("\n", StringComparison.Ordinal) ? string.Empty : "\n") + ProguardRules();
        }
    }
}
