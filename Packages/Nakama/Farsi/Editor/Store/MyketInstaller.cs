using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace NakamaFarsi.Sdk.Editor
{
    public static class MyketInstaller
    {
        public const string DependenciesPath = "Assets/NakamaFarsi/Editor/NakamaFarsiMyket_Dependencies.xml";
        public const string ParkedSuffix = ".myket-off";
        private const string DependenciesEnding = "Dependencies.xml";
        private const string PoolakeyMarker = "poolakey";

        public static void UseMyket()
        {
            WriteDependencies();
            var parked = ParkPoolakeyDependencies();
            AssetDatabase.Refresh();
            Debug.Log("Nakama Farsi: Myket build selected; added " + MyketGradle.Library + (parked > 0 ? " and left Poolakey's Gradle dependencies out" : string.Empty)
                + ". Run Assets → External Dependency Manager → Android Resolver → Resolve");
        }

        public static void UseBazaar()
        {
            var full = FullPath(DependenciesPath);
            if (File.Exists(full))
            {
                AssetDatabase.DeleteAsset(DependenciesPath);
            }

            RestorePoolakeyDependencies();
            AssetDatabase.Refresh();
        }

        private static void WriteDependencies()
        {
            var full = FullPath(DependenciesPath);
            var xml = MyketGradle.DependenciesXml();
            if (File.Exists(full) && File.ReadAllText(full) == xml)
            {
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(full)!);
            File.WriteAllText(full, xml);
        }

        private static int ParkPoolakeyDependencies()
        {
            var parked = 0;
            foreach (var path in AssetPaths().Where(IsPoolakeyDependencies))
            {
                if (string.IsNullOrEmpty(AssetDatabase.MoveAsset(path, path + ParkedSuffix)))
                {
                    parked++;
                }
            }

            return parked;
        }

        private static void RestorePoolakeyDependencies()
        {
            foreach (var path in AssetPaths().Where(path => path.EndsWith(DependenciesEnding + ParkedSuffix, System.StringComparison.OrdinalIgnoreCase)))
            {
                AssetDatabase.MoveAsset(path, path.Substring(0, path.Length - ParkedSuffix.Length));
            }
        }

        private static bool IsPoolakeyDependencies(string path)
        {
            if (!path.EndsWith(DependenciesEnding, System.StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            var full = FullPath(path);
            return File.Exists(full) && File.ReadAllText(full).IndexOf(PoolakeyMarker, System.StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static string[] AssetPaths() => AssetDatabase.GetAllAssetPaths();

        private static string FullPath(string assetPath) =>
            Path.Combine(Path.GetDirectoryName(Application.dataPath) ?? string.Empty, assetPath);
    }
}
