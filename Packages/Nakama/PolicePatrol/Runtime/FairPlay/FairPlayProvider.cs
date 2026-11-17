using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.FairPlay
{
    public static class FairPlayProvider
    {
        public static void ReportLocalState(LocalBalance[] balances, string[] ownedKeys, Action<ApiResult<LocalStateReceived>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var body = new JObject
                {
                    ["balances"] = new JArray((balances ?? Array.Empty<LocalBalance>()).Select(b => new JObject { ["currency"] = b.CurrencyId, ["amount"] = b.Amount })),
                    ["ownedKeys"] = new JArray(ownedKeys ?? Array.Empty<string>()),
                };
                var answer = await c.Rpc("pp_local_state", body, false).ConfigureAwait(false);
                return new LocalStateReceived(J.Bool(answer, "received", true));
            }, null, "pp_local_state");
    }
}
