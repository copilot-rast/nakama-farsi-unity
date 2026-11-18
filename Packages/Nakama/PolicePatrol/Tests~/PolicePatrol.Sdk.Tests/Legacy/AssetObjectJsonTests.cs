using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Assets;
using Xunit;

namespace PolicePatrol.Sdk.Tests;

public sealed class AssetObjectJsonTests
{
    private static readonly Card Bmw = new() { Id = "bmw" };
    private static readonly Card Benz = new() { Id = "benz" };
    private static readonly Sprite Icon = new() { Key = "icon-guid:21300000", Path = "Assets/Icons/m3.png" };

    [Fact]
    public void Writing_follows_unity_field_rules_and_keeps_declaration_order()
    {
        var json = AssetObjectJson.Write(Sample(), Options());

        json.Properties().Select(p => p.Name).Should().Equal(
            "baseNote", "id", "title", "speed", "ratio", "kind", "flags", "category", "icon", "prices", "levels", "position", "secret");
        json.ToString(Formatting.None).Should().Be(
            "{\"baseNote\":\"base\",\"id\":\"m3\",\"title\":\"M3\",\"speed\":0.3,\"ratio\":1.0,\"kind\":\"Sport\",\"flags\":3," +
            "\"category\":{\"$asset\":\"bmw\"},\"icon\":{\"$object\":\"icon-guid:21300000\",\"path\":\"Assets/Icons/m3.png\"}," +
            "\"prices\":[{\"currency\":{\"$asset\":\"benz\"},\"amount\":1500}],\"levels\":[1,2],\"position\":{\"x\":1.5,\"y\":-2.0},\"secret\":7}");
    }

    [Fact]
    public void Applying_written_json_rebuilds_the_same_values_and_links()
    {
        var json = AssetObjectJson.Write(Sample(), Options());
        var target = new CarData();

        var result = AssetObjectJson.Apply(json, target, Options());

        result.IsClean.Should().BeTrue(string.Join("; ", result.Warnings));
        AssetObjectJson.Write(target, Options()).ToString().Should().Be(json.ToString());
        target.category.Should().BeSameAs(Bmw);
        target.icon.Should().BeSameAs(Icon);
        target.prices[0].currency.Should().BeSameAs(Benz);
    }

    [Fact]
    public void Applying_keeps_what_the_json_does_not_change_or_cannot_resolve()
    {
        var target = Sample();
        var data = JObject.Parse("""
            {
              "title": "M3 GTR",
              "speed": "fast",
              "kind": "Unknown",
              "category": { "$asset": "not-in-build" },
              "icon": { "$object": "missing:1", "path": "Assets/gone.png" },
              "prices": [ { "amount": 2000 }, { "currency": { "$asset": "bmw" }, "amount": 10 } ],
              "levels": [ 5 ],
              "extra": 1
            }
            """);

        var result = AssetObjectJson.Apply(data, target, Options());

        target.title.Should().Be("M3 GTR");
        target.speed.Should().Be(0.3f);
        target.kind.Should().Be(Kind.Sport);
        target.category.Should().BeSameAs(Bmw);
        target.icon.Should().BeSameAs(Icon);
        target.prices.Should().HaveCount(2);
        target.prices[0].currency.Should().BeSameAs(Benz, "fields missing from an item keep the item's current value");
        target.prices[0].amount.Should().Be(2000);
        target.prices[1].currency.Should().BeSameAs(Bmw);
        target.levels.Should().Equal(5);
        target.id.Should().Be("m3");
        result.Warnings.Should().HaveCount(4).And.Contain(w => w.StartsWith("speed:")).And.Contain(w => w.StartsWith("category:"));
    }

    [Fact]
    public void A_null_string_is_written_and_hashed_as_json_null()
    {
        var car = Sample();
        car.title = null;

        var json = AssetObjectJson.Write(car, Options());

        json["title"]!.Type.Should().Be(JTokenType.Null);
        AssetCanonicalJson.Canonical(new JObject { ["a"] = new JValue((string)null) }).Should().Be("{\"a\":null}");
        AssetCanonicalJson.Hash(json).Should().HaveLength(64);
    }

    [Fact]
    public void Canonical_hash_matches_the_server()
    {
        var data = AssetJsonText.ParseExact("""{ "c": "\n\u0001é", "b": 1.50, "a": [1, { "y": null, "x": "\"q\\" }] }""");

        AssetCanonicalJson.Canonical(data).Should().Be("""{"a":[1,{"x":"\"q\\","y":null}],"b":1.50,"c":"\n\u0001é"}""");
        AssetCanonicalJson.Hash(data).Should().Be("a98b659b18ee628c6048678138338b6f547e6ce581f8fe1594b5073f7f32d4d1");
    }

    [Fact]
    public void Canonical_numbers_use_the_same_text_as_the_json_that_is_sent()
    {
        var json = AssetObjectJson.Write(Sample(), Options());
        var sent = json.ToString(Formatting.None);

        AssetCanonicalJson.Hash(AssetJsonText.ParseExact(sent)).Should().Be(AssetCanonicalJson.Hash(json));
        AssetJsonText.ParseExact("{\"big\":1e40}")["big"]!.Value<double>().Should().Be(1e40, "numbers too big for decimal still parse");
        AssetCanonicalJson.Canonical(new JObject { ["n"] = float.NaN }).Should().Be("{\"n\":\"NaN\"}");
    }

    private static CarData Sample() => new CarData
    {
        baseNote = "base",
        id = "m3",
        title = "M3",
        speed = 0.3f,
        ratio = 1.0,
        kind = Kind.Sport,
        flags = (Kind)3,
        category = Bmw,
        icon = Icon,
        prices = new[] { new Price { currency = Benz, amount = 1500 } },
        levels = new List<int> { 1, 2 },
        position = new Vec { x = 1.5f, y = -2f },
        notSaved = 9,
        lookup = new Dictionary<string, int> { ["a"] = 1 },
    }.WithSecret(7);

    private static AssetJsonOptions Options() => new() { References = new FakeReferences(new UnityThing[] { Bmw, Benz, Icon }) };

    public enum Kind
    {
        Street = 0,
        Sport = 1,
    }

    public abstract class UnityThing
    {
    }

    public sealed class Card : UnityThing
    {
        public string Id { get; init; } = string.Empty;
    }

    public sealed class Sprite : UnityThing
    {
        public string Key { get; init; } = string.Empty;

        public string Path { get; init; } = string.Empty;
    }

    public class BaseData : UnityThing
    {
        public string baseNote = string.Empty;
    }

    public sealed class CarData : BaseData
    {
        public static int Count = 1;
        public readonly int Fixed = 1;
        public string id = string.Empty;
        public string title = string.Empty;
        public float speed;
        public double ratio;
        public Kind kind;
        public Kind flags;
        public Card category;
        public Sprite icon;
        public Price[] prices = Array.Empty<Price>();
        public List<int> levels = new();
        public Vec position;
        [NonSerialized] public int notSaved;
        public Dictionary<string, int> lookup = new();
        [SerializeField] private int secret;

        public int Secret => secret;

        public CarData WithSecret(int value)
        {
            secret = value;
            return this;
        }
    }

    [Serializable]
    public sealed class Price
    {
        public Card currency;
        public long amount;
    }

    [Serializable]
    public struct Vec
    {
        public float x;
        public float y;
    }

    private sealed class FakeReferences : IAssetReferenceHandler
    {
        private readonly UnityThing[] _known;

        public FakeReferences(UnityThing[] known) => _known = known;

        public bool IsReference(Type type) => typeof(UnityThing).IsAssignableFrom(type);

        public JToken Write(object value) => value switch
        {
            null => JValue.CreateNull(),
            Card card => AssetReferenceJson.Asset(card.Id),
            Sprite sprite => AssetReferenceJson.Object(sprite.Key, sprite.Path),
            _ => JValue.CreateNull(),
        };

        public bool TryRead(JToken token, Type type, object current, out object value)
        {
            value = current;
            if (token.Type == JTokenType.Null)
            {
                value = null;
                return true;
            }

            UnityThing found = null;
            if (AssetReferenceJson.TryGetAsset(token, out var id))
            {
                found = _known.OfType<Card>().FirstOrDefault(c => c.Id == id);
            }
            else if (AssetReferenceJson.TryGetObject(token, out var key))
            {
                found = _known.OfType<Sprite>().FirstOrDefault(s => s.Key == key);
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

[AttributeUsage(AttributeTargets.Field)]
internal sealed class SerializeFieldAttribute : Attribute
{
}
