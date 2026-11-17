using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Unity;
using UnityEditor;
using UnityEngine;

namespace PolicePatrol.Sdk.Editor
{
    public static class StatCardScanner
    {
        public static StatCardScan Scan()
        {
            var scan = new StatCardScan();
            Collect<IStatCard>(scan, scan.Stats, card => card.StatKey, StatCardJson.Stat);
            Collect<IGoalCard>(scan, scan.Goals, card => card.GoalKey, StatCardJson.Goal);
            return scan;
        }

        private static void Collect<T>(StatCardScan scan, JArray target, Func<T, string> keyOf, Func<T, JObject> write)
            where T : class
        {
            var seen = new Dictionary<string, string>(StringComparer.Ordinal);
            var paths = TypeCache.GetTypesDerivedFrom<T>()
                .Where(type => typeof(ScriptableObject).IsAssignableFrom(type) && !type.IsAbstract)
                .SelectMany(type => AssetDatabase.FindAssets("t:" + type.Name))
                .Distinct()
                .Select(AssetDatabase.GUIDToAssetPath);

            foreach (var path in paths)
            {
                if (!(AssetDatabase.LoadMainAssetAtPath(path) is T card))
                {
                    continue;
                }

                var key = (keyOf(card) ?? string.Empty).Trim();
                if (key.Length == 0)
                {
                    scan.Problems.Add(path + ": the key is empty");
                    continue;
                }

                if (seen.TryGetValue(key, out var other))
                {
                    scan.Problems.Add("\"" + key + "\" is used by both " + other + " and " + path);
                    continue;
                }

                seen[key] = path;
                target.Add(write(card));
            }
        }
    }
}
