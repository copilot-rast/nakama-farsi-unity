using System;
using System.Collections.Generic;
using UnityEngine;

namespace PolicePatrol.Sdk.Unity
{
    public sealed class PolicePatrolAssetRegistry : ScriptableObject
    {
        public const string ResourceName = "PolicePatrolAssetRegistry";

        [SerializeField] private List<AssetEntry> assets = new List<AssetEntry>();
        [SerializeField] private List<ObjectEntry> objects = new List<ObjectEntry>();

        private Dictionary<string, ScriptableObject> _assetById;
        private Dictionary<ScriptableObject, string> _idByAsset;
        private Dictionary<string, UnityEngine.Object> _objectByKey;
        private Dictionary<UnityEngine.Object, string> _keyByObject;

        public IReadOnlyList<AssetEntry> Assets => assets;

        public IReadOnlyList<ObjectEntry> Objects => objects;

        public static PolicePatrolAssetRegistry Load() => Resources.Load<PolicePatrolAssetRegistry>(ResourceName);

        public ScriptableObject FindAsset(string assetId)
        {
            Index();
            return assetId != null && _assetById.TryGetValue(assetId, out var asset) ? asset : null;
        }

        public string FindAssetId(ScriptableObject asset)
        {
            Index();
            return asset != null && _idByAsset.TryGetValue(asset, out var id) ? id : null;
        }

        public UnityEngine.Object FindObject(string key)
        {
            Index();
            return key != null && _objectByKey.TryGetValue(key, out var value) ? value : null;
        }

        public string FindObjectKey(UnityEngine.Object value)
        {
            Index();
            return value != null && _keyByObject.TryGetValue(value, out var key) ? key : null;
        }

        public void Replace(List<AssetEntry> newAssets, List<ObjectEntry> newObjects)
        {
            assets = newAssets ?? new List<AssetEntry>();
            objects = newObjects ?? new List<ObjectEntry>();
            _assetById = null;
        }

        private void Index()
        {
            if (_assetById != null)
            {
                return;
            }

            _assetById = new Dictionary<string, ScriptableObject>(StringComparer.Ordinal);
            _idByAsset = new Dictionary<ScriptableObject, string>();
            foreach (var entry in assets)
            {
                if (entry?.asset != null && !string.IsNullOrEmpty(entry.assetId))
                {
                    _assetById[entry.assetId] = entry.asset;
                    _idByAsset[entry.asset] = entry.assetId;
                }
            }

            _objectByKey = new Dictionary<string, UnityEngine.Object>(StringComparer.Ordinal);
            _keyByObject = new Dictionary<UnityEngine.Object, string>();
            foreach (var entry in objects)
            {
                if (entry?.value != null && !string.IsNullOrEmpty(entry.key))
                {
                    _objectByKey[entry.key] = entry.value;
                    _keyByObject[entry.value] = entry.key;
                }
            }
        }

        [Serializable]
        public sealed class AssetEntry
        {
            public string assetId;
            public ScriptableObject asset;
        }

        [Serializable]
        public sealed class ObjectEntry
        {
            public string key;
            public UnityEngine.Object value;
        }
    }
}
