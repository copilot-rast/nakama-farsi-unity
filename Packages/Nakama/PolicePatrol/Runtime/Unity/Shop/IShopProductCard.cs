using UnityEngine;

namespace PolicePatrol.Sdk.Unity
{
    public interface IShopProductCard
    {
        string ProductKey { get; }

        string Title { get; }

        string Description { get; }

        string PurchaseMessage { get; }

        bool IsOneTime { get; }

        Object Icon { get; }

        Object Cover { get; }
    }
}
