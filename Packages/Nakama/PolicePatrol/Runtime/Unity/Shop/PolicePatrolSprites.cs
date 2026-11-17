using System;
using System.Collections.Generic;
using PolicePatrol.Sdk.Shop;
using UnityEngine;
using UnityEngine.Networking;

namespace PolicePatrol.Sdk.Unity
{
    public static class PolicePatrolSprites
    {
        private static readonly Dictionary<string, Sprite> Loaded = new Dictionary<string, Sprite>();
        private static readonly Dictionary<string, List<Action<Sprite>>> Waiting = new Dictionary<string, List<Action<Sprite>>>();

        public static int TimeoutSeconds { get; set; } = 30;

        public static void LoadIcon(ShopItem item, Action<Sprite> onComplete) => Load(item?.IconUrl, onComplete);

        public static void LoadCover(ShopItem item, Action<Sprite> onComplete) => Load(item?.CoverUrl, onComplete);

        public static void Load(string url, Action<Sprite> onComplete)
        {
            if (string.IsNullOrEmpty(url))
            {
                onComplete?.Invoke(null);
                return;
            }

            var key = ContentUrls.CacheKey(url);
            if (Loaded.TryGetValue(key, out var cached) && cached != null)
            {
                onComplete?.Invoke(cached);
                return;
            }

            if (Waiting.TryGetValue(key, out var waiting))
            {
                waiting.Add(onComplete);
                return;
            }

            Waiting[key] = new List<Action<Sprite>> { onComplete };
            var web = UnityWebRequestTexture.GetTexture(url);
            web.timeout = TimeoutSeconds;
            web.SendWebRequest().completed += _ =>
            {
                var sprite = web.result == UnityWebRequest.Result.Success ? ToSprite(DownloadHandlerTexture.GetContent(web), key) : null;
                web.Dispose();
                if (sprite != null)
                {
                    Loaded[key] = sprite;
                }

                var callbacks = Waiting[key];
                Waiting.Remove(key);
                foreach (var callback in callbacks)
                {
                    callback?.Invoke(sprite);
                }
            };
        }

        public static void Clear()
        {
            foreach (var sprite in Loaded.Values)
            {
                if (sprite != null)
                {
                    UnityEngine.Object.Destroy(sprite.texture);
                    UnityEngine.Object.Destroy(sprite);
                }
            }

            Loaded.Clear();
        }

        private static Sprite ToSprite(Texture2D texture, string name)
        {
            if (texture == null)
            {
                return null;
            }

            var sprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            sprite.name = name;
            return sprite;
        }
    }
}
