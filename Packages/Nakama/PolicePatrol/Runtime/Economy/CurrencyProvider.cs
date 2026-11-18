using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Economy
{
    public static class CurrencyProvider
    {
        public const string ServerOnlyCode = "CURRENCY_IS_SERVER_ONLY";

        public static void List(int pageNum, int limitItem, Action<ApiResult<PagedResult<UserCurrency>>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var all = await Balances(c).ConfigureAwait(false);
                var size = Math.Max(1, limitItem);
                var page = Math.Max(1, pageNum);
                return new PagedResult<UserCurrency>(all.Skip((page - 1) * size).Take(size).ToArray(), all.Length, page, size);
            }, null, "economy_balances");

        public static void GetByKey(string key, Action<ApiResult<UserCurrency>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var all = await Balances(c).ConfigureAwait(false);
                return all.FirstOrDefault(x => x.Currency.Key == key) ?? Mapping.UserCurrency(c.Core.Session.UserId, key, 0, null);
            }, null, "economy_balances");

        public static void Add(string currencyId, double value, Action<ApiResult<UserCurrency>> onComplete = null) =>
            onComplete?.Invoke(ApiResult<UserCurrency>.Fail(new ApiError(403, ServerOnlyCode, new JObject { ["currency"] = currencyId }, "Currencies change only on the server")));

        public static void Use(string currencyId, double value, Action<ApiResult<UserCurrency>> onComplete = null) =>
            onComplete?.Invoke(ApiResult<UserCurrency>.Fail(new ApiError(403, ServerOnlyCode, new JObject { ["currency"] = currencyId }, "Currencies change only on the server; use InventoryProvider.Service for services")));

        internal static async Task<UserCurrency[]> Balances(ApiClient c)
        {
            var b = await c.Rpc("economy_balances", new JObject(), true).ConfigureAwait(false);
            var user = c.Core.Session.UserId;
            return (b?["wallet"] as JObject ?? new JObject()).Properties()
                .Select(p => Mapping.UserCurrency(user, p.Name, p.Value.Type == JTokenType.Integer || p.Value.Type == JTokenType.Float ? (double)p.Value : 0, null)).ToArray();
        }
    }
}
