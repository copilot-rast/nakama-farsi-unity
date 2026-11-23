using System.Threading.Tasks;
using NakamaFarsi.Sdk;
using NakamaFarsi.Sdk.Generated;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace ApiCompat.RoadStormRequests
{
    public static class MatchEnd
    {
        public static async Task Finish(NakamaFarsiClient client, string ticket)
        {
            var end = await client.Rpcs.Combatrace.MatchEndAsync(new CombatraceMatchEndRequest
            {
                Ticket = ticket, Position = 1, Cars = 6, TimeMs = 81234, MaxKmh = 190,
                Kills = 3, Zombies = 30, Finished = true,
                Weapons = new JObject { ["rocket"] = 2 },
            });

            Debug.Log("pits " + end.Rewards.Pits + " = rank " + end.PositionPits + " + kills " + end.KillPits
                + " + zombies " + end.ZombiePits + " + finish " + end.FinishPits + ", x" + end.LeagueMultiplier);
            Debug.Log("xp +" + end.XpGained + " → " + end.Xp + ", level " + end.Level
                + " (" + end.XpIntoLevel + "/" + end.XpForNext + ")");
            Debug.Log("trophies " + end.Trophies + ", league " + end.League + " " + end.LeagueName?["fa"]
                + ", next at " + end.NextLeagueAt);
            if (end.LevelUps != null && end.LevelUps.Count > 0)
                Debug.Log("level up " + string.Join(",", end.LevelUps) + ": +" + end.LevelUpPits + " pits");
            if (end.Clamped == true)
                Debug.Log("server capped kills to " + end.Kills + " and zombies to " + end.Zombies);
        }
    }

    public static class Profile
    {
        public static async Task Show(NakamaFarsiClient client)
        {
            var p = await client.Rpcs.Combatrace.ProfileAsync();
            Debug.Log("level " + p.Level + "/" + p.MaxLevel + ", xp " + p.XpIntoLevel + "/" + p.XpForNext
                + ", trophies " + p.Trophies + ", league " + p.League + " from " + p.LeagueStart);
        }
    }

    public static class Missions
    {
        public static async Task List(NakamaFarsiClient client)
        {
            var missions = await client.Rpcs.Combatrace.MissionsAsync(new CombatraceMissionsRequest { Lang = "fa" });
            Debug.Log(missions.Claimable + " ready to claim");
            foreach (var m in missions.Items)
            {
                Debug.Log(m.Title + ": " + m.Progress + "/" + m.Goal + ", " + m.Pits + " pits, "
                    + (m.SecondsLeft < 0 ? "no end" : m.SecondsLeft + " s left") + (m.Claimable == true ? ", claim" : ""));
            }
        }

        public static async Task Claim(NakamaFarsiClient client, string id)
        {
            try
            {
                var r = await client.Rpcs.Combatrace.TaskClaimAsync(new CombatraceTaskClaimRequest { Id = id, Lang = "fa" });
                Debug.Log("+" + r.Pits + " pits, +" + r.Oil + " oil, +" + r.XpReward + " xp, level " + r.Level);
                if (r.LevelUps != null && r.LevelUps.Count > 0)
                    Debug.Log("level up: +" + r.LevelUpPits + " pits");
            }
            catch (ApiException e)
            {
                Debug.LogWarning(e.Error.Code);
            }
        }
    }

    public static class Events
    {
        public static async Task List(NakamaFarsiClient client)
        {
            var events = await client.Rpcs.Combatrace.EventsAsync(new CombatraceEventsRequest { Lang = "fa" });
            foreach (var e in events.Items)
            {
                Debug.Log(e.Title + " (" + e.Kind + (string.IsNullOrEmpty(e.Weapon) ? "" : " " + e.Weapon) + "): "
                    + e.Progress + "/" + e.Goal + ", ends in " + e.SecondsLeft + " s" + (e.PerMatch == true ? ", in one race" : ""));
            }
        }
    }
}
