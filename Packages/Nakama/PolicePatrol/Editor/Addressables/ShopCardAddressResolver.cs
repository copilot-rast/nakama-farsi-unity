using UnityEditor;
using UnityEditor.AddressableAssets;

namespace PolicePatrol.Sdk.Editor
{
    [InitializeOnLoad]
    public static class ShopCardAddressResolver
    {
        static ShopCardAddressResolver()
        {
            ShopCardAddresses.Resolver = Resolve;
        }

        private static string Resolve(UnityEngine.Object image)
        {
            var settings = AddressableAssetSettingsDefaultObject.GetSettings(false);
            var path = AssetDatabase.GetAssetPath(image);
            if (settings == null || string.IsNullOrEmpty(path))
            {
                return null;
            }

            return settings.FindAssetEntry(AssetDatabase.AssetPathToGUID(path))?.address;
        }
    }
}
