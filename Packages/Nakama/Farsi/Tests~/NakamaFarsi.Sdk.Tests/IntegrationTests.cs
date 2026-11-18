using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xunit;

namespace NakamaFarsi.Sdk.Tests
{
    public sealed class IntegrationFactAttribute : FactAttribute
    {
        public IntegrationFactAttribute()
        {
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("NF_IT_URL")))
            {
                Skip = "set NF_IT_URL to run against a server";
            }
        }
    }

    public class IntegrationTests
    {
        private static NakamaFarsiClient Client(bool socket)
        {
            var options = NakamaFarsiOptions.FromUrl(Environment.GetEnvironmentVariable("NF_IT_URL") ?? "http://127.0.0.1:7450", Environment.GetEnvironmentVariable("NF_IT_KEY") ?? "defaultkey");
            options.UseSocket = socket;
            options.Language = "fa";
            return new NakamaFarsiClient(options);
        }

        private static string Device() => "nf-sdk-it-" + Guid.NewGuid().ToString("N");

        [IntegrationFact]
        public async Task LoginSocketAndGeneratedCall()
        {
            var c = Client(true);
            await c.LoginWithDeviceAsync(Device());
            await c.Socket.ConnectAsync();
            Assert.True(c.Socket.IsConnected);
            var me = await c.Rpcs.Base.AccountGetAsync();
            Assert.Equal(c.Session.UserId, me.Extra["user"]["id"]?.ToString());
            await c.LogoutAsync();
        }

        [IntegrationFact]
        public async Task BothErrorStylesOverSocketAndHttp()
        {
            foreach (var socket in new[] { true, false })
            {
                var c = Client(socket);
                await c.LoginWithDeviceAsync(Device());
                if (socket)
                {
                    await c.Socket.ConnectAsync();
                }

                var envelope = await Assert.ThrowsAsync<ApiException>(() => c.CallRpcAsync("leaderboardx_board", "{}", RpcCallOptions.Read));
                Assert.Equal("LEADERBOARD_KEY_REQUIRED", envelope.Error.Code);
                Assert.Equal(400, envelope.Error.Status);

                var bare = await Assert.ThrowsAsync<ApiException>(() => c.CallRpcAsync("economy_event_record", "{\"key\":\"nf_sdk_no_such_event\"}", RpcCallOptions.Write));
                Assert.Equal("EVENT_TYPE_NOT_FOUND", bare.Error.Code);
                await c.LogoutAsync();
            }
        }

        [IntegrationFact]
        public async Task TypedReadsOverSocket()
        {
            var c = Client(true);
            await c.LoginWithDeviceAsync(Device());
            await c.Socket.ConnectAsync();
            var boards = await c.Rpcs.Leaderboardx.ListAsync();
            Assert.NotNull(boards);
            var tasks = await c.Rpcs.Economy.TasksListAsync();
            Assert.NotNull(tasks);
            var stickers = await c.Rpcs.Base.StickersAsync();
            Assert.NotNull(stickers);
            var balances = await c.Rpcs.Economy.BalancesAsync();
            Assert.NotNull(balances);
            await c.LogoutAsync();
        }

        [IntegrationFact]
        public async Task PhoneLoginLinksTheGuest()
        {
            var log = Environment.GetEnvironmentVariable("NF_IT_SERVER_LOG");
            var c = Client(true);
            var guest = await c.LoginWithDeviceAsync(Device());
            var status = await c.Phone.StatusAsync();
            if (!status.OtpEnabled || string.IsNullOrEmpty(log))
            {
                return;
            }

            var local = "0999" + new Random().Next(0, 9999999).ToString("D7");
            var sent = await c.Phone.RequestCodeAsync(local);
            Assert.StartsWith("+98999", sent.Phone);
            Assert.True(sent.Sandbox);
            string code = null;
            for (var i = 0; i < 40 && code == null; i++)
            {
                await Task.Delay(250);
                foreach (var line in System.IO.File.ReadAllLines(log))
                {
                    var m = System.Text.RegularExpressions.Regex.Match(line, "OTP sandbox code (\\d+) for ");
                    if (m.Success && line.Contains(sent.Phone + " "))
                    {
                        code = m.Groups[1].Value;
                    }
                }
            }

            Assert.NotNull(code);
            var wrong = await Assert.ThrowsAsync<ApiException>(() => c.Phone.VerifyAsync(sent.Phone, code == "00000" ? "11111" : "00000"));
            Assert.False(string.IsNullOrEmpty(wrong.Error.Code));
            var result = await c.Phone.VerifyAsync(sent.Phone, code);
            Assert.True(result.Linked);
            Assert.Equal(guest.UserId, result.UserId);
            Assert.Equal(guest.UserId, c.Session.UserId);
            Assert.False(string.IsNullOrEmpty(c.Session.Current.RefreshToken));
            Assert.Null(result.Raw["loginKey"]);
            Assert.True(result.NeedsProfile);
            Assert.Equal(sent.Phone, (await c.Phone.StatusAsync()).Phone);
            await c.LogoutAsync();
        }

        private static async Task<System.Net.Http.HttpClient> ConsoleHttp()
        {
            var console = Environment.GetEnvironmentVariable("NF_IT_CONSOLE_URL");
            var http = new System.Net.Http.HttpClient { BaseAddress = new Uri(console) };
            var login = new JObject { ["username"] = Environment.GetEnvironmentVariable("CONSOLE_USER"), ["password"] = Environment.GetEnvironmentVariable("CONSOLE_PASSWORD") };
            var res = await http.PostAsync("/v2/console/authenticate", Json(login));
            res.EnsureSuccessStatusCode();
            var token = (string)JObject.Parse(await res.Content.ReadAsStringAsync())["token"];
            http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            return http;
        }

        private static System.Net.Http.StringContent Json(JObject body) => new System.Net.Http.StringContent(body.ToString(), System.Text.Encoding.UTF8, "application/json");

        private static async Task GiveCoins(string userId, int coins)
        {
            using (var http = await ConsoleHttp())
            {
                var body = new JObject { ["id"] = userId, ["wallet"] = new JObject { ["coin"] = coins }.ToString(Newtonsoft.Json.Formatting.None) };
                (await http.PostAsync("/v2/console/account/" + userId, Json(body))).EnsureSuccessStatusCode();
            }
        }

        private static async Task<string> ProductId(NakamaFarsiClient c, Func<JObject, bool> pick)
        {
            var catalog = await c.Payments.CatalogAsync();
            foreach (var p in (JArray)catalog["products"] ?? new JArray())
            {
                if (pick((JObject)p))
                {
                    return (string)p["id"];
                }
            }

            return null;
        }

        private static bool Has(JObject product, string method)
        {
            foreach (var m in (JArray)product["paymentMethods"] ?? new JArray())
            {
                if ((string)m == method)
                {
                    return true;
                }
            }

            return false;
        }

        [IntegrationFact]
        public async Task CoinPurchaseOverHttp()
        {
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("NF_IT_CONSOLE_URL")))
            {
                return;
            }

            var c = Client(true);
            var s = await c.LoginWithDeviceAsync(Device());
            await c.Socket.ConnectAsync();
            var id = await ProductId(c, p => p["coinPrice"] != null && p["coinPrice"].Type == JTokenType.Object && Has(p, "in_app"));
            Assert.NotNull(id);
            await GiveCoins(s.UserId, 1000);
            var before = (int)(await c.Payments.BalancesAsync())["wallet"]["coin"];
            Assert.Equal(1000, before);
            var bought = await c.Payments.BuyAsync(id, Sdk.Payments.PaymentMethods.Coins);
            Assert.Equal(Sdk.Payments.PurchaseOutcome.Success, bought.Outcome);
            Assert.False(string.IsNullOrEmpty(bought.PaymentId));
            var status = await c.Payments.StatusAsync(bought.PaymentId);
            Assert.Equal("success", status.Status);
            var balances = await c.Payments.BalancesAsync();
            var last = (await c.Payments.HistoryAsync(1))["items"][0];
            Assert.Equal(bought.PaymentId, (string)last["paymentId"]);
            var price = (int)last["coinAmount"];
            Assert.True(price > 0);
            var gained = 0;
            foreach (var r in bought.Rewards)
            {
                if ((string)r["type"] == "currency" && (string)r["key"] == "coin" && (string)r["action"] == "add")
                {
                    gained += (int)r["value"];
                }
            }

            Assert.Equal(1000 - price + gained, (int)balances["wallet"]["coin"]);
            await c.LogoutAsync();
        }

        [IntegrationFact]
        public async Task BazaarSandboxPurchaseWithTheTestStore()
        {
            var c = Client(true);
            await c.LoginWithDeviceAsync(Device());
            await c.Socket.ConnectAsync();
            var config = await c.Payments.StoreConfigAsync(Sdk.Payments.PaymentMethods.Bazaar);
            if (!config.Sandbox)
            {
                return;
            }

            Assert.Equal(Sdk.Payments.StoreChoice.TestStore, Sdk.Payments.StoreSelector.Choose("bazaar", config, true, true));
            var id = await ProductId(c, p => Has(p, "bazaar"));
            Assert.NotNull(id);
            var store = new Sdk.Payments.TestStoreBilling();
            var bought = await c.Payments.BuyAsync(id, Sdk.Payments.PaymentMethods.Bazaar, store);
            Assert.Equal(Sdk.Payments.PurchaseOutcome.Success, bought.Outcome);
            Assert.True(Sdk.Payments.PaymentClient.ServerAccepted(bought));
            System.Collections.Generic.IReadOnlyList<Sdk.Payments.StorePurchase> left = null;
            store.GetPurchases(l => left = l);
            Assert.Empty(left);

            store.Approve = _ => false;
            var cancelled = await c.Payments.BuyAsync(id, Sdk.Payments.PaymentMethods.Bazaar, store);
            Assert.Equal(Sdk.Payments.PurchaseOutcome.Cancelled, cancelled.Outcome);

            var lost = new Sdk.Payments.TestStoreBilling();
            var start = JObject.Parse(await c.CallRpcAsync("economy_purchase_start", new JObject { ["productId"] = id, ["method"] = "bazaar" }.ToString()));
            lost.Purchase((string)start["sku"], (string)start["developerPayload"], _ => { });
            var recovered = await c.Payments.RecoverAsync(lost);
            Assert.Single(recovered);
            Assert.Equal(Sdk.Payments.PurchaseOutcome.Success, recovered[0].Outcome);
            lost.GetPurchases(l => left = l);
            Assert.Empty(left);
            await c.LogoutAsync();
        }

        [IntegrationFact]
        public async Task RoomChatLiveAndStickerRefusal()
        {
            var a = Client(true);
            var b = Client(true);
            await a.LoginWithDeviceAsync(Device());
            await b.LoginWithDeviceAsync(Device());
            var room = "nf-sdk-it-" + Guid.NewGuid().ToString("N").Substring(0, 8);
            var ca = await a.Chat.JoinRoomAsync(room);
            await b.Chat.JoinRoomAsync(room);
            var got = new TaskCompletionSource<Sdk.Social.ChatMessage>();
            b.Chat.MessageReceived += m =>
            {
                if (m.Text == "salam")
                {
                    got.TrySetResult(m);
                }
            };
            await a.Chat.SendTextAsync(ca.Id, "salam");
            var done = await Task.WhenAny(got.Task, Task.Delay(5000));
            Assert.Same(got.Task, done);
            Assert.Equal(a.Session.UserId, got.Task.Result.SenderId);
            Assert.False(got.Task.Result.IsSticker);

            var refused = await Assert.ThrowsAsync<ApiException>(() => a.Chat.SendStickerAsync(ca.Id, "nf_sdk_none/none"));
            Assert.Equal("STICKER_NOT_FOUND", refused.Error.Code);
            Assert.False(string.IsNullOrEmpty(refused.Error.Message));
            Assert.Equal("nf_sdk_none/none", (string)refused.Error.Meta["sticker"]);

            string packId = null;
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("NF_IT_CONSOLE_URL")))
            {
                using (var http = await ConsoleHttp())
                {
                    var pack = new JObject
                    {
                        ["key"] = room.Replace("-", "_"),
                        ["name"] = new JObject { ["fa"] = "آزمایشی" },
                        ["access"] = "free",
                        ["sort"] = -100000,
                        ["stickers"] = new JArray { new JObject { ["key"] = "hi", ["imageUrl"] = "/stickers/hi.png" } },
                    };
                    var res = await http.PostAsync("/v2/console/base/stickers/packs", Json(pack));
                    res.EnsureSuccessStatusCode();
                    packId = (string)JObject.Parse(await res.Content.ReadAsStringAsync())["id"];
                }
            }

            var sentSticker = false;
            var stickers = JObject.Parse(await a.Chat.StickersJsonAsync());
            Assert.NotNull(stickers["enabled"]);
            foreach (var pack in (JArray)stickers["packs"] ?? new JArray())
            {
                if ((bool)pack["owned"] && ((JArray)pack["stickers"]).Count > 0)
                {
                    var stickerRef = (string)pack["stickers"][0]["ref"];
                    var echo = new TaskCompletionSource<Sdk.Social.ChatMessage>();
                    b.Chat.MessageReceived += m =>
                    {
                        if (m.Sticker == stickerRef)
                        {
                            echo.TrySetResult(m);
                        }
                    };
                    await a.Chat.SendStickerAsync(ca.Id, stickerRef);
                    sentSticker = true;
                    Assert.Same(echo.Task, await Task.WhenAny(echo.Task, Task.Delay(5000)));
                    Assert.False(string.IsNullOrEmpty(echo.Task.Result.StickerUrl));
                    break;
                }
            }

            Assert.Equal(packId != null, sentSticker);
            if (packId != null)
            {
                using (var http = await ConsoleHttp())
                {
                    (await http.DeleteAsync("/v2/console/base/stickers/packs/" + packId)).EnsureSuccessStatusCode();
                }
            }

            await a.LogoutAsync();
            await b.LogoutAsync();
        }
    }
}
