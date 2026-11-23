using System;

namespace PolicePatrol.Sdk.Assets
{
    public sealed record AssetManifest(AssetManifestItem[] Items, string Etag, AssetClientPolicy Client, DateTimeOffset? ServerTime)
    {
        public bool NotModified { get; init; }

        public int Count { get; init; }
    }
}
