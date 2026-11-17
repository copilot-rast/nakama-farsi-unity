using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk
{
    public sealed class ItemKeys
    {
        private readonly object _gate = new object();
        private readonly Dictionary<string, string> _toServer = new Dictionary<string, string>(StringComparer.Ordinal);
        private readonly Dictionary<string, string> _toGame = new Dictionary<string, string>(StringComparer.Ordinal);

        public void Learn(string serverKey, string gameId)
        {
            if (string.IsNullOrEmpty(serverKey))
            {
                return;
            }

            lock (_gate)
            {
                if (!string.IsNullOrEmpty(gameId))
                {
                    _toServer[gameId] = serverKey;
                    _toGame[serverKey] = gameId;
                }

                _toServer[serverKey] = serverKey;
            }
        }

        public string LearnItem(JToken item)
        {
            var key = (string)item?["key"];
            var gameId = (string)item?["metadata"]?["gameId"] ?? (string)item?["gameId"];
            Learn(key, gameId);
            return ToGame(key);
        }

        public string ToServer(string gameKey)
        {
            if (string.IsNullOrEmpty(gameKey))
            {
                return gameKey;
            }

            lock (_gate)
            {
                if (_toServer.TryGetValue(gameKey, out var key))
                {
                    return key;
                }
            }

            return gameKey.ToLowerInvariant();
        }

        public string ToGame(string serverKey)
        {
            if (string.IsNullOrEmpty(serverKey))
            {
                return serverKey;
            }

            lock (_gate)
            {
                return _toGame.TryGetValue(serverKey, out var id) ? id : serverKey;
            }
        }
    }
}
