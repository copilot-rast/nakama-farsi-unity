using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using UnityEditor;
using UnityEngine;

namespace NakamaFarsi.Sdk.Editor
{
    [InitializeOnLoad]
    public static class PoolakeyInstaller
    {
        public const string Release = "2.1.1";
        public const string WithResolverUrl = "https://github.com/cafebazaar/PoolakeyUnitySdk/releases/download/" + Release + "/PoolakeyEssentialsWithExternalDependencyManagerUnity6_unitypackage";
        public const string WithoutResolverUrl = "https://github.com/cafebazaar/PoolakeyUnitySdk/releases/download/" + Release + "/PoolakeyEssentialsWithoutExternalDependencyManagerUnity6_unitypackage";
        private const string Title = "Nakama Farsi: Cafe Bazaar billing";
        private const string ResolveMenu = "Assets/External Dependency Manager/Android Resolver/Resolve";
        private const string PluginName = "poolakey-release";
        public const string KotlinVersion = "1.9.10";
        public const string KotlinFixPath = "Assets/NakamaFarsi/Editor/NakamaFarsiKotlin_Dependencies.xml";

        static PoolakeyInstaller()
        {
#if !POLICEPATROL_SDK
            EditorApplication.delayCall += OfferOnce;
            EditorApplication.delayCall += () => EnsureKotlinFix();
#endif
        }

        public static string KotlinFixXml() =>
            "<dependencies>\n"
            + "  <androidPackages>\n"
            + "    <androidPackage spec=\"org.jetbrains.kotlin:kotlin-stdlib:" + KotlinVersion + "\"/>\n"
            + "    <androidPackage spec=\"org.jetbrains.kotlin:kotlin-stdlib-jdk7:" + KotlinVersion + "\"/>\n"
            + "    <androidPackage spec=\"org.jetbrains.kotlin:kotlin-stdlib-jdk8:" + KotlinVersion + "\"/>\n"
            + "  </androidPackages>\n"
            + "</dependencies>\n";

        public static bool EnsureKotlinFix()
        {
            if (!IsInstalled())
            {
                return false;
            }

            var path = Path.Combine(Path.GetDirectoryName(Application.dataPath) ?? string.Empty, KotlinFixPath);
            var xml = KotlinFixXml();
            if (File.Exists(path) && File.ReadAllText(path) == xml)
            {
                return false;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            File.WriteAllText(path, xml);
            AssetDatabase.Refresh();
            Debug.Log("Nakama Farsi: pinned Kotlin " + KotlinVersion + " for Android (" + KotlinFixPath + ") so Poolakey's older Kotlin does not cause duplicate classes");
            return true;
        }

        public static bool IsInstalled() => AssetDatabase.FindAssets(PluginName).Length > 0;

        [MenuItem("Tools/Nakama Farsi/Store/Install Poolakey (Cafe Bazaar)")]
        public static void InstallFromMenu()
        {
            if (IsInstalled() && !EditorUtility.DisplayDialog(Title, "Poolakey is already in this project. Import it again?", "Import again", "Cancel"))
            {
                return;
            }

            Install();
        }

        public static void OfferIfMissing()
        {
            if (IsInstalled())
            {
                return;
            }

            if (EditorUtility.DisplayDialog(Title, "Bazaar builds need Cafe Bazaar's Poolakey plugin, which is not in this project yet. Download and import it now?", "Install", "Later"))
            {
                Install();
            }
        }

        public static void Install()
        {
            var url = HasResolver() ? WithoutResolverUrl : WithResolverUrl;
            var file = Path.Combine(Path.GetTempPath(), "poolakey-" + Release + ".unitypackage");

            try
            {
                EditorUtility.DisplayProgressBar(Title, "Downloading Poolakey " + Release + " from GitHub", 0.3f);
                using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(2) })
                {
                    File.WriteAllBytes(file, client.GetByteArrayAsync(url).GetAwaiter().GetResult());
                }
            }
            catch (Exception error)
            {
                EditorUtility.ClearProgressBar();
                EditorUtility.DisplayDialog(Title, "Could not download Poolakey: " + error.Message + "\n\nDownload it by hand from\n" + url + "\nand import it with Assets → Import Package.", "OK");
                return;
            }

            EditorUtility.ClearProgressBar();
            AssetDatabase.ImportPackage(file, false);
            EditorApplication.delayCall += () =>
            {
                EnsureKotlinFix();
                Resolve();
            };
            Debug.Log("Nakama Farsi: imported Poolakey " + Release + " for Cafe Bazaar billing");
        }

        private static void OfferOnce()
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode
                || EditorUserBuildSettings.activeBuildTarget != BuildTarget.Android
                || StoreSwitch.Current() != StoreSwitch.BazaarSymbol
                || IsInstalled()
                || EditorPrefs.GetBool(SkipKey(), false))
            {
                return;
            }

            var choice = EditorUtility.DisplayDialogComplex(
                Title,
                "This is an Android project with the Bazaar store selected, but Cafe Bazaar's Poolakey plugin is missing. Without it real purchases cannot open the Bazaar payment screen. Download and import it now?",
                "Install",
                "Later",
                "Don't ask again");

            if (choice == 0)
            {
                Install();
            }
            else if (choice == 2)
            {
                EditorPrefs.SetBool(SkipKey(), true);
            }
        }

        private static void Resolve()
        {
            if (!EditorApplication.ExecuteMenuItem(ResolveMenu))
            {
                Debug.Log("Nakama Farsi: run Assets → External Dependency Manager → Android Resolver → Resolve to add the Poolakey Android library");
            }
        }

        private static bool HasResolver()
        {
            if (AppDomain.CurrentDomain.GetAssemblies().Any(assembly => assembly.GetName().Name.StartsWith("Google.VersionHandler", StringComparison.Ordinal)))
            {
                return true;
            }

            var manifest = Path.Combine(Path.GetDirectoryName(Application.dataPath) ?? string.Empty, "Packages", "manifest.json");
            return File.Exists(manifest) && File.ReadAllText(manifest).Contains("com.google.external-dependency-manager");
        }

        private static string SkipKey() => "NakamaFarsi.Poolakey.Skip." + Application.dataPath;
    }
}
