using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk
{
    public sealed record ApiError(long Status, string Code, JToken Meta, string Message)
    {
        public const string NetworkErrorCode = "NETWORK_ERROR";
        public const string InvalidResponseCode = "INVALID_RESPONSE";
        public const string NotInitializedCode = "SDK_NOT_INITIALIZED";
        public const string OtpNotRequestedCode = "SDK_OTP_NOT_REQUESTED";
        public const string NotSupportedCode = "SDK_NOT_SUPPORTED";
        public const string TooManyRequestsCode = "TOO_MANY_REQUESTS";
        public const string PhoneNewCodeSentCode = "PHONE_NEW_CODE_SENT";

        public static ApiError NotInitialized => new ApiError(0, NotInitializedCode, null, "PolicePatrolSdk.Initialize has not been called");

        public static ApiError OtpNotRequested => new ApiError(0, OtpNotRequestedCode, null, "Request an OTP code before verifying or resending it");

        public static ApiError NotSupported(string what) => new ApiError(0, NotSupportedCode, null, what + " is not available on this server");

        public string ServerCode { get; init; }

        public string Field { get; init; }

        public bool IsNetworkError => Code == NetworkErrorCode;

        public int? RetryAfterSeconds => Meta is JObject meta && meta["retryAfter"] is JValue value && (value.Type == JTokenType.Integer || value.Type == JTokenType.Float) ? (int?)(int)System.Math.Ceiling((double)value) : null;
    }
}
