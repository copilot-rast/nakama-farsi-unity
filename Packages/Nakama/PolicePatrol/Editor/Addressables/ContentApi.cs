using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEditor;

namespace PolicePatrol.Sdk.Editor
{
    public static class ContentApi
    {
        private const string BasePath = "/v2/assets/editor/packs";

        public static string Platform => EditorUserBuildSettings.activeBuildTarget.ToString();

        public static async Task<ContentTarget> FindOrCreateTargetAsync(AssetSyncSettings settings)
        {
            var list = await EditorApiClient.SendJsonAsync<JToken>(settings, HttpMethod.Get, BasePath + "?platform=" + Uri.EscapeDataString(Platform), null);
            var packs = (list as JArray) ?? (list?["items"] as JArray) ?? (list?["packs"] as JArray) ?? new JArray();
            var live = packs.FirstOrDefault(p => (bool?)p["active"] == true || (bool?)p["isActive"] == true) ?? packs.FirstOrDefault();
            return live == null ? new ContentTarget(string.Empty, Platform, string.Empty, 0, 0, 0) : ContentTarget.From((JObject)live, packs.Count);
        }

        public static Task<ContentTarget> GetTargetAsync(AssetSyncSettings settings, string contentId) => FindOrCreateTargetAsync(settings);

        public static async Task<ContentPlan> PlanAsync(AssetSyncSettings settings, string contentId, IEnumerable<ContentFile> files)
        {
            var all = files.ToList();
            var body = new JObject
            {
                ["platform"] = Platform,
                ["version"] = DateTime.UtcNow.ToString("yyyyMMdd.HHmmss", CultureInfo.InvariantCulture),
                ["minAppVersion"] = PlayerSettings.bundleVersion ?? string.Empty,
                ["files"] = new JArray(all.Select(f => new JObject { ["path"] = f.Path, ["sha256"] = f.Sha256, ["size"] = f.Size })),
            };
            var answer = await EditorApiClient.SendJsonAsync<JObject>(settings, HttpMethod.Post, BasePath, body);
            var missing = (answer["missing"] as JArray ?? new JArray()).OfType<JObject>().ToList();
            var missingPaths = new HashSet<string>(missing.Select(m => (string)m["path"]), StringComparer.Ordinal);
            var reused = all.Where(f => !missingPaths.Contains(f.Path) && !missingPaths.Contains(StripPlatform(f.Path))).ToList();
            return new ContentPlan(all.Where(f => missingPaths.Contains(f.Path) || missingPaths.Contains(StripPlatform(f.Path))).Select(f => f.Path).ToList(), reused.Count, reused.Sum(f => f.Size))
            {
                PackId = (string)answer["pack"]?["id"],
                PartBytes = (long?)answer["partBytes"] ?? 8 * 1024 * 1024,
                Parts = missing,
            };
        }

        public static async Task<ContentTarget> PublishAsync(AssetSyncSettings settings, ContentPlan plan, string zipPath, string note, bool activate = true)
        {
            using (var archive = ZipFile.OpenRead(zipPath))
            {
                foreach (var file in plan.Parts)
                {
                    var path = (string)file["path"];
                    var sha = (string)file["sha256"];
                    var partBytes = (long?)file["partBytes"] ?? plan.PartBytes;
                    var parts = (int?)file["parts"] ?? 1;
                    var received = new HashSet<int>((file["received"] as JArray ?? new JArray()).Select(x => (int)x));
                    var entry = archive.Entries.FirstOrDefault(e => e.FullName == path || StripPlatform(e.FullName) == path)
                        ?? throw new InvalidOperationException("The build has no file " + path);
                    byte[] bytes;
                    using (var stream = entry.Open())
                    using (var memory = new MemoryStream())
                    {
                        await stream.CopyToAsync(memory);
                        bytes = memory.ToArray();
                    }

                    for (var n = 0; n < parts; n++)
                    {
                        if (received.Contains(n))
                        {
                            continue;
                        }

                        var offset = (int)(n * partBytes);
                        var length = (int)Math.Min(partBytes, bytes.Length - offset);
                        var content = new ByteArrayContent(bytes, offset, Math.Max(0, length));
                        await EditorApiClient.SendAsync<JObject>(settings, HttpMethod.Put, BasePath + "/" + plan.PackId + "/blobs/" + sha + "/" + n, content, TimeSpan.FromMinutes(10));
                    }
                }
            }

            var done = await EditorApiClient.SendJsonAsync<JObject>(settings, HttpMethod.Post, BasePath + "/" + plan.PackId + "/complete", new JObject { ["activate"] = activate, ["note"] = note ?? string.Empty });
            return ContentTarget.From(done["pack"] as JObject ?? done, 0);
        }

        public static async Task<JObject> CheckAccessAsync(AssetSyncSettings settings, string contentId)
        {
            using (var http = new HttpClient { Timeout = TimeSpan.FromSeconds(20) })
            {
                var url = settings.ServerUrl.Trim().TrimEnd('/') + "/v2/assets/content-index?platform=" + Uri.EscapeDataString(Platform);
                try
                {
                    var res = await http.GetAsync(url);
                    var body = JObject.Parse(await res.Content.ReadAsStringAsync());
                    var pack = body["pack"] as JObject;
                    return pack == null
                        ? new JObject { ["reachable"] = false, ["error"] = res.IsSuccessStatusCode ? "no active pack for " + Platform : (string)body["message"] ?? res.StatusCode.ToString() }
                        : new JObject { ["reachable"] = true, ["url"] = pack["catalogUrl"] };
                }
                catch (Exception e)
                {
                    return new JObject { ["reachable"] = false, ["error"] = e.Message };
                }
            }
        }

        private static string StripPlatform(string path)
        {
            var i = path.IndexOf('/');
            return i > 0 && path.Substring(0, i) == Platform ? path.Substring(i + 1) : path;
        }
    }
}
