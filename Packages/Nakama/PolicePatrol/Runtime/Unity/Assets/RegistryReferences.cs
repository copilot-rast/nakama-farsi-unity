using System;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Assets;
using UnityEngine;

namespace PolicePatrol.Sdk.Unity
{
    public sealed class RegistryReferences : IAssetReferenceHandler
    {
        private readonly PolicePatrolAssetRegistry _registry;

        public RegistryReferences(PolicePatrolAssetRegistry registry)
        {
            _registry = registry;
        }

        public bool IsReference(Type type) => typeof(UnityEngine.Object).IsAssignableFrom(type);

        public JToken Write(object value)
        {
            if (!(value is UnityEngine.Object unityObject) || unityObject == null || _registry == null)
            {
                return JValue.CreateNull();
            }

            var assetId = unityObject is ScriptableObject asset ? _registry.FindAssetId(asset) : null;
            if (assetId != null)
            {
                return AssetReferenceJson.Asset(assetId);
            }

            var key = _registry.FindObjectKey(unityObject);
            return key != null ? AssetReferenceJson.Object(key, unityObject.name) : JValue.CreateNull();
        }

        public bool TryRead(JToken token, Type type, object current, out object value)
        {
            value = current;
            if (token == null || token.Type == JTokenType.Null)
            {
                value = null;
                return true;
            }

            UnityEngine.Object found = null;
            if (_registry != null && AssetReferenceJson.TryGetAsset(token, out var assetId))
            {
                found = _registry.FindAsset(assetId);
            }
            else if (_registry != null && AssetReferenceJson.TryGetObject(token, out var key))
            {
                found = _registry.FindObject(key);
            }

            if (found == null || !type.IsInstanceOfType(found))
            {
                return false;
            }

            value = found;
            return true;
        }
    }
}
