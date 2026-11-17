using System;
using System.Linq;
using UnityEditor;
#if UNITY_2021_2_OR_NEWER
using UnityEditor.Build;
#endif

namespace NakamaFarsi.Sdk.Editor
{
    [InitializeOnLoad]
    public static class PolicePatrolSwitch
    {
        public const string Symbol = "POLICEPATROL_SDK";
        public const string ConfigName = "PolicePatrolSdkConfig";

        static PolicePatrolSwitch()
        {
            EditorApplication.delayCall += () =>
            {
                if (!IsOn() && AssetDatabase.FindAssets(ConfigName).Any(g => AssetDatabase.GUIDToAssetPath(g).Contains("/Resources/")))
                {
                    Set(true);
                }
            };
        }

        [MenuItem("Tools/Nakama Farsi/Police Patrol/Turn on")]
        public static void TurnOn() => Set(true);

        [MenuItem("Tools/Nakama Farsi/Police Patrol/Turn off")]
        public static void TurnOff() => Set(false);

        [MenuItem("Tools/Nakama Farsi/Police Patrol/Turn on", true)]
        private static bool CanTurnOn() => !IsOn();

        [MenuItem("Tools/Nakama Farsi/Police Patrol/Turn off", true)]
        private static bool CanTurnOff() => IsOn();

        public static bool IsOn() => Symbols(0).Contains(Symbol);

        private static string[] Symbols(int target) =>
            Read(target).Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        public static void Set(bool on)
        {
            for (var target = 0; target < 3; target++)
            {
                var list = Symbols(target).Where(s => s != Symbol).ToList();
                if (on)
                {
                    list.Add(Symbol);
                }

                Write(target, string.Join(";", list));
            }

            UnityEngine.Debug.Log("Nakama Farsi: Police Patrol layer " + (on ? "on (" : "off (") + Symbol + ")");
        }

#if UNITY_2021_2_OR_NEWER
        private static NamedBuildTarget Target(int i) => i == 0 ? NamedBuildTarget.Android : i == 1 ? NamedBuildTarget.Standalone : NamedBuildTarget.iOS;

        private static string Read(int i) => PlayerSettings.GetScriptingDefineSymbols(Target(i));

        private static void Write(int i, string value) => PlayerSettings.SetScriptingDefineSymbols(Target(i), value);
#else
        private static BuildTargetGroup Target(int i) => i == 0 ? BuildTargetGroup.Android : i == 1 ? BuildTargetGroup.Standalone : BuildTargetGroup.iOS;

        private static string Read(int i) => PlayerSettings.GetScriptingDefineSymbolsForGroup(Target(i));

        private static void Write(int i, string value) => PlayerSettings.SetScriptingDefineSymbolsForGroup(Target(i), value);
#endif
    }
}
