using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Catalog;
using PolicePatrol.Sdk.Payments;
using PolicePatrol.Sdk.Prizes;

namespace PolicePatrol.Sdk.Shop
{
    public static class ShopProvider
    {
        public static void List(ListQuery query, string[] tagIds, string[] categoryIds, Action<ApiResult<PagedResult<Product>>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var all = await Products(c).ConfigureAwait(false);
                var rows = all.Where(p => (tagIds == null || tagIds.Length == 0 || (p.TagIds ?? Array.Empty<string>()).Intersect(tagIds).Any())
                    && (categoryIds == null || categoryIds.Length == 0 || categoryIds.Contains(p.CategoryId))
                    && (string.IsNullOrEmpty(query?.SearchInput) || (p.Name ?? string.Empty).IndexOf(query.SearchInput, StringComparison.OrdinalIgnoreCase) >= 0)).ToArray();
                var size = Math.Max(1, query?.LimitItem ?? 10);
                var page = Math.Max(1, query?.PageNum ?? 1);
                return new PagedResult<Product>(rows.Skip((page - 1) * size).Take(size).ToArray(), rows.Length, page, size);
            }, ErrorAliases.Payments, "economy_catalog");

        public static void Purchases(Action<ApiResult<ProductPurchase[]>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var r = await c.Rpc("economy_purchases_mine", new JObject(), true).ConfigureAwait(false);
                return Mapping.Each(r, "items", i => new ProductPurchase(J.Str(i, "productId"), J.Str(i, "key"), J.Int(i, "count"), J.TimeOr(i, "lastPurchasedAt")));
            }, ErrorAliases.Payments, "economy_purchases_mine");

        public static void Get(string id, Action<ApiResult<Product>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, c => Find(c, id), ErrorAliases.Payments, "economy_catalog");

        public static void Buy(string id, Action<ApiResult<InitiatePaymentResult>> onComplete) =>
            PaymentProvider.Initiate(id, PaymentMethods.Zarrinpal, onComplete);

        internal static async Task<Product> Find(ApiClient c, string idOrKey)
        {
            var all = await Products(c).ConfigureAwait(false);
            return all.FirstOrDefault(p => p.Id == idOrKey || p.Key == idOrKey)
                ?? throw new SdkFailure(new ApiError(404, "PAYMENT_PRODUCT_WITH_ID_NOT_FOUND", new JObject { ["id"] = idOrKey }, string.Empty));
        }

        internal static async Task<Product[]> Products(ApiClient c)
        {
            var r = await c.Rpc("economy_catalog", new JObject { ["lang"] = c.Language }, true).ConfigureAwait(false);
            var lang = J.Str(r, "lang") ?? c.Language;
            return Mapping.Arr(r, "products").Select(p => ToProduct(c, p, lang)).ToArray();
        }

        internal static Product ToProduct(ApiClient c, JToken p, string lang)
        {
            var price = J.Num(p, "priceToman");
            var final = J.NumOrNull(p, "finalToman") ?? price;
            var sku = new Dictionary<string, string>(StringComparer.Ordinal);
            if (p?["sku"] is JObject skus)
            {
                foreach (var s in skus.Properties())
                {
                    sku[s.Name] = (string)s.Value;
                }
            }

            var items = Mapping.Arr(p, "items").Select(i => i.Type == JTokenType.String
                    ? new PrizeItem(PrizeItemTypes.InventoryItem, c.Items.ToGame((string)i), null, "add", 1)
                    : new PrizeItem(J.Str(i, "type") ?? PrizeItemTypes.InventoryItem, c.Items.ToGame(J.Str(i, "key", "itemId")), null, J.Str(i, "action") ?? "add", i["value"]))
                .ToArray();
            var id = J.Str(p, "id");
            var name = J.Str(p, "name");
            var prize = new Prize(id, name, null, J.Str(p, "purchaseMessage"), null, J.Str(p, "categoryKey"), null, null, null, !J.Bool(p, "isOneTime"), items, null, null, DateTimeOffset.MinValue, DateTimeOffset.MinValue);
            LocalizedValue[] One(string v) => string.IsNullOrEmpty(v) ? null : new[] { new LocalizedValue(lang, v) };
            var media = J.Str(p, "mediaSource") ?? ProductMediaSources.Upload;
            return new Product(
                id,
                name,
                J.Str(p, "key"),
                true,
                J.Num(p, "discountPercent"),
                final,
                null,
                null,
                J.Str(p, "categoryKey"),
                null,
                Mapping.Arr(p, "tags").Select(t => (string)t).ToArray(),
                null,
                new ProductPrice("IRT", price, null),
                Mapping.Arr(p, "paymentMethods").Select(m => (string)m).ToArray(),
                sku,
                J.Bool(p, "isSubscription"),
                id,
                prize,
                Mapping.Arr(p, "assetIds").Select(a => (string)a).ToArray(),
                One(name),
                One(J.Str(p, "description")),
                DateTimeOffset.MinValue,
                DateTimeOffset.MinValue,
                One(J.Str(p, "purchaseMessage")),
                media,
                J.Str(p, "mediaAssetId"),
                string.IsNullOrEmpty(J.Str(p, "iconUrl")) ? null : new ProductMedia(null, null, J.Str(p, "iconUrl")),
                string.IsNullOrEmpty(J.Str(p, "coverUrl")) ? null : new ProductMedia(null, null, J.Str(p, "coverUrl")),
                J.Int(p, "minLevel"),
                J.Num(p, "discountPercent") > 0,
                p?["maxLevel"] != null && J.Int(p, "maxLevel") > 0 ? (int?)J.Int(p, "maxLevel") : null,
                p?["owned"]?.Type == JTokenType.Boolean ? (bool?)(bool)p["owned"] : J.Bool(p, "bought") ? true : (bool?)null,
                p?["levelLocked"]?.Type == JTokenType.Boolean ? (bool?)(bool)p["levelLocked"] : null,
                J.Bool(p, "isOneTime"),
                false,
                J.Str(p, "iconAddress"),
                J.Str(p, "coverAddress"));
        }
    }
}
