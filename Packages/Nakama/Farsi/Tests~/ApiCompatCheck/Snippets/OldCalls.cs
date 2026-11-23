using System.Collections.Generic;
using System.Threading.Tasks;
using NakamaFarsi.Sdk;
using NakamaFarsi.Sdk.Generated;
using Newtonsoft.Json.Linq;

namespace ApiCompat.OldCalls
{
    public static class RoadStormBuildOfNovember
    {
        public static async Task Race(NakamaFarsiClient client)
        {
            CombatraceConfigResponse cfg = await client.Rpcs.Combatrace.ConfigAsync();
            List<long?> pits = cfg.Settings.PitsByPosition;
            long? maxCars = cfg.Settings.MaxCars;
            double? maxKmh = cfg.Settings.MaxKmh;
            List<JObject> rooms = cfg.Rooms;

            CombatraceMatchBeginResponse begin = await client.Rpcs.Combatrace.MatchBeginAsync(new CombatraceMatchBeginRequest { Room = "ranked" });
            string ticket = begin.Ticket;
            JToken entry = begin.Entry;
            bool? resumed = begin.Resumed;

            CombatraceMatchEndResponse end = await client.Rpcs.Combatrace.MatchEndAsync(new CombatraceMatchEndRequest
            {
                Ticket = ticket, Position = 2, Cars = 6, TimeMs = 90000, MaxKmh = 180.5,
            });
            bool? accepted = end.Accepted;
            long? rank = end.Position;
            long? won = end.Rewards.Pits;
            long? oil = end.Rewards.Oil;
            long? deltaTrophies = end.Rewards.Trophies;
            double? trophies = end.Trophies;
            JToken payouts = end.Payouts;
            string reason = end.Reason;
            JObject raw = end.Raw;

            CombatraceHistoryResponse history = await client.Rpcs.Combatrace.HistoryAsync(new CombatraceHistoryRequest { Limit = 20 });
            foreach (CombatraceHistoryResponse.ItemsItem item in history.Items)
            {
                string status = item.Status;
                JToken rewards = item.Rewards;
            }
        }

        public static async Task Lobby(NakamaFarsiClient client)
        {
            BaseAccountGetResponse account = await client.Rpcs.Base.AccountGetAsync();
            BaseAppVersionResponse version = await client.Rpcs.Base.AppVersionAsync();
            string latest = version.Latest;
            string store = version.StoreUrl;

            EconomyTasksListResponse tasks = await client.Rpcs.Economy.TasksListAsync();
            long? ready = tasks.Ready;
            EconomyTaskClaimResponse claimed = await client.Rpcs.Economy.TaskClaimAsync(new EconomyTaskClaimRequest { TaskId = "rs_daily_all" });

            EconomyReferralMeResponse referral = await client.Rpcs.Economy.ReferralMeAsync();
            long? invited = referral.Counts.Total;
            bool? canEnter = referral.CanEnter;

            LeaderboardxBoardResponse board = await client.Rpcs.Leaderboardx.BoardAsync(new LeaderboardxBoardRequest { Key = "combatrace_trophies", Limit = 50 });
            PublicationInboxResponse inbox = await client.Rpcs.Publication.InboxAsync();
            PublicationInboxClaimResponse prize = await client.Rpcs.Publication.InboxClaimAsync(new PublicationInboxClaimRequest { NotificationId = "n1" });

            string id = RpcIds.CombatraceMatchEnd;
            JObject payments = await client.Payments.CatalogAsync();
        }
    }
}
