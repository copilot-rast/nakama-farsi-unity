using System;

namespace PolicePatrol.Sdk.Editor
{
    public static class ShopCardAddresses
    {
        public static Func<UnityEngine.Object, string> Resolver { get; set; }

        public static string Of(UnityEngine.Object image) =>
            image == null || Resolver == null ? null : Resolver(image);
    }
}
