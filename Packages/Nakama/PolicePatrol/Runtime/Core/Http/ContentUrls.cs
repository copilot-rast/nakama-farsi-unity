using System;
using System.Text;

namespace PolicePatrol.Sdk
{
    public static class ContentUrls
    {
        public static string CacheKey(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return url;
            }

            var query = url.IndexOf('?');
            return query < 0 ? url : url.Substring(0, query);
        }

        public static string CollapseSlashes(string url)
        {
            if (string.IsNullOrEmpty(url) || !url.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                return url;
            }

            var scheme = url.IndexOf("://", StringComparison.Ordinal);
            if (scheme < 0)
            {
                return url;
            }

            var query = url.IndexOf('?');
            var end = query < 0 ? url.Length : query;
            var builder = new StringBuilder(url.Length);
            builder.Append(url, 0, scheme + 3);
            for (var i = scheme + 3; i < end; i++)
            {
                if (url[i] == '/' && builder[builder.Length - 1] == '/')
                {
                    continue;
                }

                builder.Append(url[i]);
            }

            builder.Append(url, end, url.Length - end);
            return builder.ToString();
        }
    }
}
