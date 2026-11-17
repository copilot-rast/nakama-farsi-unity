using PolicePatrol.Sdk.Payments;

namespace PolicePatrol.Sdk.Shop
{
    public static class StoreSelector
    {
        public static StoreChoice Choose(string method, StoreConfig config, bool onAndroidDevice, bool storePluginInstalled)
        {
            if (config == null || config.Sandbox || !onAndroidDevice)
            {
                return StoreChoice.TestStore;
            }

            StoreChoice store;
            switch (method)
            {
                case PaymentMethods.Bazaar:
                    store = StoreChoice.Bazaar;
                    break;
                case PaymentMethods.Myket:
                    store = StoreChoice.Myket;
                    break;
                default:
                    return StoreChoice.Unsupported;
            }

            return storePluginInstalled ? store : StoreChoice.PluginMissing;
        }
    }
}
