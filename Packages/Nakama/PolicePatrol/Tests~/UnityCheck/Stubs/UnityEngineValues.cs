namespace UnityEngine
{
    public struct Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector3 zero => default;
    }

    public struct Color
    {
        public float r;
        public float g;
        public float b;
        public float a;

        public Color(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public static Color white => new Color(1, 1, 1, 1);
    }

    public struct Vector2Int
    {
        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int x { get; set; }

        public int y { get; set; }
    }

    public struct Vector3Int
    {
        public Vector3Int(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public int x { get; set; }

        public int y { get; set; }

        public int z { get; set; }
    }

    public struct Rect
    {
        public Rect(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public float x { get; set; }

        public float y { get; set; }

        public float width { get; set; }

        public float height { get; set; }
    }

    public struct Bounds
    {
        public Bounds(Vector3 center, Vector3 size)
        {
            this.center = center;
            this.size = size;
        }

        public Vector3 center { get; set; }

        public Vector3 size { get; set; }
    }

    public struct LayerMask
    {
        public int value { get; set; }

        public static implicit operator int(LayerMask mask) => mask.value;

        public static implicit operator LayerMask(int value) => new LayerMask { value = value };
    }

    public enum WrapMode
    {
        Default = 0,
        Once = 1,
        Loop = 2,
    }

    public enum WeightedMode
    {
        None = 0,
        In = 1,
        Out = 2,
        Both = 3,
    }

    public struct Keyframe
    {
        public Keyframe(float time, float value, float inTangent, float outTangent, float inWeight, float outWeight)
        {
            this.time = time;
            this.value = value;
            this.inTangent = inTangent;
            this.outTangent = outTangent;
            this.inWeight = inWeight;
            this.outWeight = outWeight;
            weightedMode = WeightedMode.None;
        }

        public float time { get; set; }

        public float value { get; set; }

        public float inTangent { get; set; }

        public float outTangent { get; set; }

        public float inWeight { get; set; }

        public float outWeight { get; set; }

        public WeightedMode weightedMode { get; set; }
    }

    public class AnimationCurve
    {
        public AnimationCurve(params Keyframe[] keys)
        {
            this.keys = keys;
        }

        public Keyframe[] keys { get; set; }

        public WrapMode preWrapMode { get; set; }

        public WrapMode postWrapMode { get; set; }
    }

    public enum GradientMode
    {
        Blend = 0,
        Fixed = 1,
    }

    public struct GradientColorKey
    {
        public Color color;
        public float time;

        public GradientColorKey(Color col, float time)
        {
            color = col;
            this.time = time;
        }
    }

    public struct GradientAlphaKey
    {
        public float alpha;
        public float time;

        public GradientAlphaKey(float alpha, float time)
        {
            this.alpha = alpha;
            this.time = time;
        }
    }

    public class Gradient
    {
        public GradientColorKey[] colorKeys { get; set; } = new GradientColorKey[0];

        public GradientAlphaKey[] alphaKeys { get; set; } = new GradientAlphaKey[0];

        public GradientMode mode { get; set; }
    }
}
