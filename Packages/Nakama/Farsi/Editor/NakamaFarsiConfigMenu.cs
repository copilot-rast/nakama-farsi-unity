using System.IO;
using NakamaFarsi.Sdk.Unity;
using UnityEditor;
using UnityEngine;

namespace NakamaFarsi.Sdk.Editor
{
    public static class NakamaFarsiConfigMenu
    {
        [MenuItem("Tools/Nakama Farsi/Create SDK Config")]
        public static void Create()
        {
            var existing = NakamaFarsiConfig.Load();
            if (existing != null)
            {
                Selection.activeObject = existing;
                return;
            }

            Directory.CreateDirectory("Assets/Resources");
            var config = ScriptableObject.CreateInstance<NakamaFarsiConfig>();
            AssetDatabase.CreateAsset(config, "Assets/Resources/" + NakamaFarsiConfig.ResourceName + ".asset");
            AssetDatabase.SaveAssets();
            Selection.activeObject = config;
        }
    }
}
