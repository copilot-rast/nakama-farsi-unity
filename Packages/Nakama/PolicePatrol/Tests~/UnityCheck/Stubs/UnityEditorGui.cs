namespace UnityEngine
{
    public struct Vector2
    {
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float x;
        public float y;
    }

    public sealed class GUILayoutOption
    {
    }

    public sealed class GUIStyle
    {
        public int fontSize { get; set; }

        public bool wordWrap { get; set; }
    }

    public sealed class GUISkin
    {
        public GUIStyle label { get; } = new GUIStyle();

        public GUIStyle button { get; } = new GUIStyle();

        public GUIStyle toggle { get; } = new GUIStyle();

        public GUIStyle box { get; } = new GUIStyle();
    }

    public static class Screen
    {
        public static int width => 0;

        public static int height => 0;
    }

    public sealed class GUIContent
    {
        public GUIContent(string text, string tooltip = null)
        {
            this.text = text;
            this.tooltip = tooltip;
        }

        public string text;
        public string tooltip;
    }

    public static class GUI
    {
        public static bool enabled { get; set; }

        public static int depth { get; set; }

        public static GUISkin skin { get; } = new GUISkin();

        public static void Box(Rect position, string text) { }
    }

    public static class GUILayout
    {
        public static bool Button(string text, params GUILayoutOption[] options) => false;

        public static bool Toggle(bool value, string text, params GUILayoutOption[] options) => value;

        public static void Label(string text, params GUILayoutOption[] options) { }

        public static void Label(Texture image, params GUILayoutOption[] options) { }

        public static void BeginArea(Rect screenRect) { }

        public static void EndArea() { }

        public static void BeginHorizontal(params GUILayoutOption[] options) { }

        public static void EndHorizontal() { }

        public static void BeginVertical(params GUILayoutOption[] options) { }

        public static void BeginVertical(GUIStyle style, params GUILayoutOption[] options) { }

        public static void EndVertical() { }

        public static Vector2 BeginScrollView(Vector2 scrollPosition, params GUILayoutOption[] options) => scrollPosition;

        public static void EndScrollView() { }

        public static void FlexibleSpace() { }

        public static GUILayoutOption Width(float width) => new GUILayoutOption();

        public static GUILayoutOption Height(float height) => new GUILayoutOption();
    }
}

namespace UnityEditor
{
    using UnityEngine;

    public enum MessageType
    {
        None = 0,
        Info = 1,
        Warning = 2,
        Error = 3,
    }

    public class EditorWindow : ScriptableObject
    {
        public static T GetWindow<T>(string title) where T : EditorWindow => null;

        public void Repaint() { }
    }

    public static class EditorStyles
    {
        public static GUIStyle boldLabel => new GUIStyle();

        public static GUIStyle wordWrappedLabel => new GUIStyle();
    }

    public static class EditorGUILayout
    {
        public static string TextField(string label, string text, params GUILayoutOption[] options) => text;

        public static bool Toggle(GUIContent label, bool value, params GUILayoutOption[] options) => value;

        public static bool Toggle(string label, bool value, params GUILayoutOption[] options) => value;

        public static bool ToggleLeft(string label, bool value, params GUILayoutOption[] options) => value;

        public static string PasswordField(string label, string password, params GUILayoutOption[] options) => password;

        public static void LabelField(string label, params GUILayoutOption[] options) { }

        public static void LabelField(string label, GUIStyle style, params GUILayoutOption[] options) { }

        public static void LabelField(string label, string label2, params GUILayoutOption[] options) { }

        public static void HelpBox(string message, MessageType type) { }

        public static bool Foldout(bool foldout, string content) => foldout;

        public static void Space() { }

        public static Rect BeginHorizontal(params GUILayoutOption[] options) => default;

        public static void EndHorizontal() { }

        public static Vector2 BeginScrollView(Vector2 scrollPosition, params GUILayoutOption[] options) => scrollPosition;

        public static void EndScrollView() { }
    }

    public enum BuildTarget
    {
        StandaloneLinux64 = 24,
        Android = 13,
    }

    public static class EditorUserBuildSettings
    {
        public static BuildTarget activeBuildTarget => BuildTarget.Android;
    }

    public static class PlayerSettings
    {
        public static string bundleVersion => "1.0";

        public static string GetScriptingDefineSymbols(UnityEditor.Build.NamedBuildTarget target) => string.Empty;

        public static void SetScriptingDefineSymbols(UnityEditor.Build.NamedBuildTarget target, string defines) { }
    }

    public static class EditorPrefs
    {
        public static string GetString(string key, string defaultValue) => defaultValue;

        public static void SetString(string key, string value) { }

        public static bool GetBool(string key, bool defaultValue) => defaultValue;

        public static void SetBool(string key, bool value) { }
    }

    public static class EditorUtility
    {
        public static void SetDirty(Object target) { }

        public static bool DisplayDialog(string title, string message, string ok) => true;

        public static bool DisplayDialog(string title, string message, string ok, string cancel) => false;

        public static void DisplayProgressBar(string title, string info, float progress) { }

        public static void ClearProgressBar() { }

        public static int DisplayDialogComplex(string title, string message, string ok, string cancel, string alt) => 1;
    }

    public static class Undo
    {
        public static void RecordObject(Object objectToUndo, string name) { }
    }
}

namespace UnityEditor.Build
{
    public readonly struct NamedBuildTarget
    {
        public static NamedBuildTarget Android => default;
        public static NamedBuildTarget Standalone => default;
        public static NamedBuildTarget iOS => default;
    }
}

namespace UnityEditor
{
    public class AssetImporter : UnityEngine.Object
    {
        public string assetPath => string.Empty;

        public void SaveAndReimport() { }
    }

    public sealed class PluginImporter : AssetImporter
    {
        public static PluginImporter[] GetAllImporters() => System.Array.Empty<PluginImporter>();

        public bool GetCompatibleWithPlatform(BuildTarget platform) => false;

        public void SetCompatibleWithPlatform(BuildTarget platform, bool enable) { }
    }
}

namespace UnityEditor
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public sealed class InitializeOnLoadAttribute : System.Attribute
    {
    }

    public static class EditorApplication
    {
        public delegate void CallbackFunction();

        public static CallbackFunction delayCall;

        public static bool isPlayingOrWillChangePlaymode => false;

        public static bool ExecuteMenuItem(string menuItemPath) => false;
    }
}
