using System.IO;
using PolicePatrol.Sdk.Unity;
using UnityEditor;
using UnityEngine;

namespace PolicePatrol.Sdk.Editor
{
    public static class PolicePatrolSdkConfigMenu
    {
        private const string Folder = "Assets/Resources";
        private const string AssetPath = Folder + "/" + PolicePatrolSdkConfig.ResourceName + ".asset";

        [MenuItem("Tools/PolicePatrol/Create SDK Config")]
        public static void CreateOrSelect()
        {
            var config = AssetDatabase.LoadAssetAtPath<PolicePatrolSdkConfig>(AssetPath);
            if (config == null)
            {
                if (!Directory.Exists(Folder))
                {
                    AssetDatabase.CreateFolder("Assets", "Resources");
                }

                config = ScriptableObject.CreateInstance<PolicePatrolSdkConfig>();
                AssetDatabase.CreateAsset(config, AssetPath);
                AssetDatabase.SaveAssets();
            }

            Selection.activeObject = config;
            EditorGUIUtility.PingObject(config);
        }
    }
}
