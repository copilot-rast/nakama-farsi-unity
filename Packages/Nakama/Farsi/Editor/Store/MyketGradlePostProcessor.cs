using System.IO;
using UnityEditor.Android;

namespace NakamaFarsi.Sdk.Editor
{
    public sealed class MyketGradlePostProcessor : IPostGenerateGradleAndroidProject
    {
        public int callbackOrder => 100;

        public void OnPostGenerateGradleAndroidProject(string path)
        {
            if (StoreSwitch.Current() != StoreSwitch.MyketSymbol)
            {
                return;
            }

            var root = Path.GetDirectoryName(path) ?? path;
            Patch(Path.Combine(path, "build.gradle"), MyketGradle.AddPlaceholders);
            Patch(Path.Combine(root, "launcher", "build.gradle"), MyketGradle.AddPlaceholders);
            Patch(Path.Combine(root, "settings.gradle"), MyketGradle.AddRepository);
            Patch(Path.Combine(path, "proguard-unity.txt"), MyketGradle.AddProguard);
        }

        private static void Patch(string file, System.Func<string, string> change)
        {
            if (!File.Exists(file))
            {
                return;
            }

            var text = File.ReadAllText(file);
            var patched = change(text);
            if (patched != text)
            {
                File.WriteAllText(file, patched);
            }
        }
    }
}
