using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Assets;
using UnityEditor;
using UnityEngine;

namespace PolicePatrol.Sdk.Editor
{
    public sealed class EditorReferences : IAssetReferenceHandler
    {
        private readonly Dictionary<ScriptableObject, string> _idByAsset = new Dictionary<ScriptableObject, string>();
        private readonly Dictionary<string, ScriptableObject> _assetById = new Dictionary<string, ScriptableObject>(StringComparer.Ordinal);
        private readonly Dictionary<string, UnityEngine.Object> _objects = new Dictionary<string, UnityEngine.Object>(StringComparer.Ordinal);

        public EditorReferences(IEnumerable<ScannedAsset> assets)
        {
            foreach (var asset in assets)
            {
                _idByAsset[asset.Asset] = asset.AssetId;
                _assetById[asset.AssetId] = asset.Asset;
            }
        }

        public IReadOnlyDictionary<string, UnityEngine.Object> Objects => _objects;

        public bool IsReference(Type type) => typeof(UnityEngine.Object).IsAssignableFrom(type);

        public JToken Write(object value)
        {
            var target = value as UnityEngine.Object;
            if (target == null)
            {
                return JValue.CreateNull();
            }

            if (target is ScriptableObject asset && _idByAsset.TryGetValue(asset, out var assetId))
            {
                return AssetReferenceJson.Asset(assetId);
            }

            if (!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(target, out string guid, out long fileId) || string.IsNullOrEmpty(guid))
            {
                return JValue.CreateNull();
            }

            var key = guid + ":" + fileId.ToString(CultureInfo.InvariantCulture);
            _objects[key] = target;
            return AssetReferenceJson.Object(key, AssetDatabase.GetAssetPath(target));
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
            if (AssetReferenceJson.TryGetAsset(token, out var assetId) && _assetById.TryGetValue(assetId, out var asset))
            {
                found = asset;
            }
            else if (AssetReferenceJson.TryGetObject(token, out var key))
            {
                found = Resolve(key);
            }

            if (found == null || !type.IsInstanceOfType(found))
            {
                return false;
            }

            value = found;
            return true;
        }

        private UnityEngine.Object Resolve(string key)
        {
            if (_objects.TryGetValue(key, out var known))
            {
                return known;
            }

            var colon = key.LastIndexOf(':');
            if (colon <= 0 || !long.TryParse(key.Substring(colon + 1), NumberStyles.Integer, CultureInfo.InvariantCulture, out var fileId))
            {
                return null;
            }

            var path = AssetDatabase.GUIDToAssetPath(key.Substring(0, colon));
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }

            foreach (var candidate in AssetDatabase.LoadAllAssetsAtPath(path))
            {
                if (candidate != null && AssetDatabase.TryGetGUIDAndLocalFileIdentifier(candidate, out string _, out long candidateId) && candidateId == fileId)
                {
                    _objects[key] = candidate;
                    return candidate;
                }
            }

            return null;
        }
    }
}
