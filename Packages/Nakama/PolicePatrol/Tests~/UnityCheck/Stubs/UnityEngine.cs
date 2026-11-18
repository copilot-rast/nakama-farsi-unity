using System;

namespace UnityEngine
{
    public class Object
    {
        public string name { get; set; }

        public HideFlags hideFlags { get; set; }

        public static void DontDestroyOnLoad(Object target) { }

        public static void Destroy(Object target) { }
    }

    public enum HideFlags
    {
        None = 0,
        HideAndDontSave = 61,
    }

    public sealed class Coroutine
    {
    }

    public sealed class GameObject : Object
    {
        public GameObject(string name) { }

        public T AddComponent<T>() where T : Component => null;
    }

    public class Component : Object
    {
    }

    public class Behaviour : Component
    {
    }

    public class MonoBehaviour : Behaviour
    {
        public System.Threading.CancellationToken destroyCancellationToken => default;

        public Coroutine StartCoroutine(System.Collections.IEnumerator routine) => null;
    }

    public class CustomYieldInstruction
    {
    }

    public class WaitForSecondsRealtime : CustomYieldInstruction
    {
        public WaitForSecondsRealtime(float time) { }
    }

    public static class Application
    {
        public static event Events.UnityAction<string> deepLinkActivated;

        public static string persistentDataPath => string.Empty;

        public static bool isEditor => false;

        public static RuntimePlatform platform => RuntimePlatform.OSXEditor;

        public static string dataPath => string.Empty;

        public static string absoluteURL => string.Empty;

        public static string version => "0.0.0";

        public static string buildGUID => string.Empty;

        public static void OpenURL(string url) { }

        internal static void ActivateDeepLink(string url) => deepLinkActivated?.Invoke(url);
    }

    public static class JsonUtility
    {
        public static void FromJsonOverwrite(string json, object objectToOverwrite) { }

        public static string ToJson(object obj) => "{}";
    }

    public static class SystemInfo
    {
        public static string deviceUniqueIdentifier => string.Empty;

        public static string operatingSystem => string.Empty;

        public static string deviceModel => string.Empty;
    }

    public class ScriptableObject : Object
    {
        public static T CreateInstance<T>() where T : ScriptableObject => throw new NotSupportedException();
    }

    public class AsyncOperation
    {
        public event Action<AsyncOperation> completed;

        internal void Raise() => completed?.Invoke(this);
    }

    public static class Debug
    {
        public static bool isDebugBuild => true;

        public static void Log(object message) { }

        public static void LogWarning(object message) { }

        public static void LogError(object message) { }

        public static void LogException(System.Exception exception) { }
    }

    public static class Resources
    {
        public static T Load<T>(string path) where T : Object => null;
    }

    public static class Time
    {
        public static float realtimeSinceStartup => 0f;

        public static float unscaledDeltaTime => 0.02f;

        public static float deltaTime => 0.02f;
    }

    public static class PlayerPrefs
    {
        public static string GetString(string key, string defaultValue) => defaultValue;

        public static string GetString(string key) => string.Empty;

        public static void SetString(string key, string value) { }

        public static void DeleteKey(string key) { }

        public static bool HasKey(string key) => false;

        public static void Save() { }
    }

    public enum RuntimeInitializeLoadType
    {
        BeforeSceneLoad,
    }

    [AttributeUsage(AttributeTargets.Method)]
    public sealed class RuntimeInitializeOnLoadMethodAttribute : Attribute
    {
        public RuntimeInitializeOnLoadMethodAttribute(RuntimeInitializeLoadType loadType) { }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class CreateAssetMenuAttribute : Attribute
    {
        public string fileName { get; set; }

        public string menuName { get; set; }

        public int order { get; set; }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public sealed class SerializeField : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field)]
    public sealed class MinAttribute : Attribute
    {
        public MinAttribute(float min) { }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class ContextMenu : Attribute
    {
        public ContextMenu(string itemName) { }
    }
}

namespace UnityEngine
{
    public enum RuntimePlatform
    {
        OSXEditor = 0,
        WindowsEditor = 7,
        IPhonePlayer = 8,
        Android = 11,
        LinuxEditor = 16,
    }

    public class AndroidJavaObject : System.IDisposable
    {
        public AndroidJavaObject(string className, params object[] args) { }

        public void Call(string methodName, params object[] args) { }

        public T Call<T>(string methodName, params object[] args) => default;

        public T Get<T>(string fieldName) => default;

        public T CallStatic<T>(string methodName, params object[] args) => default;

        public T GetStatic<T>(string fieldName) => default;

        public void Dispose() { }
    }

    public class AndroidJavaClass : AndroidJavaObject
    {
        public AndroidJavaClass(string className) : base(className) { }
    }

    public class AndroidJavaProxy
    {
        public AndroidJavaProxy(string javaInterface) { }
    }
}
