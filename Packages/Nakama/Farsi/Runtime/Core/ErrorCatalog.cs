using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NakamaFarsi.Sdk
{
    public sealed class ErrorCatalog
    {
        private static readonly Regex Placeholder = new Regex("\\{([A-Za-z0-9_]+)\\}", RegexOptions.CultureInvariant);

        private readonly object _gate = new object();
        private readonly IKeyValueStore _store;
        private readonly string _key;
        private Dictionary<string, Entry> _entries = new Dictionary<string, Entry>(StringComparer.Ordinal);

        public ErrorCatalog(IKeyValueStore store, string storePrefix = "nf.")
        {
            _store = store;
            _key = storePrefix + "errors";
            Restore();
        }

        public string Lang { get; private set; }

        public string ETag { get; private set; }

        public DateTimeOffset FetchedAt { get; private set; }

        public int CacheSeconds { get; private set; } = 300;

        public int Count
        {
            get
            {
                lock (_gate)
                {
                    return _entries.Count;
                }
            }
        }

        public bool IsFresh(DateTimeOffset now, string lang) => Count > 0 && Lang == lang && now - FetchedAt < TimeSpan.FromSeconds(CacheSeconds);

        public sealed class Entry
        {
            public long Status { get; set; }

            public string Message { get; set; }

            public int? RetryAfterSeconds { get; set; }
        }

        public bool TryResolve(string code, JObject meta, out Entry entry, out string message)
        {
            lock (_gate)
            {
                _entries.TryGetValue(code ?? string.Empty, out entry);
            }

            if (entry == null)
            {
                message = string.Empty;
                return false;
            }

            message = Fill(entry.Message, meta, Lang);
            return true;
        }

        public static string Fill(string template, JObject meta, string lang)
        {
            if (string.IsNullOrEmpty(template) || meta == null)
            {
                return template ?? string.Empty;
            }

            return Placeholder.Replace(template, m =>
            {
                var v = meta[m.Groups[1].Value];
                if (v == null)
                {
                    return m.Value;
                }

                var text = v.Type == JTokenType.Float || v.Type == JTokenType.Integer
                    ? Convert.ToDouble(((JValue)v).Value, CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture)
                    : (string)v;
                return lang == "fa" ? PersianDigits(text) : text;
            });
        }

        public static string PersianDigits(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            var chars = s.ToCharArray();
            for (var i = 0; i < chars.Length; i++)
            {
                if (chars[i] >= '0' && chars[i] <= '9')
                {
                    chars[i] = (char)('۰' + (chars[i] - '0'));
                }
            }

            return new string(chars);
        }

        public void Apply(string json, string etag, DateTimeOffset now)
        {
            var doc = JObject.Parse(json);
            var entries = new Dictionary<string, Entry>(StringComparer.Ordinal);
            if (doc["errors"] is JObject errors)
            {
                foreach (var p in errors.Properties())
                {
                    var o = p.Value as JObject;
                    if (o == null)
                    {
                        continue;
                    }

                    entries[p.Name] = new Entry
                    {
                        Status = o["status"]?.Type == JTokenType.Integer ? (long)o["status"] : 0,
                        Message = (string)o["message"] ?? string.Empty,
                        RetryAfterSeconds = o["retryAfterSeconds"]?.Type == JTokenType.Integer ? (int?)(int)o["retryAfterSeconds"] : null,
                    };
                }
            }

            lock (_gate)
            {
                _entries = entries;
                Lang = (string)doc["lang"];
                ETag = etag;
                FetchedAt = now;
                CacheSeconds = doc["cacheSeconds"]?.Type == JTokenType.Integer ? Math.Max(0, (int)doc["cacheSeconds"]) : 300;
            }

            if (_store != null)
            {
                var saved = new JObject { ["etag"] = etag, ["at"] = now.ToUnixTimeSeconds(), ["doc"] = doc };
                _store.Set(_key, saved.ToString(Formatting.None));
                _store.Save();
            }
        }

        public void Touch(DateTimeOffset now)
        {
            lock (_gate)
            {
                FetchedAt = now;
            }
        }

        public async Task RefreshAsync(NakamaFarsiOptions options, IHttpGet http, Func<string, string, Task<string>> rpc, string lang, DateTimeOffset now, CancellationToken ct = default)
        {
            if (http != null)
            {
                try
                {
                    var headers = new Dictionary<string, string> { ["Accept-Language"] = lang };
                    if (!string.IsNullOrEmpty(ETag) && Lang == lang)
                    {
                        headers["If-None-Match"] = ETag;
                    }

                    var url = options.BaseUrl + options.ErrorCatalogPath + "?lang=" + Uri.EscapeDataString(lang ?? string.Empty);
                    var res = await http.GetAsync(url, headers, options.TimeoutSeconds, ct).ConfigureAwait(false);
                    if (res.Status == 304)
                    {
                        Touch(now);
                        return;
                    }

                    if (res.Status == 200 && !string.IsNullOrEmpty(res.Body))
                    {
                        Apply(res.Body, res.ETag, now);
                        return;
                    }
                }
                catch (Exception)
                {
                }
            }

            if (rpc == null)
            {
                return;
            }

            try
            {
                var body = await rpc("devkit_error_catalog", new JObject { ["lang"] = lang }.ToString(Formatting.None)).ConfigureAwait(false);
                Apply(body, null, now);
            }
            catch (Exception)
            {
            }
        }

        private void Restore()
        {
            var raw = _store?.Get(_key);
            if (string.IsNullOrEmpty(raw))
            {
                return;
            }

            try
            {
                var saved = JObject.Parse(raw);
                var doc = saved["doc"] as JObject;
                if (doc == null)
                {
                    return;
                }

                var at = DateTimeOffset.FromUnixTimeSeconds((long?)saved["at"] ?? 0);
                Apply(doc.ToString(Formatting.None), (string)saved["etag"], at);
            }
            catch (Exception)
            {
            }
        }
    }
}
