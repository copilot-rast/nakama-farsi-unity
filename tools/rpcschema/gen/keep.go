package gen

import (
	"encoding/json"
	"fmt"
	"os"
	"path/filepath"
)

var keptTypes []string

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
		keptTypes = nil
		doc.RPCs[i].Request = asSchema(keepTop("request", map[string]any(r.Request), map[string]any(o.Request)))
		doc.RPCs[i].Response = asSchema(keepTop("response", map[string]any(r.Response), map[string]any(o.Response)))
		for _, k := range keptTypes {
			fmt.Printf("rpcschema: note %s: a field type would change; %s (the old C# type stays, the value is still in Raw)\n", r.ID, k)
		}
	}
	out, err := marshal(doc)
	if err != nil {
		return err
	}
	return os.WriteFile(path, out, 0o644)
}

func keepTop(path string, next, prev map[string]any) any {
	if len(prev) == 0 {
		return next
	}
	if len(next) == 0 {
		return prev
	}
	if prev["type"] == "object" && next["type"] == "object" {
		out := map[string]any{}
		for k, v := range next {
			out[k] = v
		}
		np, _ := toMap(next["properties"])
		pp, _ := toMap(prev["properties"])
		merged := map[string]any{}
		for k, v := range np {
			merged[k] = v
		}
		for k, v := range pp {
			merged[k] = keepOld(path+"."+k, np[k], v)
		}
		out["properties"] = merged
		return out
	}
	if prev["type"] != "object" && next["type"] == "object" {
		return next
	}
	return keepOld(path, next, prev)
}

func keepOld(path string, next, prev any) any {
	n, nok := toMap(next)
	p, pok := toMap(prev)
	if !pok {
		return next
	}
	if len(p) == 0 {
		return prev
	}
	if !nok || len(n) == 0 {
		return prev
	}
	if n["type"] != p["type"] {
		keptTypes = append(keptTypes, fmt.Sprintf("%s: %v kept, the server now sends %v", path, p["type"], n["type"]))
		return prev
	}
	out := map[string]any{}
	for k, v := range n {
		out[k] = v
	}
	switch p["type"] {
	case "object":
		np, _ := toMap(n["properties"])
		pp, _ := toMap(p["properties"])
		if len(pp) == 0 {
			return prev
		}
		merged := map[string]any{}
		for k, v := range np {
			merged[k] = v
		}
		for k, v := range pp {
			merged[k] = keepOld(path+"."+k, np[k], v)
		}
		out["properties"] = merged
		if p["additionalProperties"] != nil {
			out["additionalProperties"] = p["additionalProperties"]
		}
	case "array":
		if p["items"] != nil {
			out["items"] = keepOld(path+"[]", n["items"], p["items"])
		}
	}
	return out
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
	if (n["type"] == "integer" && p["type"] == "number") || (n["type"] == "number" && p["type"] == "integer") {
		return map[string]any{"type": "number"}
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
