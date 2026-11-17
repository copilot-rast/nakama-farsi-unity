using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Economy
{
    public static class MetaProvider
    {
        public const string ServerOnlyCode = "META_IS_SERVER_ONLY";

        public static void List(int pageNum, int limitItem, Action<ApiResult<PagedResult<UserMeta>>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var all = await Metas(c).ConfigureAwait(false);
                var size = Math.Max(1, limitItem);
                var page = Math.Max(1, pageNum);
                return new PagedResult<UserMeta>(all.Skip((page - 1) * size).Take(size).ToArray(), all.Length, page, size);
            }, null, "economy_balances");

        public static void GetByKey(string key, Action<ApiResult<UserMeta>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var all = await Metas(c).ConfigureAwait(false);
                return all.FirstOrDefault(x => x.Meta.Key == key) ?? Mapping.UserMeta(c.Core.Session.UserId, key, 0);
            }, null, "economy_balances");

        public static void Add(string metaId, double value, Action<ApiResult<UserMeta>> onComplete = null) =>
            onComplete?.Invoke(ApiResult<UserMeta>.Fail(new ApiError(403, ServerOnlyCode, new JObject { ["meta"] = metaId }, "Metas change only on the server")));

        public static void Set(string metaId, double value, Action<ApiResult<UserMeta>> onComplete = null) => Add(metaId, value, onComplete);

        internal static async Task<UserMeta[]> Metas(ApiClient c)
        {
            var b = await c.Rpc("economy_balances", new JObject(), true).ConfigureAwait(false);
            var user = c.Core.Session.UserId;
            return (b?["metas"] as JObject ?? new JObject()).Properties()
                .Select(p => Mapping.UserMeta(user, p.Name, p.Value.Type == JTokenType.Integer || p.Value.Type == JTokenType.Float ? (double)p.Value : J.Num(p.Value, "value")))
                .ToArray();
        }
    }
}
