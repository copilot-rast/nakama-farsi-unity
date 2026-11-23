using System;

namespace PolicePatrol.Sdk.Assets
{
    public sealed record AssetCacheState(AssetClientPolicy Policy, DateTimeOffset? LoadedAt, DateTimeOffset? ServerTime);
}
