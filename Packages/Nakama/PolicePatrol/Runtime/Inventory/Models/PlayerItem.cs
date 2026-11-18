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
        ItemService[] Services)
    {
        private ItemPrice[] _finalPrices;

        public ItemPrice[] FinalPrices
        {
            get => _finalPrices ?? Prices;
            init => _finalPrices = value;
        }

        public double DiscountPercent { get; init; }

        public bool HasDiscount => DiscountPercent > 0;
    }
}
