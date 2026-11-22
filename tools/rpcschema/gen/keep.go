package gen

import (
	"encoding/json"
	"os"
	"path/filepath"
)

func KeepKnown(outDir string, previous []byte) error {
	if len(previous) == 0 {
		return nil
	}
	var old Document
	if err := json.Unmarshal(previous, &old); err != nil {
		return err
	}
	path := filepath.Join(outDir, "rpc-schema.json")
	raw, err := os.ReadFile(path)
	if err != nil {
		return err
	}
	var doc Document
	if err := json.Unmarshal(raw, &doc); err != nil {
		return err
	}
	known := map[string]RPC{}
	for _, r := range old.RPCs {
		known[r.ID] = r
	}
	for i, r := range doc.RPCs {
		o, ok := known[r.ID]
		if !ok {
			continue
		}
		doc.RPCs[i].Request = asSchema(mergeKnown(map[string]any(r.Request), map[string]any(o.Request)))
		doc.RPCs[i].Response = asSchema(mergeKnown(map[string]any(r.Response), map[string]any(o.Response)))
	}
	out, err := marshal(doc)
	if err != nil {
		return err
	}
	return os.WriteFile(path, out, 0o644)
}

func asSchema(v any) Schema {
	m, _ := v.(map[string]any)
	return Schema(m)
}

func mergeKnown(next, prev any) any {
	n, nok := toMap(next)
	p, pok := toMap(prev)
	if !pok || len(p) == 0 {
		return next
	}
	if !nok || len(n) == 0 {
		return prev
	}
	if n["type"] != p["type"] {
		return next
	}
	out := map[string]any{}
	for k, v := range n {
		out[k] = v
	}
	switch n["type"] {
	case "object":
		np, _ := toMap(n["properties"])
		pp, _ := toMap(p["properties"])
		if len(pp) > 0 {
			merged := map[string]any{}
			for k, v := range pp {
				merged[k] = v
			}
			for k, v := range np {
				merged[k] = mergeKnown(v, pp[k])
			}
			out["properties"] = merged
		}
		if p["additionalProperties"] != nil {
			out["additionalProperties"] = mergeKnown(n["additionalProperties"], p["additionalProperties"])
		}
	case "array":
		if p["items"] != nil {
			out["items"] = mergeKnown(n["items"], p["items"])
		}
	}
	return out
}

func toMap(v any) (map[string]any, bool) {
	switch m := v.(type) {
	case map[string]any:
		return m, true
	case Schema:
		return map[string]any(m), true
	}
	return nil, false
}
