using UnityEngine.Networking;

namespace UnityEngine
{
    public class Texture : Object
    {
        public int width => 0;

        public int height => 0;
    }

    public sealed class Texture2D : Texture
    {
    }

    public sealed class Sprite : Object
    {
        public Texture2D texture => null;

        public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot) => new Sprite();
    }
}

namespace UnityEngine.Networking
{
    public sealed class DownloadHandlerTexture : DownloadHandler
    {
        public static Texture2D GetContent(UnityWebRequest www) => null;
    }

    public static class UnityWebRequestTexture
    {
        public static UnityWebRequest GetTexture(string uri) => new UnityWebRequest(uri, "GET");
    }
}
