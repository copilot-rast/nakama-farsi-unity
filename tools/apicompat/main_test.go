package main

import (
	"os"
	"path/filepath"
	"strings"
	"testing"
)

const base = `namespace NakamaFarsi.Sdk.Generated
{
    public sealed partial class NakamaFarsiRpcs
    {
        public NakamaFarsiRpcs(IRpcCaller caller)
        {
            Game = new GameRpcs(caller);
        }

        public GameRpcs Game { get; }
    }

    public static class RpcIds
    {
        public const string GameEnd = "game_end";
    }

    public sealed partial class GameRpcs
    {
        public GameRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<GameEndResponse> EndAsync(GameEndRequest request = null, CancellationToken ct = default)
        {
            return null;
        }
    }

    public sealed class GameEndRequest
    {
        [JsonProperty("ticket")]
        public string Ticket { get; set; }
    }

    public sealed class GameEndResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("xp")]
        public long? Xp { get; set; }

        [JsonProperty("rewards")]
        public RewardsData Rewards { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class RewardsData
        {
            [JsonProperty("pits")]
            public long? Pits { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }
}
`

func check(t *testing.T, next string) report {
	t.Helper()
	dir := t.TempDir()
	a, b := filepath.Join(dir, "a.cs"), filepath.Join(dir, "b.cs")
	if err := os.WriteFile(a, []byte(base), 0o644); err != nil {
		t.Fatal(err)
	}
	if err := os.WriteFile(b, []byte(next), 0o644); err != nil {
		t.Fatal(err)
	}
	old, err := parse(a)
	if err != nil {
		t.Fatal(err)
	}
	cur, err := parse(b)
	if err != nil {
		t.Fatal(err)
	}
	return compare(old, cur)
}

func TestSameFileIsClean(t *testing.T) {
	r := check(t, base)
	if len(r.Removed)+len(r.Changed)+len(r.JSON) != 0 || r.Added != 0 {
		t.Fatalf("%+v", r)
	}
}

func TestNewOptionalFieldIsFine(t *testing.T) {
	next := strings.Replace(base, `        [JsonProperty("xp")]`, "        [JsonProperty(\"level\")]\n        public long? Level { get; set; }\n\n        [JsonProperty(\"xp\")]", 1)
	r := check(t, next)
	if len(r.Removed)+len(r.Changed)+len(r.JSON) != 0 || r.Added != 1 {
		t.Fatalf("%+v", r)
	}
}

func TestBreakingChangesAreCaught(t *testing.T) {
	cases := map[string][2]string{
		"property removed":    {"        [JsonProperty(\"xp\")]\n        public long? Xp { get; set; }\n", ""},
		"property type":       {"public long? Xp", "public double? Xp"},
		"json name":           {`[JsonProperty("xp")]`, `[JsonProperty("exp")]`},
		"nested class rename": {"public RewardsData Rewards", "public RewardsData_ Rewards"},
		"nested class gone":   {"public sealed class RewardsData", "public sealed class RewardsInfo"},
		"method signature":    {"EndAsync(GameEndRequest request = null, CancellationToken ct = default)", "EndAsync(GameEndRequest request, CancellationToken ct = default)"},
		"method gone":         {"EndAsync(", "FinishAsync("},
		"rpc id value":        {`"game_end"`, `"game_finish"`},
		"module renamed":      {"public GameRpcs Game { get; }", "public GameRpcs Games { get; }"},
		"request class gone":  {"class GameEndRequest", "class GameFinishRequest"},
		"response interface":  {"GameEndResponse : IRawResponse", "GameEndResponse"},
	}
	for name, c := range cases {
		t.Run(name, func(t *testing.T) {
			if !strings.Contains(base, c[0]) {
				t.Fatalf("fixture has no %q", c[0])
			}
			r := check(t, strings.Replace(base, c[0], c[1], 1))
			if len(r.Removed)+len(r.Changed) == 0 {
				t.Fatalf("not caught: %+v", r)
			}
		})
	}
}

func TestJSONRules(t *testing.T) {
	r := check(t, strings.Replace(base, "public long? Pits", "public long Pits", 1))
	if len(r.JSON) == 0 {
		t.Fatal("non-nullable field not reported")
	}
	r = check(t, strings.Replace(base, "            [JsonExtensionData]\n            public IDictionary<string, JToken> Extra { get; set; }\n", "", 1))
	if len(r.JSON) == 0 {
		t.Fatal("missing extension data not reported")
	}
}

func TestUsageFileNamesEveryOldMember(t *testing.T) {
	dir := t.TempDir()
	a := filepath.Join(dir, "a.cs")
	if err := os.WriteFile(a, []byte(base), 0o644); err != nil {
		t.Fatal(err)
	}
	old, err := parse(a)
	if err != nil {
		t.Fatal(err)
	}
	src := usageFile(old, old)
	for _, want := range []string{
		"rpcs.Game.EndAsync(new global::NakamaFarsi.Sdk.Generated.GameEndRequest(), CancellationToken.None)",
		"global::NakamaFarsi.Sdk.Generated.GameEndResponse.RewardsData v = o.Rewards;",
		"long? v = o.Pits;",
		"global::NakamaFarsi.Sdk.Generated.RpcIds.GameEnd",
	} {
		if !strings.Contains(src, want) {
			t.Fatalf("usage file has no %q:\n%s", want, src)
		}
	}
}
