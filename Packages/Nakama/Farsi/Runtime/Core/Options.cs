using System;

namespace NakamaFarsi.Sdk
{
    public sealed class NakamaFarsiOptions
    {
        public string Scheme { get; set; } = "http";
        public string Host { get; set; } = "127.0.0.1";
        public int Port { get; set; } = 7350;
        public string ServerKey { get; set; } = "defaultkey";

        public string HttpKey { get; set; }

        public string Language { get; set; } = "fa";

        public int TimeoutSeconds { get; set; } = 15;

        public bool UseSocket { get; set; } = true;

        public int ReadRetries { get; set; } = 1;

        public int RefreshAheadSeconds { get; set; } = 120;

        public string StorePrefix { get; set; } = "nf.";

        public string ErrorCatalogPath { get; set; } = "/v2/devkit/errors";

        public bool Logging { get; set; }

        public string BaseUrl => Scheme + "://" + Host + ":" + Port;

        public static NakamaFarsiOptions FromUrl(string baseUrl, string serverKey)
        {
            var uri = new Uri(baseUrl.TrimEnd('/'));
            return new NakamaFarsiOptions
            {
                Scheme = uri.Scheme,
                Host = uri.Host,
                Port = uri.IsDefaultPort ? (uri.Scheme == "https" ? 443 : 80) : uri.Port,
                ServerKey = serverKey,
            };
        }
    }
}
