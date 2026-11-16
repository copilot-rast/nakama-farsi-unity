using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace NakamaFarsi.Sdk
{
    public interface IKeyValueStore
    {
        string Get(string key);

        void Set(string key, string value);

        void Delete(string key);

        void Save();
    }

    public sealed class MemoryKeyValueStore : IKeyValueStore
    {
        private readonly Dictionary<string, string> _values = new Dictionary<string, string>(StringComparer.Ordinal);
        private readonly object _gate = new object();

        public int Saves { get; private set; }

        public string Get(string key)
        {
            lock (_gate)
            {
                return _values.TryGetValue(key, out var v) ? v : null;
            }
        }

        public void Set(string key, string value)
        {
            lock (_gate)
            {
                _values[key] = value;
            }
        }

        public void Delete(string key)
        {
            lock (_gate)
            {
                _values.Remove(key);
            }
        }

        public void Save()
        {
            lock (_gate)
            {
                Saves++;
            }
        }
    }

    public sealed class FileKeyValueStore : IKeyValueStore
    {
        private readonly string _path;
        private readonly object _gate = new object();
        private Dictionary<string, string> _values;
        private bool _dirty;

        public FileKeyValueStore(string path)
        {
            _path = path ?? throw new ArgumentNullException(nameof(path));
        }

        public string Get(string key)
        {
            lock (_gate)
            {
                Load();
                return _values.TryGetValue(key, out var v) ? v : null;
            }
        }

        public void Set(string key, string value)
        {
            lock (_gate)
            {
                Load();
                _values[key] = value;
                _dirty = true;
            }
        }

        public void Delete(string key)
        {
            lock (_gate)
            {
                Load();
                _dirty |= _values.Remove(key);
            }
        }

        public void Save()
        {
            lock (_gate)
            {
                if (!_dirty || _values == null)
                {
                    return;
                }

                var dir = Path.GetDirectoryName(_path);
                if (!string.IsNullOrEmpty(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                var tmp = _path + ".tmp";
                File.WriteAllText(tmp, JsonConvert.SerializeObject(_values));
                if (File.Exists(_path))
                {
                    File.Delete(_path);
                }

                File.Move(tmp, _path);
                _dirty = false;
            }
        }

        private void Load()
        {
            if (_values != null)
            {
                return;
            }

            _values = new Dictionary<string, string>(StringComparer.Ordinal);
            try
            {
                if (File.Exists(_path))
                {
                    _values = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(_path)) ?? _values;
                }
            }
            catch (Exception)
            {
            }
        }
    }

    public sealed class FallbackKeyValueStore : IKeyValueStore
    {
        private const string Marker = "\u0001file";
        private readonly IKeyValueStore _primary;
        private readonly IKeyValueStore _secondary;

        public FallbackKeyValueStore(IKeyValueStore primary, IKeyValueStore secondary, int maxPrimaryChars = 32 * 1024)
        {
            _primary = primary ?? throw new ArgumentNullException(nameof(primary));
            _secondary = secondary ?? throw new ArgumentNullException(nameof(secondary));
            MaxPrimaryChars = maxPrimaryChars;
        }

        public int MaxPrimaryChars { get; }

        public string Get(string key)
        {
            var v = _primary.Get(key);
            return v == Marker ? _secondary.Get(key) : v;
        }

        public void Set(string key, string value)
        {
            if (value != null && value.Length > MaxPrimaryChars)
            {
                _secondary.Set(key, value);
                _primary.Set(key, Marker);
                return;
            }

            try
            {
                _primary.Set(key, value);
                _secondary.Delete(key);
            }
            catch (Exception)
            {
                _secondary.Set(key, value);
                _primary.Set(key, Marker);
            }
        }

        public void Delete(string key)
        {
            _primary.Delete(key);
            _secondary.Delete(key);
        }

        public void Save()
        {
            _secondary.Save();
            _primary.Save();
        }
    }
}
