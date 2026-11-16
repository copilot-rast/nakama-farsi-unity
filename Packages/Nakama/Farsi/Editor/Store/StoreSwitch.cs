using System;
using System.Linq;
using UnityEditor;
using UnityEditor.Build;

namespace NakamaFarsi.Sdk.Editor
{
    public static class StoreSwitch
    {
        public const string BazaarSymbol = "NAKAMAFARSI_STORE_BAZAAR";
        public const string MyketSymbol = "NAKAMAFARSI_STORE_MYKET";
        private const string PoolakeyMarker = "poolakey";
        private const string MyketMarker = "ir.myket";

        [MenuItem("Tools/Nakama Farsi/Store/Build for Bazaar")]
        public static void UseBazaar()
        {
            Use(BazaarSymbol);
            MyketInstaller.UseBazaar();
            PoolakeyInstaller.OfferIfMissing();
        }

        [MenuItem("Tools/Nakama Farsi/Store/Build for Myket")]
        public static void UseMyket()
        {
            Use(MyketSymbol);
            MyketInstaller.UseMyket();
        }

        public static string Current()
        {
            var symbols = Read();
            return symbols.Contains(MyketSymbol) ? MyketSymbol : BazaarSymbol;
        }

        public static void Use(string symbol)
        {
            var symbols = Read().Where(item => item != BazaarSymbol && item != MyketSymbol).ToList();
            symbols.Add(symbol);
            WriteSymbols(string.Join(";", symbols));
            SetPoolakeyInBuild(symbol == BazaarSymbol);
            SetMyketInBuild(symbol == MyketSymbol);
        }

        public static int SetPoolakeyInBuild(bool included) => SetInBuild(PoolakeyMarker, included);

        public static int SetMyketInBuild(bool included) => SetInBuild(MyketMarker, included);

        private static int SetInBuild(string marker, bool included)
        {
            var changed = 0;
            foreach (var importer in PluginImporter.GetAllImporters().Where(importer => IsAar(importer, marker)))
            {
                if (importer.GetCompatibleWithPlatform(BuildTarget.Android) == included)
                {
                    continue;
                }

                importer.SetCompatibleWithPlatform(BuildTarget.Android, included);
                importer.SaveAndReimport();
                changed++;
            }

            return changed;
        }

        private static bool IsAar(PluginImporter importer, string marker) =>
            importer.assetPath.EndsWith(".aar", StringComparison.OrdinalIgnoreCase)
            && importer.assetPath.IndexOf(marker, StringComparison.OrdinalIgnoreCase) >= 0;

        private static string[] Read() =>
            ReadSymbols().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

#if UNITY_2021_2_OR_NEWER
        private static string ReadSymbols() => PlayerSettings.GetScriptingDefineSymbols(NamedBuildTarget.Android);

        private static void WriteSymbols(string value) => PlayerSettings.SetScriptingDefineSymbols(NamedBuildTarget.Android, value);
#else
        private static string ReadSymbols() => PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);

        private static void WriteSymbols(string value) => PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, value);
#endif
    }
}
