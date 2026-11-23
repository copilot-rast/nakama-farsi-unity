using System;

namespace PolicePatrol.Sdk.Assets
{
    public sealed record AssetClientPolicy(bool RequireOnline, int MaxCacheAgeHours)
    {
        public static AssetClientPolicy None => new AssetClientPolicy(false, 0);

        public TimeSpan? MaxCacheAge => MaxCacheAgeHours > 0 ? TimeSpan.FromHours(MaxCacheAgeHours) : (TimeSpan?)null;
    }
}
