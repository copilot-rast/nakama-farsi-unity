using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Assets;
using UnityEngine;

namespace PolicePatrol.Sdk.Unity
{
    public sealed class UnityAssetConverters : IAssetValueConverter
    {
        public bool CanConvert(Type type) =>
            type == typeof(LayerMask) || type == typeof(Vector2Int) || type == typeof(Vector3Int) || type == typeof(Rect)
            || type == typeof(Bounds) || type == typeof(AnimationCurve) || type == typeof(Gradient);

        public JToken Write(object value)
        {
            switch (value)
            {
                case LayerMask mask:
                    return new JValue(mask.value);
                case Vector2Int v:
                    return new JObject { ["x"] = v.x, ["y"] = v.y };
                case Vector3Int v:
                    return new JObject { ["x"] = v.x, ["y"] = v.y, ["z"] = v.z };
                case Rect r:
                    return new JObject { ["x"] = r.x, ["y"] = r.y, ["width"] = r.width, ["height"] = r.height };
                case Bounds b:
                    return new JObject { ["center"] = WriteVector(b.center), ["size"] = WriteVector(b.size) };
                case AnimationCurve curve:
                    return new JObject
                    {
                        ["keys"] = new JArray(curve.keys.Select(k => new JObject
                        {
                            ["time"] = k.time, ["value"] = k.value, ["inTangent"] = k.inTangent, ["outTangent"] = k.outTangent,
                            ["inWeight"] = k.inWeight, ["outWeight"] = k.outWeight, ["weightedMode"] = (int)k.weightedMode,
                        })),
                        ["preWrapMode"] = (int)curve.preWrapMode,
                        ["postWrapMode"] = (int)curve.postWrapMode,
                    };
                case Gradient gradient:
                    return new JObject
                    {
                        ["mode"] = (int)gradient.mode,
                        ["colorKeys"] = new JArray(gradient.colorKeys.Select(k => new JObject { ["color"] = WriteColor(k.color), ["time"] = k.time })),
                        ["alphaKeys"] = new JArray(gradient.alphaKeys.Select(k => new JObject { ["alpha"] = k.alpha, ["time"] = k.time })),
                    };
                default:
                    return JValue.CreateNull();
            }
        }

        public object Read(JToken token, Type type, object current)
        {
            if (token == null || token.Type == JTokenType.Null)
            {
                return current;
            }

            if (type == typeof(LayerMask))
            {
                return (LayerMask)token.Value<int>();
            }

            if (!(token is JObject json))
            {
                return current;
            }

            if (type == typeof(Vector2Int))
            {
                return new Vector2Int(Int(json, "x"), Int(json, "y"));
            }

            if (type == typeof(Vector3Int))
            {
                return new Vector3Int(Int(json, "x"), Int(json, "y"), Int(json, "z"));
            }

            if (type == typeof(Rect))
            {
                return new Rect(Float(json, "x"), Float(json, "y"), Float(json, "width"), Float(json, "height"));
            }

            if (type == typeof(Bounds))
            {
                return new Bounds(ReadVector(json["center"]), ReadVector(json["size"]));
            }

            if (type == typeof(AnimationCurve))
            {
                return ReadCurve(json);
            }

            return type == typeof(Gradient) ? ReadGradient(json) : current;
        }

        private static AnimationCurve ReadCurve(JObject json)
        {
            var keys = (json["keys"] as JArray ?? new JArray()).OfType<JObject>().Select(k => new Keyframe(
                Float(k, "time"), Float(k, "value"), Float(k, "inTangent"), Float(k, "outTangent"), Float(k, "inWeight"), Float(k, "outWeight"))
            {
                weightedMode = (WeightedMode)Int(k, "weightedMode"),
            }).ToArray();
            return new AnimationCurve(keys)
            {
                preWrapMode = (WrapMode)Int(json, "preWrapMode"),
                postWrapMode = (WrapMode)Int(json, "postWrapMode"),
            };
        }

        private static Gradient ReadGradient(JObject json) => new Gradient
        {
            mode = (GradientMode)Int(json, "mode"),
            colorKeys = (json["colorKeys"] as JArray ?? new JArray()).OfType<JObject>()
                .Select(k => new GradientColorKey(ReadColor(k["color"]), Float(k, "time"))).ToArray(),
            alphaKeys = (json["alphaKeys"] as JArray ?? new JArray()).OfType<JObject>()
                .Select(k => new GradientAlphaKey(Float(k, "alpha"), Float(k, "time"))).ToArray(),
        };

        private static JObject WriteVector(Vector3 v) => new JObject { ["x"] = v.x, ["y"] = v.y, ["z"] = v.z };

        private static Vector3 ReadVector(JToken token) =>
            token is JObject v ? new Vector3(Float(v, "x"), Float(v, "y"), Float(v, "z")) : Vector3.zero;

        private static JObject WriteColor(Color c) => new JObject { ["r"] = c.r, ["g"] = c.g, ["b"] = c.b, ["a"] = c.a };

        private static Color ReadColor(JToken token) =>
            token is JObject c ? new Color(Float(c, "r"), Float(c, "g"), Float(c, "b"), Float(c, "a")) : Color.white;

        private static float Float(JObject json, string name) => json[name] is JValue value && value.Type != JTokenType.Null ? value.Value<float>() : 0f;

        private static int Int(JObject json, string name) => json[name] is JValue value && value.Type != JTokenType.Null ? value.Value<int>() : 0;
    }
}
