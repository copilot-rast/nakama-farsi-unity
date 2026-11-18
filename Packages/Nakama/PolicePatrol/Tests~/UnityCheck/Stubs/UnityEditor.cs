using System;

namespace UnityEditor
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class MenuItem : Attribute
    {
        public MenuItem(string itemName) { }

        public MenuItem(string itemName, bool isValidateFunction) { }
    }

    public static class AssetDatabase
    {
        public static T LoadAssetAtPath<T>(string assetPath) where T : UnityEngine.Object => null;

        public static string[] FindAssets(string filter) => new string[0];

        public static string[] FindAssets(string filter, string[] searchInFolders) => new string[0];

        public static string GUIDToAssetPath(string guid) => string.Empty;

        public static string AssetPathToGUID(string path) => string.Empty;

        public static string GetAssetPath(UnityEngine.Object assetObject) => string.Empty;

        public static UnityEngine.Object LoadMainAssetAtPath(string assetPath) => null;

        public static UnityEngine.Object[] LoadAllAssetsAtPath(string assetPath) => new UnityEngine.Object[0];

        public static bool IsValidFolder(string path) => false;

        public static bool TryGetGUIDAndLocalFileIdentifier(UnityEngine.Object obj, out string guid, out long localId)
        {
            guid = null;
            localId = 0;
            return false;
        }

        public static string CreateFolder(string parentFolder, string newFolderName) => string.Empty;

        public static void CreateAsset(UnityEngine.Object asset, string path) { }

        public static void SaveAssets() { }

        public static void Refresh() { }

        public static void ImportPackage(string packagePath, bool interactive) { }

        public static string MoveAsset(string oldPath, string newPath) => string.Empty;

        public static bool DeleteAsset(string path) => true;

        public static string[] GetAllAssetPaths() => new string[0];
    }

    public static class TypeCache
    {
        public static System.Collections.Generic.IList<Type> GetTypesDerivedFrom<T>() => new Type[0];
    }

    public static class Selection
    {
        public static UnityEngine.Object activeObject { get; set; }
    }

    public static class EditorGUIUtility
    {
        public static void PingObject(UnityEngine.Object obj) { }
    }
}

namespace UnityEditor.Android
{
    public interface IPostGenerateGradleAndroidProject
    {
        int callbackOrder { get; }

        void OnPostGenerateGradleAndroidProject(string path);
    }
}
