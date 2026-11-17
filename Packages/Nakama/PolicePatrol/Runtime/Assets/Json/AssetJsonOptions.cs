using System;
using System.Collections.Generic;

namespace PolicePatrol.Sdk.Assets
{
    public sealed class AssetJsonOptions
    {
        public IAssetReferenceHandler References { get; set; }

        public List<IAssetValueConverter> Converters { get; } = new List<IAssetValueConverter>();

        internal IAssetValueConverter FindConverter(Type type)
        {
            foreach (var converter in Converters)
            {
                if (converter.CanConvert(type))
                {
                    return converter;
                }
            }

            return null;
        }
    }
}
