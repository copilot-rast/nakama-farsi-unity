package gen

import (
	"os"
	"path/filepath"
	"reflect"
	"sort"
	"testing"
)

const plugin = `package game

const reportRPC = "game_report"

func InitModule(ctx context.Context, logger runtime.Logger, db *sql.DB, nk runtime.NakamaModule, initializer runtime.Initializer) error {
	for name, fn := range map[string]rpcFunc{"game_inline": rpcInline} {
		if err := initializer.RegisterRpc(name, wrapRPC(fn)); err != nil {
			return err
		}
	}
	for name, fn := range clientRPCs() {
		if err := initializer.RegisterRpc(name, wrapRPC(fn)); err != nil {
			return err
		}
	}
	rpcs := p.rpcs()
	for _, prov := range providers {
		for k, v := range prov(p) {
			rpcs[k] = v
		}
	}
	for name, fn := range rpcs {
		if err := initializer.RegisterRpc(name, wrapRPC(fn)); err != nil {
			return err
		}
	}
	if err := initializer.RegisterRpc(reportRPC, rpcReport); err != nil {
		return err
	}
	return initializer.RegisterRpc(pick(), rpcReport)
}

func clientRPCs() map[string]rpcFunc {
	return map[string]rpcFunc{"game_list": rpcList, "game_end": rpcEnd}
}

func (p *plugin) rpcs() map[string]rpcFunc {
	return map[string]rpcFunc{"game_extra": rpcExtra}
}

func init() {
	providers = append(providers, func(p *plugin) map[string]rpcFunc {
		return map[string]rpcFunc{"game_provided": rpcProvided}
	})
}
`

func TestRegisteredIDsFollowsEveryPattern(t *testing.T) {
	root := t.TempDir()
	dir := filepath.Join(root, "integrations", "game")
	if err := os.MkdirAll(dir, 0o755); err != nil {
		t.Fatal(err)
	}
	if err := os.WriteFile(filepath.Join(dir, "module.go"), []byte(plugin), 0o644); err != nil {
		t.Fatal(err)
	}
	ids, unknown, err := RegisteredIDs(root)
	if err != nil {
		t.Fatal(err)
	}
	got := []string{}
	for id := range ids {
		got = append(got, id)
	}
	sort.Strings(got)
	want := []string{"game_end", "game_extra", "game_inline", "game_list", "game_provided", "game_report"}
	if !reflect.DeepEqual(got, want) {
		t.Fatalf("ids %v, want %v", got, want)
	}
	if len(unknown) != 1 {
		t.Fatalf("the pick() registration must be reported as unknown, got %v", unknown)
	}
}

func TestKeepOldNeverChangesAnExistingType(t *testing.T) {
	prev := map[string]any{"type": "object", "properties": map[string]any{
		"payouts":  map[string]any{},
		"trophies": map[string]any{"type": "number"},
		"meta":     map[string]any{"type": "object", "properties": map[string]any{}},
		"rewards":  map[string]any{"type": "object", "properties": map[string]any{"pits": map[string]any{"type": "integer"}}},
		"gone":     map[string]any{"type": "string"},
	}}
	next := map[string]any{"type": "object", "properties": map[string]any{
		"payouts":  map[string]any{"type": "object", "properties": map[string]any{"a": map[string]any{"type": "integer"}}},
		"trophies": map[string]any{"type": "integer"},
		"meta":     map[string]any{"type": "object", "properties": map[string]any{"x": map[string]any{"type": "string"}}},
		"rewards":  map[string]any{"type": "object", "properties": map[string]any{"pits": map[string]any{"type": "string"}, "oil": map[string]any{"type": "integer"}}},
		"xp":       map[string]any{"type": "integer"},
	}}
	out := keepTop("response", next, prev).(map[string]any)["properties"].(map[string]any)
	check := func(path string, got, want any) {
		t.Helper()
		if !reflect.DeepEqual(got, want) {
			t.Fatalf("%s = %v, want %v", path, got, want)
		}
	}
	check("payouts", out["payouts"], map[string]any{})
	check("trophies", out["trophies"], map[string]any{"type": "number"})
	check("meta", out["meta"], map[string]any{"type": "object", "properties": map[string]any{}})
	rewards := out["rewards"].(map[string]any)["properties"].(map[string]any)
	check("rewards.pits", rewards["pits"], map[string]any{"type": "integer"})
	check("rewards.oil", rewards["oil"], map[string]any{"type": "integer"})
	check("gone", out["gone"], map[string]any{"type": "string"})
	check("xp", out["xp"], map[string]any{"type": "integer"})
}
