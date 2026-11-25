using System;
using Newtonsoft.Json.Linq;

namespace NakamaFarsi.Sdk
{
    public sealed class ApiError
    {
        public const string NetworkErrorCode = "NETWORK_ERROR";
        public const string TimeoutCode = "TIMEOUT";
        public const string InvalidResponseCode = "INVALID_RESPONSE";
        public const string NotInitializedCode = "SDK_NOT_INITIALIZED";
        public const string NotLoggedInCode = "SDK_NOT_LOGGED_IN";
        public const string SessionExpiredCode = "SESSION_EXPIRED";
        public const string InvalidArgumentCode = "SDK_INVALID_ARGUMENT";

        public ApiError(string code, long status, string message, JObject meta = null, int? retryAfterSeconds = null, string field = null, string lang = null)
        {
            Code = string.IsNullOrEmpty(code) ? "UNKNOWN" : code;
            Status = status;
            Message = message ?? string.Empty;
            Meta = meta ?? new JObject();
            RetryAfterSeconds = retryAfterSeconds ?? ReadRetry(Meta);
            Field = field;
            Lang = lang;
        }

        public string Code { get; }

        public long Status { get; }

        public string Message { get; }

        public JObject Meta { get; }

        public int? RetryAfterSeconds { get; }

        public string Field { get; }

        public string Lang { get; }

        public string Raw { get; internal set; }

        public bool IsNetworkError => Code == NetworkErrorCode || Code == TimeoutCode;

        public static readonly System.Collections.Generic.HashSet<string> NotRetryableCodes = new System.Collections.Generic.HashSet<string>(StringComparer.Ordinal)
        {
            "STORE_CONFIGURATION_REJECTED",
            "METHOD_UNAVAILABLE",
            "STORE_MODE_CHANGED",
        };

        public bool IsNotRetryableCode => NotRetryableCodes.Contains(Code);

        public bool IsRetryable => !IsNotRetryableCode && (IsNetworkError || Status == 408 || Status == 429 || Status >= 500);

        public static ApiError Network(string detail) => new ApiError(NetworkErrorCode, 0, string.Empty) { Raw = detail };

        public static ApiError Timeout(int seconds) => new ApiError(TimeoutCode, 0, string.Empty, new JObject { ["seconds"] = seconds });

        public static ApiError InvalidResponse(string detail) => new ApiError(InvalidResponseCode, 0, string.Empty) { Raw = detail };

        public static ApiError NotLoggedIn() => new ApiError(NotLoggedInCode, 401, string.Empty);

        public static ApiError Invalid(string field, string detail) => new ApiError(InvalidArgumentCode, 0, detail ?? string.Empty, null, null, field);

        public override string ToString() => Code + " (" + Status + ")" + (string.IsNullOrEmpty(Message) ? string.Empty : ": " + Message);

        private static int? ReadRetry(JObject meta)
        {
            var v = meta?["retryAfter"] ?? meta?["retryAfterSeconds"];
            if (v == null)
            {
                return null;
            }

            try
            {
                return v.Type == JTokenType.Integer || v.Type == JTokenType.Float ? (int?)Math.Ceiling((double)v) : int.TryParse((string)v, out var n) ? (int?)n : null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public sealed class ApiException : Exception
    {
        public ApiException(ApiError error, Exception inner = null)
            : base(error?.ToString(), inner)
        {
            Error = error;
        }

        public ApiError Error { get; }
    }

    public sealed class ApiResult<T>
    {
        private ApiResult(T data, ApiError error)
        {
            Data = data;
            Error = error;
        }

        public T Data { get; }

        public ApiError Error { get; }

        public bool IsSuccess => Error == null;

        public static ApiResult<T> Ok(T data) => new ApiResult<T>(data, null);

        public static ApiResult<T> Fail(ApiError error) => new ApiResult<T>(default, error ?? new ApiError("UNKNOWN", 0, string.Empty));
    }
}
