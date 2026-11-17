using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Unity;
using UnityEditor;
using UnityEngine;

namespace PolicePatrol.Sdk.Editor
{
    public static class ShopCardScanner
    {
        public static ShopCardScan Scan()
        {
            var scan = new ShopCardScan();
            var seen = new Dictionary<string, string>(StringComparer.Ordinal);
            var paths = TypeCache.GetTypesDerivedFrom<IShopProductCard>()
                .Where(type => typeof(ScriptableObject).IsAssignableFrom(type) && !type.IsAbstract)
                .SelectMany(type => AssetDatabase.FindAssets("t:" + type.Name))
                .Distinct()
                .Select(AssetDatabase.GUIDToAssetPath);

            foreach (var path in paths)
            {
                if (!(AssetDatabase.LoadMainAssetAtPath(path) is IShopProductCard card))
                {
                    continue;
                }

                var key = (card.ProductKey ?? string.Empty).Trim();
                if (key.Length == 0)
                {
                    scan.Problems.Add(path + ": the product key is empty");
                    continue;
                }

                if (seen.TryGetValue(key, out var other))
                {
                    scan.Problems.Add("\"" + key + "\" is used by both " + other + " and " + path);
                    continue;
                }

                seen[key] = path;
                scan.Items.Add(new JObject
                {
                    ["key"] = key,
                    ["title"] = card.Title ?? string.Empty,
                    ["description"] = card.Description ?? string.Empty,
                    ["purchaseMessage"] = card.PurchaseMessage ?? string.Empty,
                    ["isOneTime"] = card.IsOneTime,
                    ["iconAddress"] = Address(card.Icon, "icon", path, scan),
                    ["coverAddress"] = Address(card.Cover, "cover", path, scan),
                });
            }

            return scan;
        }

        private static string Address(UnityEngine.Object image, string field, string path, ShopCardScan scan)
        {
            var address = ShopCardAddresses.Of(image);
            if (image != null && string.IsNullOrEmpty(address))
            {
                scan.Warnings.Add(path + ": the " + field + " is not Addressable, so its address on the server stays as it is");
            }

            return address;
        }
    }
}
