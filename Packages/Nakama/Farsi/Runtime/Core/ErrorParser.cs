using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NakamaFarsi.Sdk
{
    public static class ErrorParser
    {
        private static readonly System.Collections.Generic.HashSet<string> Envelope = new System.Collections.Generic.HashSet<string>(StringComparer.Ordinal)
        {
            "code", "status", "message", "meta", "field", "lang", "retryAfterSeconds",
        };

        private static readonly Regex BareCode = new Regex("^[A-Z][A-Z0-9_]{2,}$", RegexOptions.CultureInvariant);

        public static ApiError Parse(string text, long httpStatus, ErrorCatalog catalog, string lang)
        {
            text = (text ?? string.Empty).Trim();
            if (text.StartsWith("{", StringComparison.Ordinal))
            {
                JObject json = null;
                try
                {
                    using (var reader = new JsonTextReader(new System.IO.StringReader(text)) { DateParseHandling = DateParseHandling.None })
                    {
                        json = JObject.Load(reader);
                    }
                }
                catch (JsonException)
                {
                }

                if (json != null && json["code"] != null)
                {
                    var code = (string)json["code"];
                    var status = json["status"] != null && json["status"].Type == JTokenType.Integer ? (long)json["status"] : httpStatus;
                    var meta = json["meta"] is JObject given ? (JObject)given.DeepClone() : new JObject();
                    foreach (var top in json.Properties())
                    {
                        if (!Envelope.Contains(top.Name) && meta[top.Name] == null)
                        {
                            meta[top.Name] = top.Value.DeepClone();
                        }
                    }
                    int? retry = json["retryAfterSeconds"] != null && json["retryAfterSeconds"].Type == JTokenType.Integer ? (int?)(int)json["retryAfterSeconds"] : null;
                    if (retry != null && meta["retryAfter"] == null)
                    {
                        meta["retryAfter"] = retry.Value;
                    }

                    var message = (string)json["message"];
                    if (string.IsNullOrEmpty(message) && catalog != null && catalog.TryResolve(code, meta, out var entry, out var filled))
                    {
                        message = filled;
                        if (status == 0 || (status == 500 && entry.Status != 0))
                        {
                            status = entry.Status;
                        }

                        retry = retry ?? entry.RetryAfterSeconds;
                    }

                    if (retry == null && meta["retryAfter"] != null && meta["retryAfter"].Type == JTokenType.Integer)
                    {
                        retry = (int)meta["retryAfter"];
                    }

                    return new ApiError(code, status, message, meta, retry, (string)json["field"], (string)json["lang"] ?? lang) { Raw = text };
                }
            }

            if (BareCode.IsMatch(text))
            {
                if (catalog != null && catalog.TryResolve(text, null, out var entry, out var filled))
                {
                    return new ApiError(text, entry.Status != 0 ? entry.Status : httpStatus, filled, null, entry.RetryAfterSeconds, null, lang) { Raw = text };
                }

                return new ApiError(text, httpStatus, string.Empty, null, null, null, lang) { Raw = text };
            }

            return new ApiError(CodeForStatus(httpStatus, text), httpStatus, string.Empty, null, null, null, lang) { Raw = text };
        }

        public static string CodeForStatus(long status, string text)
        {
            if (text != null && text.IndexOf("RPC function not found", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "RPC_NOT_FOUND";
            }

            switch (status)
            {
                case 400: return "BAD_REQUEST";
                case 401: return "UNAUTHORIZED";
                case 403: return "FORBIDDEN";
                case 404: return "NOT_FOUND";
                case 409: return "CONFLICT";
                case 429: return "TOO_MANY_REQUESTS";
                case 0: return ApiError.InvalidResponseCode;
                default: return "HTTP_" + status;
            }
        }
    }
}
