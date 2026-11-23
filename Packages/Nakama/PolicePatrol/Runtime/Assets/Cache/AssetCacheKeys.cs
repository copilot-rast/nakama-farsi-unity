using System.Security.Cryptography;
using System.Text;

namespace PolicePatrol.Sdk.Assets
{
    internal static class AssetCacheKeys
    {
        public static string Index(string folder) => "index:" + (folder ?? "*");

        public static string State(string folder) => "state:" + (folder ?? "*");

        public static string FileName(string key)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(key));
                var builder = new StringBuilder(bytes.Length * 2);
                foreach (var value in bytes)
                {
                    builder.Append(value.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
