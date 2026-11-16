using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace NakamaFarsi.Sdk.Auth
{
    public sealed class PhoneStatus
    {
        public string Phone { get; set; }
        public bool OtpEnabled { get; set; }
        public int CodeLength { get; set; }
        public JObject Raw { get; set; }
    }

    public sealed class PhoneCodeSent
    {
        public string RequestId { get; set; }
        public string Phone { get; set; }
        public int ExpiresIn { get; set; }
        public int ResendAfter { get; set; }
        public int CodeLength { get; set; }
        public bool Sandbox { get; set; }
        public JObject Raw { get; set; }
    }

    public sealed class PhoneLoginResult
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public bool Created { get; set; }
        public bool Linked { get; set; }
        public bool NeedsProfile { get; set; }
        public JObject Raw { get; set; }
    }

    public sealed class PhoneLogin
    {
        private readonly NakamaFarsiClient _client;

        public PhoneLogin(NakamaFarsiClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<PhoneStatus> StatusAsync(CancellationToken ct = default)
        {
            var raw = await Call("publication_phone", new JObject(), RpcCallOptions.Read, ct).ConfigureAwait(false);
            return new PhoneStatus
            {
                Phone = (string)raw["phone"] ?? string.Empty,
                OtpEnabled = (bool?)raw["otpEnabled"] ?? false,
                CodeLength = (int?)raw["codeLength"] ?? 0,
                Raw = raw,
            };
        }

        public async Task<PhoneCodeSent> RequestCodeAsync(string phone, string country = null, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ApiException(ApiError.Invalid("phone", "required"));
            }

            await EnsureGuestAsync(ct).ConfigureAwait(false);
            var body = new JObject { ["phone"] = phone.Trim(), ["lang"] = _client.Language };
            if (!string.IsNullOrEmpty(country))
            {
                body["country"] = country;
            }

            var raw = await Call("publication_otp_request", body, RpcCallOptions.Write, ct).ConfigureAwait(false);
            return new PhoneCodeSent
            {
                RequestId = (string)raw["requestId"],
                Phone = (string)raw["phone"],
                ExpiresIn = (int?)raw["expiresIn"] ?? 0,
                ResendAfter = (int?)raw["resendAfter"] ?? 0,
                CodeLength = (int?)raw["codeLength"] ?? 0,
                Sandbox = (bool?)raw["sandbox"] ?? false,
                Raw = raw,
            };
        }

        public async Task<PhoneLoginResult> VerifyAsync(string phone, string code, bool link = true, string country = null, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ApiException(ApiError.Invalid("phone", "required"));
            }

            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ApiException(ApiError.Invalid("code", "required"));
            }

            await EnsureGuestAsync(ct).ConfigureAwait(false);
            var body = new JObject { ["phone"] = phone.Trim(), ["code"] = code.Trim(), ["link"] = link };
            if (!string.IsNullOrEmpty(country))
            {
                body["country"] = country;
            }

            var raw = await Call("publication_otp_verify", body, RpcCallOptions.Write, ct).ConfigureAwait(false);
            var loginKey = (string)raw["loginKey"];
            if (!string.IsNullOrEmpty(loginKey))
            {
                await _client.Session.AuthenticateCustomAsync(loginKey, null, false, ct).ConfigureAwait(false);
            }
            else
            {
                _client.Session.Adopt((string)raw["token"]);
            }

            raw.Remove("loginKey");
            raw.Remove("token");
            _client.AfterLogin();
            var result = new PhoneLoginResult
            {
                UserId = (string)raw["userId"],
                Username = (string)raw["username"],
                Phone = (string)raw["phone"],
                Created = (bool?)raw["created"] ?? false,
                Linked = (bool?)raw["linked"] ?? false,
                Raw = raw,
            };
            result.NeedsProfile = await NeedsProfileAsync(ct).ConfigureAwait(false);
            return result;
        }

        public async Task<bool> NeedsProfileAsync(CancellationToken ct = default)
        {
            var account = await Call("base_account_get", new JObject(), RpcCallOptions.Read, ct).ConfigureAwait(false);
            var name = (string)account.SelectToken("user.display_name");
            return string.IsNullOrEmpty(name);
        }

        private async Task EnsureGuestAsync(CancellationToken ct)
        {
            if (_client.Session.Current == null)
            {
                throw new ApiException(ApiError.NotLoggedIn());
            }

            await _client.Session.EnsureAsync(ct).ConfigureAwait(false);
        }

        private async Task<JObject> Call(string id, JObject body, RpcCallOptions options, CancellationToken ct)
        {
            var text = await _client.CallRpcAsync(id, body.ToString(Newtonsoft.Json.Formatting.None), options, ct).ConfigureAwait(false);
            return string.IsNullOrWhiteSpace(text) ? new JObject() : JObject.Parse(text);
        }
    }
}
