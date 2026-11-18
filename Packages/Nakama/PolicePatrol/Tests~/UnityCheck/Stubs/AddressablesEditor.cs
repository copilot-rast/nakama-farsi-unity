using System;
using System.Collections.Generic;

namespace UnityEditor.AddressableAssets.Build
{
    public class AddressablesPlayerBuildResult
    {
        public string Error { get; set; }
    }
}

namespace UnityEditor.AddressableAssets.Settings
{
    using UnityEditor.AddressableAssets.Build;

    public class ProfileValueReference
    {
        public bool SetVariableByName(AddressableAssetSettings settings, string profileVariableName) => true;

        public string GetValue(AddressableAssetSettings settings) => string.Empty;
    }

    public class AddressableAssetProfileSettings
    {
        public List<string> GetVariableNames() => new List<string>();

        public string CreateValue(string variableName, string defaultValue) => string.Empty;

        public void SetValue(string profileId, string variableName, string value) { }
    }

    public class AddressableAssetGroupSchema : UnityEngine.ScriptableObject
    {
    }

    public class AddressableAssetEntry
    {
        public AddressableAssetGroup parentGroup => null;

        public string address { get; set; }

        public bool SetLabel(string label, bool enable, bool force = false, bool postEvent = true) => true;
    }

    public class AddressableAssetGroup : UnityEngine.ScriptableObject
    {
        public string Name => string.Empty;

        public TSchema GetSchema<TSchema>() where TSchema : AddressableAssetGroupSchema => null;

        public TSchema AddSchema<TSchema>(bool postEvent = true) where TSchema : AddressableAssetGroupSchema => null;
    }

    public class AddressableAssetSettings : UnityEngine.ScriptableObject
    {
        public const string kRemoteBuildPath = "Remote.BuildPath";
        public const string kRemoteLoadPath = "Remote.LoadPath";

        public AddressableAssetProfileSettings profileSettings => new AddressableAssetProfileSettings();

        public string activeProfileId { get; set; }

        public bool BuildRemoteCatalog { get; set; }

        public ProfileValueReference RemoteCatalogBuildPath => new ProfileValueReference();

        public ProfileValueReference RemoteCatalogLoadPath => new ProfileValueReference();

        public AddressableAssetGroup FindGroup(string name) => null;

        public List<AddressableAssetGroup> groups => new List<AddressableAssetGroup>();

        public AddressableAssetEntry FindAssetEntry(string guid) => null;

        public AddressableAssetEntry CreateOrMoveEntry(string guid, AddressableAssetGroup targetParent, bool readOnly = false, bool postEvent = true) => null;

        public void AddLabel(string label, bool postEvent = true) { }

        public AddressableAssetGroup CreateGroup(string groupName, bool setAsDefaultGroup, bool readOnly, bool postEvent, List<AddressableAssetGroupSchema> schemasToCopy, params Type[] types) => null;

        public static void BuildPlayerContent(out AddressablesPlayerBuildResult result) => result = new AddressablesPlayerBuildResult();
    }
}

namespace UnityEditor.AddressableAssets.Settings.GroupSchemas
{
    using UnityEditor.AddressableAssets.Settings;

    public class BundledAssetGroupSchema : AddressableAssetGroupSchema
    {
        public enum BundlePackingMode
        {
            PackTogether,
            PackSeparately,
            PackTogetherByLabel,
        }

        public ProfileValueReference BuildPath => new ProfileValueReference();

        public ProfileValueReference LoadPath => new ProfileValueReference();

        public BundlePackingMode BundleMode { get; set; }
    }

    public class ContentUpdateGroupSchema : AddressableAssetGroupSchema
    {
        public bool StaticContent { get; set; }
    }
}

namespace UnityEditor.AddressableAssets
{
    using UnityEditor.AddressableAssets.Settings;

    public static class AddressableAssetSettingsDefaultObject
    {
        public static AddressableAssetSettings GetSettings(bool create) => null;
    }
}
