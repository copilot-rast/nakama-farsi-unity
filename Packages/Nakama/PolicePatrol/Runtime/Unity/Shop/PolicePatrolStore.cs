using System;
using PolicePatrol.Sdk.Payments;
using PolicePatrol.Sdk.Shop;
using UnityEngine;

namespace PolicePatrol.Sdk.Unity
{
    public static class PolicePatrolStore
    {
#if POLICEPATROL_STORE_MYKET
        public const string Method = PaymentMethods.Myket;
#else
        public const string Method = PaymentMethods.Bazaar;
#endif

        public static IStoreBilling Billing { get; private set; }

        public const string PluginMissingCode = "STORE_PLUGIN_MISSING";
        public const string NotSupportedCode = "STORE_NOT_SUPPORTED_YET";

        public static void Register(IStoreBilling billing) => Billing = billing;

        public static void Setup(Action<ApiResult<IStoreBilling>> onComplete)
        {
            PaymentProvider.StoreConfig(Method, result =>
            {
                if (!result.IsSuccess)
                {
                    onComplete?.Invoke(ApiResult<IStoreBilling>.Fail(result.Error));
                    return;
                }

                var onDevice = Application.platform == RuntimePlatform.Android;
                var choice = StoreSelector.Choose(Method, result.Data, onDevice, onDevice && PluginInstalled());
                switch (choice)
                {
                    case StoreChoice.TestStore:
                        Register(new TestStoreBilling());
                        break;
                    case StoreChoice.Bazaar:
                        Register(new BazaarStoreBilling(result.Data.RsaPublicKey));
                        break;
                    case StoreChoice.Myket:
                        Register(new MyketStoreBilling(result.Data.RsaPublicKey));
                        break;
                    case StoreChoice.PluginMissing:
                        onComplete?.Invoke(ApiResult<IStoreBilling>.Fail(new ApiError(0, PluginMissingCode, null, PluginMissingMessage())));
                        return;
                    default:
                        onComplete?.Invoke(ApiResult<IStoreBilling>.Fail(new ApiError(0, NotSupportedCode, null,
                            Method + " billing is not built into the SDK yet; turn on sandbox in the panel to test with the test store")));
                        return;
                }

                onComplete?.Invoke(ApiResult<IStoreBilling>.Ok(Billing));
            });
        }

        private static bool PluginInstalled() =>
            Method == PaymentMethods.Myket ? MyketBridge.IsInstalled() : PoolakeyBridge.IsInstalled();

        private static string PluginMissingMessage() =>
            Method == PaymentMethods.Myket
                ? "Myket billing is not in this build: choose Tools → PolicePatrol → Store → Build for Myket and resolve Android dependencies"
                : "Cafe Bazaar billing is not in this build: import Poolakey (PoolakeySDKWithExternalDependencyManager.unitypackage) and resolve Android dependencies";

        public static ProductIAP CreateShop() =>
            new ProductIAP(Billing ?? throw new System.InvalidOperationException("Register the " + Method + " store adapter with PolicePatrolStore.Register first"));
    }
}
