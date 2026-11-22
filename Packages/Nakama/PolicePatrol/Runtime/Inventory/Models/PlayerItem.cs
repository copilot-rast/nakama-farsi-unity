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

        public bool SaleStopped { get; init; }

        public string Kind { get; init; }

        public string Description { get; init; }

        public string IconUrl { get; init; }

        public string ImageUrl { get; init; }

        public bool Equipped { get; init; }

        public Newtonsoft.Json.Linq.JObject Metadata { get; init; } = new Newtonsoft.Json.Linq.JObject();

        public Newtonsoft.Json.Linq.JObject Profile { get; init; }

        public CarProfile CarProfile { get; init; }

        public PartProfile PartProfile { get; init; }

        public System.Collections.Generic.IReadOnlyDictionary<string, CarStat> Stats { get; init; } = new System.Collections.Generic.Dictionary<string, CarStat>();

        public System.Collections.Generic.IReadOnlyDictionary<string, string> Installed { get; init; } = new System.Collections.Generic.Dictionary<string, string>();

        public bool IsCar => Kind == ItemKinds.Car;

        public bool IsPart => Kind == ItemKinds.Part;

        public CarStat Stat(string key) => Stats != null && Stats.TryGetValue(key, out var s) ? s : null;
    }
}
