using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NakamaFarsi.Sdk;
using PolicePatrol.Sdk.Auth;
using PolicePatrol.Sdk.Economy;
using PolicePatrol.Sdk.Payments;
using PolicePatrol.Sdk.Stages;
using PolicePatrol.Sdk.Users;
using Xunit;
using Xunit.Abstractions;

namespace PolicePatrol.Sdk.Tests
{
    public sealed class LocalServerFactAttribute : FactAttribute
    {
        public LocalServerFactAttribute()
        {
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("NF_IT_URL")) || string.IsNullOrEmpty(Environment.GetEnvironmentVariable("NF_IT_SERVER_LOG"))
                || string.IsNullOrEmpty(Environment.GetEnvironmentVariable("NF_IT_SQL")))
            {
                Skip = "set NF_IT_URL, NF_IT_KEY, NF_IT_SERVER_LOG and NF_IT_SQL (a script that runs one SQL statement on the server database) to run against a local Police Patrol server";
            }
        }
    }

    public class RoundTwoIntegrationTests : IDisposable
    {
        private static readonly Random Rng = new Random();
        private readonly ITestOutputHelper _out;

        public RoundTwoIntegrationTests(ITestOutputHelper output) => _out = output;

        public void Dispose() => PolicePatrolSdk.Shutdown();

        private static void Start(string device)
        {
            PolicePatrolSdk.Shutdown();
            var options = new SdkOptions(Environment.GetEnvironmentVariable("NF_IT_URL"), "it", false, 15, "fa")
            {
                ServerKey = Environment.GetEnvironmentVariable("NF_IT_KEY") ?? "defaultkey",
                UseSocket = false,
                DeviceId = device,
            };
            PolicePatrolSdk.Initialize(options, new NakamaFarsiClient(PolicePatrolSdk.CoreOptions(options)));
        }

        private static string NewDevice() => "r2-" + Guid.NewGuid().ToString("N");

        private static string NewPhone() => "0912" + Rng.Next(1000000, 9999999);

        private static string Intl(string local) => "+98" + local.Substring(1);

        private static string Purpose() =>
            (string)typeof(ApiClient).GetProperty("VerificationPurpose", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(PolicePatrolSdk.Client);

        private static long LogSize() => new FileInfo(Environment.GetEnvironmentVariable("NF_IT_SERVER_LOG")).Length;

        private static async Task<string> Code(string local, long after)
        {
            var phone = Regex.Escape(Intl(local));
            for (var i = 0; i < 50; i++)
            {
                using (var f = new FileStream(Environment.GetEnvironmentVariable("NF_IT_SERVER_LOG"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    f.Seek(after, SeekOrigin.Begin);
                    var text = await new StreamReader(f).ReadToEndAsync();
                    var m = Regex.Match(text, "sandbox code (\\d+) for " + phone);
                    if (m.Success)
                    {
                        return m.Groups[1].Value;
                    }
                }

                await Task.Delay(200);
            }

            throw new Exception("no sandbox code for " + local);
        }

        private static string Sql(string statement)
        {
            var p = Process.Start(new ProcessStartInfo(Environment.GetEnvironmentVariable("NF_IT_SQL"), "\"" + statement.Replace("\"", "\\\"") + "\"")
            {
                RedirectStandardOutput = true, RedirectStandardError = true, UseShellExecute = false,
            });
            var output = p.StandardOutput.ReadToEnd().Trim();
            p.WaitForExit();
            return output;
        }

        private async Task<(string Phone, string UserId)> SignUpByPhone()
        {
            Start(NewDevice());
            var phone = NewPhone();
            var at = LogSize();
            var first = await Harness.Call<OtpChallenge>(cb => AuthProvider.RequestLoginOtp(phone, cb));
            Assert.True(first.IsSuccess, first.Error?.ToString());
            var code = await Code(phone, at);
            var login = await Harness.Call<LoginResponse>(cb => AuthProvider.VerifyOtp(code, OtpChannel.Phone, cb));
            Assert.True(login.IsSuccess, login.Error?.ToString());
            return (phone, PolicePatrolSdk.Client.Core.Session.UserId);
        }

        [LocalServerFact]
        public async Task Item1NewPhoneResendIsALoginAndVerifies()
        {
            Start(NewDevice());
            Assert.False(AuthProvider.IsLoggedIn);
            var phone = NewPhone();
            var at = LogSize();
            var first = await Harness.Call<OtpChallenge>(cb => AuthProvider.RequestLoginOtp(phone, cb));
            Assert.True(first.IsSuccess, first.Error?.ToString());
            Assert.True(AuthProvider.IsLoggedIn);
            var code1 = await Code(phone, at);

            var soon = await Harness.Call<OtpChallenge>(cb => AuthProvider.ResendOtp(OtpChannel.Phone, cb));
            Assert.False(soon.IsSuccess);
            _out.WriteLine("too soon: " + soon.Error.Code + " server " + soon.Error.ServerCode + " retry " + soon.Error.RetryAfterSeconds + " text " + soon.Error.Message);
            Assert.NotNull(soon.Error.RetryAfterSeconds);
            Assert.DoesNotContain("{retryAfter}", soon.Error.Message ?? string.Empty);

            await Task.Delay(TimeSpan.FromSeconds(11));
            at = LogSize();
            var again = await Harness.Call<OtpChallenge>(cb => AuthProvider.ResendOtp(OtpChannel.Phone, cb));
            Assert.True(again.IsSuccess, again.Error?.ToString());
            Assert.Equal("login", Purpose());
            var code2 = await Code(phone, at);
            _out.WriteLine("codes " + code1 + " " + code2);

            var login = await Harness.Call<LoginResponse>(cb => AuthProvider.VerifyOtp(code2, OtpChannel.Phone, cb));
            Assert.True(login.IsSuccess, login.Error?.ToString());
            var me = await Harness.Call<CurrentUser>(ProfileProvider.GetMe);
            Assert.True(me.IsSuccess, me.Error?.ToString());
            Assert.False(me.Data.IsGuest);
            _out.WriteLine("new phone user " + me.Data.Id + " phone " + me.Data.PhoneNumber);
        }

        [LocalServerFact]
        public async Task Item1RegisteredPhoneResendStaysALogin()
        {
            var owner = await SignUpByPhone();
            await Task.Delay(TimeSpan.FromSeconds(11));
            Start(NewDevice());
            var signedIn = await Harness.Call<LoginResponse>(cb => AuthProvider.DeviceIdLogin(PolicePatrolSdk.Client.Core.DeviceId, cb));
            Assert.True(signedIn.IsSuccess, signedIn.Error?.ToString());
            var at = LogSize();
            var first = await Harness.Call<OtpChallenge>(cb => AuthProvider.RequestLoginOtp(owner.Phone, cb));
            Assert.True(first.IsSuccess, first.Error?.ToString());
            await Code(owner.Phone, at);
            await Task.Delay(TimeSpan.FromSeconds(11));
            at = LogSize();
            var again = await Harness.Call<OtpChallenge>(cb => AuthProvider.ResendOtp(OtpChannel.Phone, cb));
            Assert.True(again.IsSuccess, again.Error?.ToString());
            Assert.Equal("login", Purpose());
            var code = await Code(owner.Phone, at);
            var login = await Harness.Call<LoginResponse>(cb => AuthProvider.VerifyOtp(code, OtpChannel.Phone, cb));
            Assert.True(login.IsSuccess, login.Error?.ToString());
            Assert.Equal(owner.UserId, PolicePatrolSdk.Client.Core.Session.UserId);
        }

        [LocalServerFact]
        public async Task Item1RecoverResendStaysARecover()
        {
            var owner = await SignUpByPhone();
            await Task.Delay(TimeSpan.FromSeconds(11));
            var device = NewDevice();
            Start(device);
            var guest = await Harness.Call<LoginResponse>(cb => AuthProvider.DeviceIdLogin(device, cb));
            Assert.True(guest.IsSuccess, guest.Error?.ToString());
            var at = LogSize();
            var first = await Harness.Call<OtpChallenge>(cb => AuthProvider.RequestRecoverOtp(owner.Phone, cb));
            Assert.True(first.IsSuccess, first.Error?.ToString());
            await Code(owner.Phone, at);
            await Task.Delay(TimeSpan.FromSeconds(11));
            at = LogSize();
            var again = await Harness.Call<OtpChallenge>(cb => AuthProvider.ResendOtp(OtpChannel.Phone, cb));
            Assert.True(again.IsSuccess, again.Error?.ToString());
            Assert.Equal("recover", Purpose());
            var code = await Code(owner.Phone, at);
            var login = await Harness.Call<LoginResponse>(cb => AuthProvider.VerifyOtp(code, OtpChannel.Phone, cb, device));
            Assert.True(login.IsSuccess, login.Error?.ToString());
            Assert.Equal(owner.UserId, PolicePatrolSdk.Client.Core.Session.UserId);
        }

        [LocalServerFact]
        public async Task Item6PhoneChangeWithTheOldNumberFirst()
        {
            var owner = await SignUpByPhone();
            await Task.Delay(TimeSpan.FromSeconds(11));
            var next = NewPhone();
            var at = LogSize();
            var asked = await Harness.Call<OtpChallenge>(cb => AuthProvider.RequestPhoneChange(next, cb));
            Assert.True(asked.IsSuccess, asked.Error?.ToString());
            Assert.Equal(PhoneChangeStep.StageOld, asked.Data.Stage);
            var oldCode = await Code(owner.Phone, at);
            at = LogSize();
            var first = await Harness.Call<PhoneChangeStep>(cb => AuthProvider.VerifyPhoneChangeStep(oldCode, cb));
            Assert.True(first.IsSuccess, first.Error?.ToString());
            Assert.False(first.Data.Done);
            Assert.True(first.Data.WaitingForNewPhoneCode);
            _out.WriteLine("second step sent to " + first.Data.NextChallenge.SentTo);
            var newCode = await Code(next, at);
            var second = await Harness.Call<PhoneChangeStep>(cb => AuthProvider.VerifyPhoneChangeStep(newCode, cb));
            Assert.True(second.IsSuccess, second.Error?.ToString());
            Assert.True(second.Data.Done);
            Assert.Equal(Intl(next), Sql("SELECT phone FROM publication_phone_account WHERE user_id='" + owner.UserId + "'"));
        }

        [LocalServerFact]
        public async Task Item2AQuizStartKeepsTheSavedMissionResult()
        {
            var device = NewDevice();
            Start(device);
            var login = await Harness.Call<LoginResponse>(cb => AuthProvider.DeviceIdLogin(device, cb));
            Assert.True(login.IsSuccess, login.Error?.ToString());
            var attempt = await Harness.Call<StageAttempt>(cb => StageProvider.Start("chapter-close-beta-level-01", cb));
            Assert.True(attempt.IsSuccess, attempt.Error?.ToString());
            var quiz = await PolicePatrolSdk.Client.Core.CallRpcAsync("quiz_play", "{\"packKey\":\"quiz-public-01\",\"lang\":\"fa\"}");
            _out.WriteLine("quiz started: " + quiz.Substring(0, Math.Min(160, quiz.Length)));
            Assert.Equal(2, int.Parse(Sql("SELECT count(*) FROM campaign_attempt WHERE user_id='" + PolicePatrolSdk.Client.Core.Session.UserId + "' AND status='open'")));
            await Task.Delay(TimeSpan.FromSeconds(6));
            var done = await Harness.Call<StageResult>(cb => StageProvider.Complete("chapter-close-beta-level-01", attempt.Data.AttemptId, true, 6, 100, cb));
            Assert.True(done.IsSuccess, done.Error?.ToString());
            _out.WriteLine("saved result sent after the quiz start: stars " + done.Data.Stars);
        }

        [LocalServerFact]
        public async Task Item3ACoinPurchaseWhoseGrantFailsAfterTheChargeIsRetried()
        {
            var device = NewDevice();
            Start(device);
            var login = await Harness.Call<LoginResponse>(cb => AuthProvider.DeviceIdLogin(device, cb));
            Assert.True(login.IsSuccess, login.Error?.ToString());
            var user = PolicePatrolSdk.Client.Core.Session.UserId;
            Sql("UPDATE economy_prize SET items='[{\"type\":\"currency\",\"key\":\"coin\",\"action\":\"add\",\"value\":5},{\"type\":\"meta\",\"key\":\"xp\",\"action\":\"add\",\"value\":\"abc\"}]' WHERE key='r2_bad_prize'");
            var product = Sql("SELECT id FROM economy_product WHERE key='r2_once_coins'");
            await Harness.Call<UserCurrency>(cb => CurrencyProvider.GetByKey("coin", cb));
            Sql("UPDATE users SET wallet = jsonb_set(coalesce(wallet,'{}'::jsonb), '{coin}', '1000') WHERE id='" + user + "'");

            var buy = await Harness.Call<InitiatePaymentResult>(cb => PaymentProvider.Initiate(product, PaymentMethods.InApp, cb));
            Assert.False(buy.IsSuccess);
            Assert.Equal(PaymentErrorCodes.RewardPending, buy.Error.Code);
            var row = Sql("SELECT status || ',' || reward_granted || ',' || (once_key IS NOT NULL) FROM economy_payment WHERE user_id='" + user + "'");
            _out.WriteLine("after the failed grant: " + row + " wallet " + Sql("SELECT wallet->>'coin' FROM users WHERE id='" + user + "'"));
            Assert.Equal("success,false,true", row);

            Sql("UPDATE economy_prize SET items='[{\"type\":\"currency\",\"key\":\"coin\",\"action\":\"add\",\"value\":5},{\"type\":\"meta\",\"key\":\"xp\",\"action\":\"add\",\"value\":3}]' WHERE key='r2_bad_prize'");
            await Harness.Call<UserCurrency>(cb => CurrencyProvider.GetByKey("coin", cb));
            Assert.Equal("t", Sql("SELECT reward_granted FROM economy_payment WHERE user_id='" + user + "'"));
            Assert.Equal("995", Sql("SELECT wallet->>'coin' FROM users WHERE id='" + user + "'"));
            var again = await Harness.Call<InitiatePaymentResult>(cb => PaymentProvider.Initiate(product, PaymentMethods.InApp, cb));
            Assert.False(again.IsSuccess);
            _out.WriteLine("buy again: " + again.Error.Code);
        }
    }
}
