using System;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Assets
{
    public static class AssetObjectJson
    {
        public static JObject Write(object source, AssetJsonOptions options = null) =>
            new AssetJsonWriter(options).WriteFields(source ?? throw new ArgumentNullException(nameof(source)), 0);

        public static AssetApplyResult Apply(JObject data, object target, AssetJsonOptions options = null)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            var applier = new AssetJsonApplier(options);
            applier.ApplyFields(data ?? new JObject(), target, string.Empty, 0);
            return new AssetApplyResult(applier.Warnings);
        }
    }
}
