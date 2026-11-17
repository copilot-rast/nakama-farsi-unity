namespace PolicePatrol.Sdk.Inventory
{
    public sealed record PlayerItem(
        string Key,
        string Type,
        string Name,
        string ParentKey,
        string RequiresKey,
        ItemPrice[] Prices,
        int UnlockLevel,
        ItemPrice[] UnlockPrices,
        bool Owned,
        bool Unlocked,
        bool CanBuy,
        int Order,
        PlayerUpgrade[] Upgrades,
        ItemService[] Services);
}
