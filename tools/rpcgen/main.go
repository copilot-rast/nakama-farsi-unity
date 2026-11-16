package main

import (
	"encoding/json"
	"flag"
	"fmt"
	"os"
	"path/filepath"
	"sort"
	"strings"
	"unicode"
)

type schemaDoc struct {
	Version int      `json:"version"`
	RPCs    []rpcDef `json:"rpcs"`
}

type rpcDef struct {
	ID       string   `json:"id"`
	Module   string   `json:"module"`
	Handler  string   `json:"handler"`
	Auth     string   `json:"auth"`
	Request  *shape   `json:"request"`
	Response *shape   `json:"response"`
	Errors   []string `json:"errors"`
}

type shape struct {
	Type       string            `json:"type"`
	Properties map[string]*shape `json:"properties"`
	Items      *shape            `json:"items"`
}

var readTokens = set("me", "rules", "config", "stats", "trophies", "catalog", "balances", "inventory", "items", "list",
	"kinds", "manifest", "fetch", "index", "chapters", "schema", "achievements", "profile", "levels", "streaks",
	"progress", "games", "game", "history", "mine", "status", "current", "get", "info", "tickets", "titles", "brand",
	"categories", "countries", "languages", "tags", "activity", "reports", "time", "catalog", "stickers", "quota", "board",
	"winners", "banners", "sponsors", "unread", "inbox", "comments", "offers", "rewards", "payments", "purchases", "prefs", "devices",
	"phone", "types", "tasks", "avatar", "slug", "version", "gifts", "options", "balances", "streaks", "faq")

var writeTokens = set("buy", "claim", "play", "start", "complete", "submit", "record", "track", "set", "send", "create",
	"open", "close", "rate", "reply", "resolve", "redeem", "enter", "unlock", "upgrade", "use", "equip", "unequip",
	"report", "request", "verify", "cancel", "upload", "join", "begin", "finish", "part", "typing", "token", "follow",
	"unfollow", "react", "comment", "delete", "update", "add", "remove", "next", "review", "answer", "hint", "check",
	"local", "state", "freeride")

func set(items ...string) map[string]bool {
	out := map[string]bool{}
	for _, i := range items {
		out[i] = true
	}
	return out
}

func main() {
	in := flag.String("schema", "tools/schema/rpc-schema.json", "RPC schema from tools/rpcschema")
	out := flag.String("out", "Packages/Nakama/Farsi/Runtime/Generated/Rpcs.g.cs", "C# file to write")
	flag.Parse()
	raw, err := os.ReadFile(*in)
	if err != nil {
		fail(err)
	}
	var doc schemaDoc
	if err := json.Unmarshal(raw, &doc); err != nil {
		fail(err)
	}
	src := generate(doc)
	if err := os.MkdirAll(filepath.Dir(*out), 0o755); err != nil {
		fail(err)
	}
	if err := os.WriteFile(*out, []byte(src), 0o644); err != nil {
		fail(err)
	}
	fmt.Printf("rpcgen: %d RPCs in %d modules → %s\n", len(doc.RPCs), len(modules(doc)), *out)
}

func fail(err error) {
	fmt.Fprintln(os.Stderr, "rpcgen:", err)
	os.Exit(1)
}

func modules(doc schemaDoc) []string {
	seen := map[string]bool{}
	out := []string{}
	for _, r := range doc.RPCs {
		if !seen[r.Module] {
			seen[r.Module] = true
			out = append(out, r.Module)
		}
	}
	sort.Strings(out)
	return out
}

func pascal(s string) string {
	var b strings.Builder
	up := true
	for _, r := range s {
		if !unicode.IsLetter(r) && !unicode.IsDigit(r) {
			up = true
			continue
		}
		if up {
			b.WriteRune(unicode.ToUpper(r))
			up = false
		} else {
			b.WriteRune(r)
		}
	}
	out := b.String()
	if out == "" {
		return "Value"
	}
	if unicode.IsDigit(rune(out[0])) {
		out = "_" + out
	}
	return out
}

func readOnly(r rpcDef) bool {
	tokens := strings.Split(r.ID, "_")
	for _, t := range tokens[1:] {
		if writeTokens[t] {
			return false
		}
	}
	return readTokens[tokens[len(tokens)-1]]
}

type writer struct {
	b      strings.Builder
	indent int
}

func (w *writer) line(format string, args ...any) {
	if format == "" {
		w.b.WriteString("\n")
		return
	}
	w.b.WriteString(strings.Repeat("    ", w.indent))
	fmt.Fprintf(&w.b, format, args...)
	w.b.WriteString("\n")
}

func xml(s string) string {
	return strings.NewReplacer("&", "&amp;", "<", "&lt;", ">", "&gt;").Replace(s)
}

func generate(doc schemaDoc) string {
	w := &writer{}
	w.line("#pragma warning disable 1591")
	w.line("using System.Collections.Generic;")
	w.line("using System.Threading;")
	w.line("using System.Threading.Tasks;")
	w.line("using Newtonsoft.Json;")
	w.line("using Newtonsoft.Json.Linq;")
	w.line("")
	w.line("namespace NakamaFarsi.Sdk.Generated")
	w.line("{")
	w.indent++
	mods := modules(doc)
	byModule := map[string][]rpcDef{}
	for _, r := range doc.RPCs {
		byModule[r.Module] = append(byModule[r.Module], r)
	}

	w.line("public sealed partial class NakamaFarsiRpcs")
	w.line("{")
	w.indent++
	w.line("public NakamaFarsiRpcs(IRpcCaller caller)")
	w.line("{")
	w.indent++
	for _, m := range mods {
		w.line("%s = new %sRpcs(caller);", pascal(m), pascal(m))
	}
	w.indent--
	w.line("}")
	for _, m := range mods {
		w.line("")
		w.line("public %sRpcs %s { get; }", pascal(m), pascal(m))
	}
	w.indent--
	w.line("}")
	w.line("")

	w.line("public static class RpcIds")
	w.line("{")
	w.indent++
	for _, r := range doc.RPCs {
		w.line("public const string %s = \"%s\";", pascal(r.ID), r.ID)
	}
	w.indent--
	w.line("}")

	for _, m := range mods {
		w.line("")
		cls := pascal(m) + "Rpcs"
		w.line("public sealed partial class %s", cls)
		w.line("{")
		w.indent++
		w.line("private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };")
		w.line("private static readonly RpcCallOptions WriteCall = new RpcCallOptions();")
		w.line("private readonly IRpcCaller _c;")
		w.line("")
		w.line("public %s(IRpcCaller caller)", cls)
		w.line("{")
		w.line("    _c = caller;")
		w.line("}")
		for _, r := range byModule[m] {
			method := methodName(r)
			req := pascal(r.ID) + "Request"
			res := pascal(r.ID) + "Response"
			w.line("")
			w.line("public Task<%s> %sAsync(%s request = null, CancellationToken ct = default)", res, method, req)
			w.line("{")
			w.indent++
			w.line("request = request ?? new %s();", req)
			if hasProp(r.Request, "lang") {
				w.line("if (request.Lang == null)")
				w.line("{")
				w.line("    request.Lang = _c.Language;")
				w.line("}")
				w.line("")
			}
			w.line("return RpcInvoke.CallAsync<%s>(_c, RpcIds.%s, request, %s, ct);", res, pascal(r.ID), map[bool]string{true: "ReadCall", false: "WriteCall"}[readOnly(r)])
			w.indent--
			w.line("}")
		}
		w.indent--
		w.line("}")
	}

	for _, r := range doc.RPCs {
		w.line("")
		writeClass(w, pascal(r.ID)+"Request", r.Request, false)
		w.line("")
		writeClass(w, pascal(r.ID)+"Response", r.Response, true, "IRawResponse")
	}
	w.indent--
	w.line("}")
	return w.b.String()
}

func hasProp(s *shape, name string) bool {
	if s == nil || s.Properties == nil {
		return false
	}
	p, ok := s.Properties[name]
	return ok && p != nil && p.Type == "string"
}

func methodName(r rpcDef) string {
	id := r.ID
	if strings.HasPrefix(id, r.Module+"_") {
		id = strings.TrimPrefix(id, r.Module+"_")
	}
	return pascal(id)
}

func writeClass(w *writer, name string, s *shape, extension bool, iface ...string) {
	if len(iface) > 0 {
		w.line("public sealed class %s : %s", name, strings.Join(iface, ", "))
	} else {
		w.line("public sealed class %s", name)
	}
	w.line("{")
	w.indent++
	if len(iface) > 0 {
		w.line("[JsonIgnore]")
		w.line("public JObject Raw { get; set; }")
		w.line("")
	}
	props := []string{}
	if s != nil {
		for k := range s.Properties {
			props = append(props, k)
		}
	}
	sort.Strings(props)
	used := map[string]bool{name: true}
	nested := []func(){}
	for i, k := range props {
		p := s.Properties[k]
		prop := pascal(k)
		for used[prop] {
			prop += "_"
		}
		used[prop] = true
		typ, more := csType(w, prop, p, used)
		if more != nil {
			nested = append(nested, more)
		}
		if i > 0 {
			w.line("")
		}
		w.line("[JsonProperty(\"%s\")]", k)
		w.line("public %s %s { get; set; }", typ, prop)
	}
	if extension {
		if len(props) > 0 {
			w.line("")
		}
		extra := "Extra"
		for used[extra] {
			extra += "_"
		}
		w.line("[JsonExtensionData]")
		w.line("public IDictionary<string, JToken> %s { get; set; }", extra)
	}
	for _, n := range nested {
		w.line("")
		n()
	}
	w.indent--
	w.line("}")
}

func csType(w *writer, prop string, s *shape, used map[string]bool) (string, func()) {
	if s == nil {
		return "JToken", nil
	}
	switch s.Type {
	case "string":
		return "string", nil
	case "boolean":
		return "bool?", nil
	case "integer":
		return "long?", nil
	case "number":
		return "double?", nil
	case "array":
		inner, more := csType(w, prop+"Item", s.Items, used)
		inner = strings.TrimSuffix(inner, "?")
		if inner == "long" || inner == "double" || inner == "bool" {
			inner += "?"
		}
		return "List<" + inner + ">", more
	case "object":
		if len(s.Properties) == 0 {
			return "JObject", nil
		}
		name := prop + "Data"
		if strings.HasSuffix(prop, "Item") {
			name = prop
		}
		for used[name] {
			name += "_"
		}
		used[name] = true
		return name, func() {

			nw := &writer{indent: 0}
			writeClass(nw, name, s, true)
			for _, l := range strings.Split(strings.TrimRight(nw.b.String(), "\n"), "\n") {
				if l == "" {
					w.line("")
					continue
				}
				w.line("%s", l)
			}
		}
	}
	return "JToken", nil
}
