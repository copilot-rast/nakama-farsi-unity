using System.Collections.Generic;
using System.Linq;

namespace PolicePatrol.Sdk.Inventory
{
    public sealed record PlayerInventory(int Level, PlayerItem[] Items)
    {
        public IReadOnlyDictionary<string, string> Equipped { get; init; } = new Dictionary<string, string>();

        public int OwnedCount { get; init; }

        public int TotalCount { get; init; }

        public PlayerItem Find(string itemKey) => Items?.FirstOrDefault(i => i.Key == itemKey);

        public PlayerItem[] Cars => (Items ?? new PlayerItem[0]).Where(i => i.IsCar).ToArray();

        public PlayerItem[] PartsOf(string carKey) => (Items ?? new PlayerItem[0]).Where(i => i.IsPart && i.ParentKey == carKey).ToArray();
    }
}
