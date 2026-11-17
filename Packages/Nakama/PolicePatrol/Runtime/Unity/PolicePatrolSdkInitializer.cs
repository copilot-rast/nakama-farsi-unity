using NakamaFarsi.Sdk.Unity;
using UnityEngine;

namespace PolicePatrol.Sdk.Unity
{
    public static class PolicePatrolSdkInitializer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void InitializeFromConfig()
        {
            var config = PolicePatrolSdkConfig.Load();
            if (config == null)
            {
                Debug.LogError($"[PolicePatrol.Sdk] {PolicePatrolSdkConfig.ResourceName} was not found in a Resources folder. Create it with Tools > PolicePatrol > Create SDK Config.");
                return;
            }

            Initialize(config);
        }

        public static ApiClient Initialize(PolicePatrolSdkConfig config)
        {
            var options = config.ToOptions();
            var core = NakamaFarsiRunner.Initialize(PolicePatrolSdk.CoreOptions(options), config.AnalyticsSessions);
            return PolicePatrolSdk.Initialize(options, core, new UnityLogger());
        }
    }
}
