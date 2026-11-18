using System.Linq;
using System.Threading.Tasks;
using PolicePatrol.Sdk.Auth;
using Xunit;
using NF = NakamaFarsi.Sdk;

namespace PolicePatrol.Sdk.Tests
{
    public class OtpRouteTests
    {
        private static ScriptedTransport LoginServer(bool signedIn, string userId)
        {
            var t = Harness.Start(signedIn: signedIn);
            var sent = 0;
            t.Routes["publication_otp_request"] = p => "{\"phone\":\"+989121234567\",\"expiresIn\":120,\"resendAfter\":0,\"requestId\":\"r" + (++sent) + "\"}";
            t.Routes["publication_otp_verify"] = p => "{\"token\":\"" + Harness.Jwt(System.DateTimeOffset.UtcNow.AddHours(2)) + "\",\"userId\":\"" + userId + "\",\"phone\":\"+989121234567\"}";
            t.Routes["account_phone_recover_request"] = p => new NF.RpcServerException("{\"code\":\"PHONE_NOT_REGISTERED\",\"status\":404}", 404);
            return t;
        }

        private static string[] Ids(ScriptedTransport t) => t.Calls.Select(c => c.Id).Where(id => id != "devkit_error_catalog").ToArray();

        [Fact]
        public async Task ANewPhoneResendsTheLoginCodeAfterTheSilentDeviceSignIn()
        {
            var t = LoginServer(false, "new-user");
            Assert.False(AuthProvider.IsLoggedIn);
            var first = await Harness.Call<OtpChallenge>(cb => AuthProvider.RequestLoginOtp("09121234567", cb));
            Assert.True(first.IsSuccess, first.Error?.ToString());
            Assert.True(AuthProvider.IsLoggedIn);

            var again = await Harness.Call<OtpChallenge>(cb => AuthProvider.ResendOtp(OtpChannel.Phone, cb));
            Assert.True(again.IsSuccess, again.Error?.ToString());
            Assert.Equal(new[] { "device_sign_in", "publication_otp_request", "publication_otp_request" }, Ids(t));
            Assert.Contains("+989121234567", t.Calls.Last().Payload);

            var login = await Harness.Call<LoginResponse>(cb => AuthProvider.VerifyOtp("1234", OtpChannel.Phone, cb));
            Assert.True(login.IsSuccess, login.Error?.ToString());
            Assert.Equal("publication_otp_verify", Ids(t).Last());
            Assert.False(AuthProvider.HasPendingOtp);
        }

        [Fact]
        public async Task TheObsoleteRequestKeepsItsFirstRouteOnResend()
        {
            var t = LoginServer(false, "new-user");
#pragma warning disable CS0618
            var first = await Harness.Call<OtpChallenge>(cb => AuthProvider.RequestPhoneOtp("09121234567", cb));
#pragma warning restore CS0618
            Assert.True(first.IsSuccess, first.Error?.ToString());
            var again = await Harness.Call<OtpChallenge>(cb => AuthProvider.ResendOtp(OtpChannel.Phone, cb));
            Assert.True(again.IsSuccess, again.Error?.ToString());
            Assert.DoesNotContain("account_phone_recover_request", Ids(t));
            Assert.Equal(2, Ids(t).Count(id => id == "publication_otp_request"));
        }

        [Fact]
        public async Task ARegisteredPhoneStaysALoginWhenSignedInWithTheDevice()
        {
            var t = LoginServer(true, "owner");
            Assert.True(AuthProvider.IsLoggedIn);
            var first = await Harness.Call<OtpChallenge>(cb => AuthProvider.RequestLoginOtp("09121234567", cb));
            Assert.True(first.IsSuccess, first.Error?.ToString());
            var again = await Harness.Call<OtpChallenge>(cb => AuthProvider.ResendOtp(OtpChannel.Phone, cb));
            Assert.True(again.IsSuccess, again.Error?.ToString());
            Assert.Equal(new[] { "publication_otp_request", "publication_otp_request" }, Ids(t));

            var login = await Harness.Call<LoginResponse>(cb => AuthProvider.VerifyOtp("1234", OtpChannel.Phone, cb));
            Assert.True(login.IsSuccess, login.Error?.ToString());
            Assert.Equal("publication_otp_verify", Ids(t).Last());
        }

        [Fact]
        public async Task ARecoverCodeIsResentAsARecoverCode()
        {
            var t = Harness.Start();
            t.Routes["account_phone_recover_request"] = p => "{\"purpose\":\"recover\",\"stage\":\"new\",\"phone\":\"+989121234567\",\"expiresIn\":120,\"resendAfter\":0}";
            t.Routes["account_phone_recover_verify"] = p => "{\"token\":\"" + Harness.Jwt(System.DateTimeOffset.UtcNow.AddHours(2)) + "\",\"userId\":\"owner\",\"devicesMoved\":[]}";
            var first = await Harness.Call<OtpChallenge>(cb => AuthProvider.RequestRecoverOtp("09121234567", cb));
            Assert.True(first.IsSuccess, first.Error?.ToString());
            var again = await Harness.Call<OtpChallenge>(cb => AuthProvider.ResendOtp(OtpChannel.Phone, cb));
            Assert.True(again.IsSuccess, again.Error?.ToString());
            Assert.Equal(new[] { "account_phone_recover_request", "account_phone_recover_request" }, Ids(t));

            var login = await Harness.Call<LoginResponse>(cb => AuthProvider.VerifyOtp("1234", OtpChannel.Phone, cb));
            Assert.True(login.IsSuccess, login.Error?.ToString());
            Assert.Equal("account_phone_recover_verify", Ids(t).Last());
        }

        [Fact]
        public async Task TheSavedPurposeSurvivesARestartForResend()
        {
            var store = new NF.MemoryKeyValueStore();
            var t = Harness.Start(store, null, false);
            t.Routes["publication_otp_request"] = p => "{\"phone\":\"+989121234567\",\"expiresIn\":120,\"resendAfter\":0}";
            var first = await Harness.Call<OtpChallenge>(cb => AuthProvider.RequestLoginOtp("09121234567", cb));
            Assert.True(first.IsSuccess, first.Error?.ToString());

            Harness.Start(store, t);
            var again = await Harness.Call<OtpChallenge>(cb => AuthProvider.ResendOtp(OtpChannel.Phone, cb));
            Assert.True(again.IsSuccess, again.Error?.ToString());
            Assert.Equal("publication_otp_request", Ids(t).Last());
        }
    

        [Fact]
        public async Task APhoneChangeWithTheOldNumberFirstHasTwoSteps()
        {
            var t = Harness.Start();
            t.Routes["account_phone_request"] = p => "{\"purpose\":\"change\",\"stage\":\"old\",\"phone\":\"0912***4567\",\"expiresIn\":120,\"resendAfter\":60}";
            var asked = await Harness.Call<OtpChallenge>(cb => AuthProvider.RequestPhoneChange("09351112222", cb));
            Assert.Equal(PhoneChangeStep.StageOld, asked.Data.Stage);
            Assert.Equal("0912***4567", asked.Data.SentTo);

            t.Routes["account_phone_verify"] = p => "{\"purpose\":\"change\",\"stage\":\"new\",\"phone\":\"+989351112222\",\"expiresIn\":120,\"resendAfter\":60}";
            var first = await Harness.Call<PhoneChangeStep>(cb => AuthProvider.VerifyPhoneChangeStep("1111", cb));
            Assert.True(first.IsSuccess, first.Error?.ToString());
            Assert.False(first.Data.Done);
            Assert.True(first.Data.WaitingForNewPhoneCode);
            Assert.Equal("+989351112222", first.Data.NextChallenge.SentTo);
            Assert.NotNull(first.Data.NextChallenge.CanResendAt);

#pragma warning disable CS0618
            var old = await Harness.Call<Users.CurrentUser>(cb => AuthProvider.VerifyPhoneChange("1111", cb));
#pragma warning restore CS0618
            Assert.False(old.IsSuccess);
            Assert.Equal(ApiError.PhoneNewCodeSentCode, old.Error.Code);

            t.Routes["account_phone_verify"] = p => "{\"done\":true,\"purpose\":\"change\",\"phone\":\"+989351112222\",\"profile\":{\"id\":\"u-1\",\"username\":\"p\",\"phone\":\"+989351112222\",\"phoneVerified\":true}}";
            var second = await Harness.Call<PhoneChangeStep>(cb => AuthProvider.VerifyPhoneChangeStep("2222", cb));
            Assert.True(second.Data.Done);
            Assert.True(second.Data.User.PhoneNumberVerified);
            Assert.Equal(new[] { "account_phone_request", "account_phone_verify", "account_phone_verify", "account_phone_verify" }, Ids(t));
        }
    

        [Fact]
        public async Task TooSoonWithoutAWaitGetsTheWaitOfTheLastCode()
        {
            var t = Harness.Start();
            t.Routes["publication_otp_request"] = p => "{\"phone\":\"+989121234567\",\"expiresIn\":120,\"resendAfter\":60}";
            Assert.True((await Harness.Call<OtpChallenge>(cb => AuthProvider.RequestLoginOtp("09121234567", cb))).IsSuccess);
            t.Routes["publication_otp_request"] = p => new NF.RpcServerException("OTP_TOO_SOON", 429);
            var soon = await Harness.Call<OtpChallenge>(cb => AuthProvider.ResendOtp(OtpChannel.Phone, cb));
            Assert.False(soon.IsSuccess);
            Assert.InRange(soon.Error.RetryAfterSeconds ?? 0, 55, 60);
            Assert.InRange((int)soon.Error.Meta["retryAfter"], 55, 60);

            var other = await Harness.Call<OtpChallenge>(cb => AuthProvider.RequestLoginOtp("09350000000", cb));
            Assert.Null(other.Error.RetryAfterSeconds);
        }
    }
}
