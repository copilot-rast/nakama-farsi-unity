using System;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;
using UnityEngine.AddressableAssets;

namespace PolicePatrol.Sdk.Editor
{
    public static class AddressablesSetup
    {
        public const string RemoteGroupName = "PolicePatrol Remote";
        public const string RemoteBuildPath = "ServerData/[BuildTarget]";

        public static AddressableAssetSettings Settings =>
            AddressableAssetSettingsDefaultObject.GetSettings(true)
            ?? throw new InvalidOperationException("Addressables settings could not be created. Open Window > Asset Management > Addressables > Groups once.");

        public static string Configure(string url)
        {
            var settings = Settings;
            var profiles = settings.profileSettings;
            var loadPath = url.Trim().StartsWith("{") ? url.Trim() : url.Trim().TrimEnd('/') + "/[BuildTarget]";
            EnsureVariable(profiles, AddressableAssetSettings.kRemoteBuildPath, RemoteBuildPath);
            EnsureVariable(profiles, AddressableAssetSettings.kRemoteLoadPath, loadPath);
            profiles.SetValue(settings.activeProfileId, AddressableAssetSettings.kRemoteBuildPath, RemoteBuildPath);
            profiles.SetValue(settings.activeProfileId, AddressableAssetSettings.kRemoteLoadPath, loadPath);

            settings.BuildRemoteCatalog = true;
            settings.RemoteCatalogBuildPath.SetVariableByName(settings, AddressableAssetSettings.kRemoteBuildPath);
            settings.RemoteCatalogLoadPath.SetVariableByName(settings, AddressableAssetSettings.kRemoteLoadPath);

            var group = RemoteGroup(settings, RemoteGroupName);
            EditorUtility.SetDirty(settings);
            AssetDatabase.SaveAssets();
            return "Addressables now load remote content from " + loadPath + ". Put content in the \"" + group.Name + "\" group (or any group whose paths are Remote).";
        }

        public static AssetReference MakeRemote(UnityEngine.Object asset, string groupName, string label, bool packTogether)
        {
            var path = AssetDatabase.GetAssetPath(asset);
            var guid = string.IsNullOrEmpty(path) ? null : AssetDatabase.AssetPathToGUID(path);
            if (string.IsNullOrEmpty(guid))
            {
                return null;
            }

            var settings = Settings;
            var group = settings.FindGroup(groupName) ?? RemoteGroup(settings, groupName, packTogether);
            var entry = settings.FindAssetEntry(guid);
            if (entry == null || entry.parentGroup != group)
            {
                entry = settings.CreateOrMoveEntry(guid, group, false, false);
            }

            if (!string.IsNullOrEmpty(label))
            {
                settings.AddLabel(label, false);
                entry.SetLabel(label, true, true, false);
            }

            var reference = new AssetReference(guid);
            if (AssetDatabase.LoadMainAssetAtPath(path) != asset)
            {
                reference.SetEditorSubObject(asset);
            }

            return reference;
        }

        public static void SaveAll()
        {
            var settings = Settings;
            EditorUtility.SetDirty(settings);
            foreach (var group in settings.groups)
            {
                EditorUtility.SetDirty(group);
            }

            AssetDatabase.SaveAssets();
        }

        public static AddressableAssetGroup RemoteGroup(AddressableAssetSettings settings, string name, bool packTogether = false)
        {
            var group = settings.FindGroup(name)
                ?? settings.CreateGroup(name, false, false, true, null, typeof(BundledAssetGroupSchema), typeof(ContentUpdateGroupSchema));
            var bundled = group.GetSchema<BundledAssetGroupSchema>() ?? group.AddSchema<BundledAssetGroupSchema>();
            bundled.BuildPath.SetVariableByName(settings, AddressableAssetSettings.kRemoteBuildPath);
            bundled.LoadPath.SetVariableByName(settings, AddressableAssetSettings.kRemoteLoadPath);
            bundled.BundleMode = packTogether ? BundledAssetGroupSchema.BundlePackingMode.PackTogether : BundledAssetGroupSchema.BundlePackingMode.PackSeparately;
            var update = group.GetSchema<ContentUpdateGroupSchema>() ?? group.AddSchema<ContentUpdateGroupSchema>();
            update.StaticContent = false;
            EditorUtility.SetDirty(group);
            return group;
        }

        private static void EnsureVariable(AddressableAssetProfileSettings profiles, string name, string value)
        {
            if (!profiles.GetVariableNames().Contains(name))
            {
                profiles.CreateValue(name, value);
            }
        }
    }
}
