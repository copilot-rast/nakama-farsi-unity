using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Inventory
{
    public static class InventoryProvider
    {
        public static void Get(Action<ApiResult<PlayerInventory>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, Load, ErrorAliases.Inventory, "economy_inventory");

        private static readonly ConcurrentDictionary<string, string> Retries = new ConcurrentDictionary<string, string>(StringComparer.Ordinal);

        public static void Buy(string itemKey, Action<ApiResult<ItemChange>> onComplete) => Buy(itemKey, onComplete, null);

        public static void Buy(string itemKey, Action<ApiResult<ItemChange>> onComplete, string requestId)
        {
            var id = Reuse("buy|" + itemKey, requestId, ref onComplete);
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var key = c.Items.ToServer(itemKey);
                var answer = await c.Rpc("economy_item_buy", new JObject { ["key"] = key, ["requestId"] = id, ["lang"] = c.Language }, false, true).ConfigureAwait(false);
                return new ItemChange(Item(c, answer?["item"]), Paid(answer));
            }, ErrorAliases.Inventory, "economy_item_buy");
        }

        public static void Unlock(string itemKey, Action<ApiResult<ItemChange>> onComplete) => Unlock(itemKey, onComplete, null);

        public static void Unlock(string itemKey, Action<ApiResult<ItemChange>> onComplete, string requestId)
        {
            var id = Reuse("unlock|" + itemKey, requestId, ref onComplete);
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var key = c.Items.ToServer(itemKey);
                var answer = await c.Rpc("inventoryx_unlock", new JObject { ["key"] = key, ["requestId"] = id, ["lang"] = c.Language }, false, true).ConfigureAwait(false);
                return new ItemChange(await Fresh(c, key, answer?["item"]).ConfigureAwait(false), Paid(answer));
            }, ErrorAliases.Inventory, "inventoryx_unlock");
        }

        public static void Upgrade(string itemKey, string upgrade, int? fromLevel, Action<ApiResult<UpgradeChange>> onComplete) => Upgrade(itemKey, upgrade, fromLevel, onComplete, null);

        public static void Upgrade(string itemKey, string upgrade, int? fromLevel, Action<ApiResult<UpgradeChange>> onComplete, string requestId)
        {
            var id = Reuse("upgrade|" + itemKey + "|" + upgrade + "|" + fromLevel, requestId, ref onComplete);
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var key = c.Items.ToServer(itemKey);
                var body = new JObject { ["key"] = key, ["track"] = upgrade, ["requestId"] = id, ["lang"] = c.Language };
                if (fromLevel.HasValue)
                {
                    body["fromLevel"] = fromLevel.Value;
                }

                var answer = await c.Rpc("inventoryx_upgrade", body, false, true).ConfigureAwait(false);
                var item = await Fresh(c, key, answer?["item"]).ConfigureAwait(false);
                var level = item.Upgrades?.FirstOrDefault(u => u.Key == upgrade)?.Level
                    ?? J.Int(Mapping.Arr(answer?["item"], "tracks").FirstOrDefault(t => J.Str(t, "key") == upgrade), "level");
                return new UpgradeChange(item, upgrade, level, Paid(answer));
            }, ErrorAliases.Inventory, "inventoryx_upgrade");
        }

        public static void Service(string itemKey, string service, int units, string requestId, Action<ApiResult<ServiceResult>> onComplete)
        {
            var id = Reuse("service|" + itemKey + "|" + service + "|" + units, requestId, ref onComplete);
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var body = new JObject { ["key"] = c.Items.ToServer(itemKey), ["service"] = service, ["units"] = units, ["requestId"] = id, ["lang"] = c.Language };
                var answer = await c.Rpc("economy_item_use", body, false, true).ConfigureAwait(false);
                return new ServiceResult(itemKey, J.Str(answer, "service") ?? service, J.Int(answer, "units", units), Paid(answer));
            }, ErrorAliases.Inventory, "economy_item_use");
        }

        public static bool IsRetryable(ApiError error) =>
            error != null && (error.IsNetworkError || error.Status == 429 || error.Status >= 500 || error.Code == InventoryErrorCodes.Busy);

        private static string Reuse<T>(string action, string requestId, ref Action<ApiResult<T>> onComplete)
        {
            if (!string.IsNullOrEmpty(requestId))
            {
                return requestId;
            }

            var id = Retries.GetOrAdd(action, _ => Guid.NewGuid().ToString("N"));
            var done = onComplete;
            onComplete = result =>
            {
                if (result.IsSuccess || !IsRetryable(result.Error))
                {
                    ((ICollection<KeyValuePair<string, string>>)Retries).Remove(new KeyValuePair<string, string>(action, id));
                }

                done?.Invoke(result);
            };
            return id;
        }

        internal static async Task<PlayerInventory> Load(ApiClient c)
        {
            var inv = await c.Rpc("economy_inventory", new JObject { ["lang"] = c.Language }, true).ConfigureAwait(false);
            var items = Mapping.Arr(inv, "items");
            foreach (var i in items)
            {
                c.Items.LearnItem(i);
            }

            return new PlayerInventory(J.Int(inv, "level"), items.Select(i => Item(c, i)).ToArray());
        }

        private static async Task<PlayerItem> Fresh(ApiClient c, string key, JToken fallback)
        {
            try
            {
                var inv = await Load(c).ConfigureAwait(false);
                var gameKey = c.Items.ToGame(key);
                return inv.Items.FirstOrDefault(i => i.Key == gameKey) ?? Item(c, fallback);
            }
            catch (Exception)
            {
                return Item(c, fallback);
            }
        }

        internal static ItemPrice[] Paid(JToken answer) => Mapping.Each(answer, "paid", Price);

        internal static ItemPrice Price(JToken p) => new ItemPrice(Mapping.CurrencyKey(p), Mapping.Amount(p));

        internal static PlayerItem Item(ApiClient c, JToken i)
        {
            if (i == null || i.Type != JTokenType.Object)
            {
                return null;
            }

            var key = c.Items.LearnItem(i);
            var price = i["price"];
            var prices = price is JObject po ? new[] { Price(po) } : price is JArray pa ? pa.Select(Price).ToArray() : Array.Empty<ItemPrice>();
            var tracks = Mapping.Arr(i, "tracks");
            PlayerUpgrade[] upgrades;
            if (tracks.Count > 0)
            {
                upgrades = tracks.Select(t => new PlayerUpgrade(
                    J.Str(t, "key"),
                    J.Str(t, "name") ?? J.Str(t, "key"),
                    J.Int(t, "level"),
                    J.Int(t, "maxLevel"),
                    t["nextPrice"] is JObject np ? Price(np) : null)).ToArray();
            }
            else if (J.Int(i, "maxUpgradeLevel") > 0)
            {
                upgrades = new[] { new PlayerUpgrade("level", "Level", J.Int(i, "upgradeLevel"), J.Int(i, "maxUpgradeLevel"), i["nextUpgradePrice"] is JObject np ? Price(np) : null) };
            }
            else
            {
                upgrades = Array.Empty<PlayerUpgrade>();
            }

            var services = Mapping.Each(i, "services", s => new ItemService(J.Str(s, "key"), J.Str(s, "name") ?? J.Str(s, "key"), Mapping.CurrencyKey(s), J.Num(s, "unitPrice"), J.Int(s, "maxUnits")));
            return new PlayerItem(
                key,
                J.Str(i, "type"),
                J.Str(i, "name"),
                c.Items.ToGame(J.Str(i, "parentKey")),
                c.Items.ToGame(J.Str(i, "requiresKey")),
                prices,
                J.Int(i, "unlockLevel"),
                Mapping.Each(i, "unlockPrices", Price),
                J.Bool(i, "owned"),
                i["unlocked"] != null ? J.Bool(i, "unlocked") : !J.Bool(i, "locked"),
                J.Bool(i, "canBuy"),
                J.Int(i, "sort"),
                upgrades,
                services)
            {
                FinalPrices = i["finalPrice"] is JObject fo ? new[] { Price(fo) } : i["finalPrice"] is JArray fa ? fa.Select(Price).ToArray() : null,
                DiscountPercent = J.Num(i, "discountPercent"),
            };
        }
    }
}
