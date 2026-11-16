#if UNITY_5_3_OR_NEWER
using System.Threading;
using System.Threading.Tasks;
using NakamaFarsi.Sdk.Payments;
using UnityEngine;

namespace NakamaFarsi.Sdk.Unity
{
    public static class NakamaFarsiStore
    {
#if NAKAMAFARSI_STORE_MYKET
        public const string Method = PaymentMethods.Myket;
#else
        public const string Method = PaymentMethods.Bazaar;
#endif
        public const string PluginMissingCode = "STORE_PLUGIN_MISSING";
        public const string NotSupportedCode = "STORE_NOT_SUPPORTED";
        public const string NotSetUpCode = "STORE_NOT_SET_UP";

        public static IStoreBilling Billing { get; private set; }

        public static StoreConfig Config { get; private set; }

        public static void Register(IStoreBilling billing) => Billing = billing;

        public static async Task<IStoreBilling> SetupAsync(NakamaFarsiClient client = null, bool recover = true, CancellationToken ct = default)
        {
            client = client ?? NakamaFarsiRunner.Client;
            Config = await client.Payments.StoreConfigAsync(Method, ct).ConfigureAwait(true);
            var onDevice = Application.platform == RuntimePlatform.Android;
            switch (StoreSelector.Choose(Method, Config, onDevice, onDevice && PluginInstalled()))
            {
                case StoreChoice.TestStore:
                    Register(new TestStoreBilling(Method));
                    break;
                case StoreChoice.Bazaar:
                    Register(new BazaarStoreBilling(Config.RsaPublicKey));
                    break;
                case StoreChoice.Myket:
                    Register(new MyketStoreBilling(Config.RsaPublicKey));
                    break;
                case StoreChoice.PluginMissing:
                    throw new ApiException(new ApiError(PluginMissingCode, 0, PluginMissingMessage()));
                default:
                    throw new ApiException(new ApiError(NotSupportedCode, 0, Method + " billing is not supported on this platform"));
            }

            if (recover)
            {
                await client.Payments.RecoverAsync(Billing, ct).ConfigureAwait(true);
            }

            return Billing;
        }

        public static Task<PurchaseResult> BuyAsync(string productId, NakamaFarsiClient client = null, CancellationToken ct = default)
        {
            client = client ?? NakamaFarsiRunner.Client;
            if (Billing == null)
            {
                throw new ApiException(new ApiError(NotSetUpCode, 0, "call NakamaFarsiStore.SetupAsync first"));
            }

            return client.Payments.BuyAsync(productId, Method, Billing, null, null, null, ct);
        }

        private static bool PluginInstalled() =>
            Method == PaymentMethods.Myket ? MyketBridge.IsInstalled() : PoolakeyBridge.IsInstalled();

        private static string PluginMissingMessage() =>
            Method == PaymentMethods.Myket
                ? "Myket billing is not in this build: choose Tools > Nakama Farsi > Store > Build for Myket and resolve Android dependencies"
                : "Cafe Bazaar billing is not in this build: choose Tools > Nakama Farsi > Store > Install Poolakey (Cafe Bazaar) and resolve Android dependencies";
    }
}
#endif
