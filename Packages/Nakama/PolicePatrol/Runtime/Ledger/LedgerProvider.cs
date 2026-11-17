using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Ledger
{
    public static class LedgerProvider
    {
        public static void List(int pageNum, int limitItem, Action<ApiResult<PagedResult<LedgerEntry>>> onComplete, string[] kinds = null, string refId = null) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var size = Math.Max(1, Math.Min(100, limitItem));
                var page = Math.Max(1, pageNum);
                string cursor = null;
                JArray items = new JArray();
                for (var p = 1; p <= page; p++)
                {
                    var body = new JObject { ["limit"] = size, ["lang"] = c.Language };
                    if (kinds != null && kinds.Length > 0)
                    {
                        body["kinds"] = new JArray(kinds);
                    }

                    if (!string.IsNullOrEmpty(cursor))
                    {
                        body["cursor"] = cursor;
                    }

                    var answer = await c.Rpc("ledger_list", body, true).ConfigureAwait(false);
                    items = Mapping.Arr(answer, "items");
                    cursor = J.Str(answer, "cursor");
                    if (string.IsNullOrEmpty(cursor) && p < page)
                    {
                        items = new JArray();
                        break;
                    }
                }

                var user = c.Core.Session.UserId;
                var rows = items
                    .Where(i => refId == null || J.Str(i, "refId", "sourceId") == refId)
                    .Select(i => new LedgerEntry(
                        J.Str(i, "id"),
                        user,
                        J.Str(i, "kind"),
                        J.Str(i, "refId", "sourceId"),
                        J.Str(i, "title", "kindName") ?? J.Str(i, "itemName", "currencyName"),
                        J.NumOrNull(i, "amount") ?? J.NumOrNull(i, "change"),
                        J.Str(i, "currency") ?? c.Items.ToGame(J.Str(i, "itemKey")),
                        J.Str(i, "sourceId"),
                        J.TimeOr(i, "at")))
                    .ToArray();
                var known = (page - 1) * size + rows.Length + (string.IsNullOrEmpty(cursor) ? 0 : 1);
                return new PagedResult<LedgerEntry>(rows, known, page, size);
            }, null, "ledger_list");
    }
}
