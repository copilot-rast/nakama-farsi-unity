package main

import (
	"encoding/json"
	"flag"
	"fmt"
	"os"
	"regexp"
	"sort"
	"strconv"
	"strings"
)

type member struct {
	Class string
	Name  string
	Kind  string
	Sig   string
	Type  string
	JSON  string
}

type surface struct {
	Classes map[string]string
	Members map[string]member
	Modules map[string]string
}

var (
	reClass    = regexp.MustCompile(`^public (?:sealed |static )?(?:partial )?class (\w+)(?: : (.+))?$`)
	reProp     = regexp.MustCompile(`^public (.+) (\w+) \{ get;(?: set;)? \}$`)
	reMethod   = regexp.MustCompile(`^public (.+?) (\w+)\((.*)\)$`)
	reCtor     = regexp.MustCompile(`^public (\w+)\((.*)\)$`)
	reConst    = regexp.MustCompile(`^public const string (\w+) = "([^"]*)";$`)
	reJSON     = regexp.MustCompile(`^\[JsonProperty\("([^"]*)"\)\]$`)
	reValueTyp = regexp.MustCompile(`(^|[<, ])(long|int|bool|double|float|decimal)([>, ]|$)`)
)

func parse(path string) (*surface, error) {
	raw, err := os.ReadFile(path)
	if err != nil {
		return nil, err
	}
	s := &surface{Classes: map[string]string{}, Members: map[string]member{}, Modules: map[string]string{}}
	var stack []string
	pendingClass := ""
	pendingJSON := ""
	attr := ""
	depth := 0
	classDepth := []int{}
	for _, line := range strings.Split(string(raw), "\n") {
		t := strings.TrimSpace(line)
		switch {
		case t == "{":
			depth++
			if pendingClass != "" {
				stack = append(stack, pendingClass)
				classDepth = append(classDepth, depth)
				pendingClass = ""
			}
			continue
		case t == "}":
			if len(classDepth) > 0 && classDepth[len(classDepth)-1] == depth {
				stack = stack[:len(stack)-1]
				classDepth = classDepth[:len(classDepth)-1]
			}
			depth--
			continue
		}
		cls := strings.Join(stack, ".")
		if m := reJSON.FindStringSubmatch(t); m != nil {
			pendingJSON = m[1]
			continue
		}
		if strings.HasPrefix(t, "[") {
			attr = t
			continue
		}
		if m := reClass.FindStringSubmatch(t); m != nil {
			name := m[1]
			if cls != "" {
				name = cls + "." + name
			}
			s.Classes[name] = strings.Replace(strings.TrimPrefix(t, "public "), "class "+m[1], "class", 1)
			pendingClass = m[1]
			pendingJSON, attr = "", ""
			continue
		}
		if !strings.HasPrefix(t, "public ") || cls == "" {
			pendingJSON, attr = "", ""
			continue
		}
		if m := reConst.FindStringSubmatch(t); m != nil {
			s.Members[cls+"."+m[1]] = member{Class: cls, Name: m[1], Kind: "const", Sig: `"` + m[2] + `"`, Type: "string"}
		} else if m := reProp.FindStringSubmatch(t); m != nil {
			acc := "get"
			if strings.Contains(t, "set;") {
				acc = "get set"
			}
			sig := m[1] + " {" + acc + "}"
			if pendingJSON != "" {
				sig += ` json "` + pendingJSON + `"`
			}
			if attr != "" {
				sig += " " + attr
			}
			s.Members[cls+"."+m[2]] = member{Class: cls, Name: m[2], Kind: "property", Sig: sig, Type: m[1], JSON: pendingJSON}
			if cls == "NakamaFarsiRpcs" {
				s.Modules[m[1]] = m[2]
			}
		} else if m := reCtor.FindStringSubmatch(t); m != nil {
			key := cls + ".ctor(" + paramTypes(m[2]) + ")"
			s.Members[key] = member{Class: cls, Name: m[1], Kind: "constructor", Sig: m[1] + "(" + m[2] + ")"}
		} else if m := reMethod.FindStringSubmatch(t); m != nil {
			key := cls + "." + m[2] + "(" + paramTypes(m[3]) + ")"
			s.Members[key] = member{Class: cls, Name: m[2], Kind: "method", Sig: m[1] + " " + m[2] + "(" + m[3] + ")", Type: m[1]}
		}
		pendingJSON, attr = "", ""
	}
	return s, nil
}

func paramTypes(params string) string {
	if strings.TrimSpace(params) == "" {
		return ""
	}
	out := []string{}
	for _, p := range splitTop(params) {
		p = strings.TrimSpace(p)
		if i := strings.Index(p, " = "); i >= 0 {
			p = p[:i]
		}
		f := strings.Fields(p)
		if len(f) >= 2 {
			out = append(out, strings.Join(f[:len(f)-1], " "))
		}
	}
	return strings.Join(out, ", ")
}

func splitTop(s string) []string {
	out := []string{}
	depth, start := 0, 0
	for i, r := range s {
		switch r {
		case '<':
			depth++
		case '>':
			depth--
		case ',':
			if depth == 0 {
				out = append(out, s[start:i])
				start = i + 1
			}
		}
	}
	return append(out, s[start:])
}

type report struct {
	Removed []string
	Changed []string
	Added   int
	JSON    []string
}

func compare(old, cur *surface) report {
	var r report
	for _, name := range sortedKeys(old.Classes) {
		got, ok := cur.Classes[name]
		if !ok {
			r.Removed = append(r.Removed, "class "+name)
		} else if got != old.Classes[name] {
			r.Changed = append(r.Changed, fmt.Sprintf("class %s: %q is now %q", name, old.Classes[name], got))
		}
	}
	for _, key := range sortedKeys(old.Members) {
		o := old.Members[key]
		n, ok := cur.Members[key]
		if !ok {
			r.Removed = append(r.Removed, fmt.Sprintf("%s %s (%s)", o.Kind, key, o.Sig))
			continue
		}
		if n.Sig != o.Sig {
			r.Changed = append(r.Changed, fmt.Sprintf("%s %s: %s  →  %s", o.Kind, key, o.Sig, n.Sig))
		}
	}
	for key, n := range cur.Members {
		if _, ok := old.Members[key]; !ok {
			r.Added++
		}
		if n.Kind == "property" && n.JSON != "" && reValueTyp.MatchString(n.Type) && !strings.Contains(n.Type, "?") {
			r.JSON = append(r.JSON, fmt.Sprintf("%s is %s; JSON fields must be nullable so a missing field still parses", key, n.Type))
		}
	}
	for name, decl := range cur.Classes {
		if strings.HasSuffix(name, "Response") && !strings.Contains(decl, "IRawResponse") {
			r.JSON = append(r.JSON, "class "+name+" does not implement IRawResponse")
		}
	}
	for name := range cur.Classes {
		if strings.HasSuffix(name, "Request") || cur.Classes[name] == "" || strings.Contains(cur.Classes[name], "static") || strings.HasSuffix(name, "Rpcs") {
			continue
		}
		if _, ok := cur.Members[name+".Extra"]; !ok {
			if _, ok2 := cur.Members[name+".Extra_"]; !ok2 {
				r.JSON = append(r.JSON, "class "+name+" has no [JsonExtensionData] member; fields from newer servers would be lost")
			}
		}
	}
	r.Removed = dedupe(r.Removed)
	sort.Strings(r.JSON)
	return r
}

func dedupe(list []string) []string {
	seen := map[string]bool{}
	out := []string{}
	for _, s := range list {
		if !seen[s] {
			seen[s] = true
			out = append(out, s)
		}
	}
	sort.Strings(out)
	return out
}

func sortedKeys[V any](m map[string]V) []string {
	out := make([]string, 0, len(m))
	for k := range m {
		out = append(out, k)
	}
	sort.Strings(out)
	return out
}

func version(path string) (string, [2]int, error) {
	raw, err := os.ReadFile(path)
	if err != nil {
		return "", [2]int{}, err
	}
	var p struct {
		Version string `json:"version"`
	}
	if err := json.Unmarshal(raw, &p); err != nil {
		return "", [2]int{}, err
	}
	parts := strings.SplitN(strings.SplitN(p.Version, "-", 2)[0], ".", 3)
	var mm [2]int
	for i := 0; i < 2 && i < len(parts); i++ {
		mm[i], _ = strconv.Atoi(parts[i])
	}
	return p.Version, mm, nil
}

func main() {
	oldPath := flag.String("old", "", "the committed Rpcs.g.cs")
	newPath := flag.String("new", "", "the freshly generated Rpcs.g.cs")
	oldPkg := flag.String("old-package", "", "the committed package.json")
	newPkg := flag.String("new-package", "", "the working package.json")
	usage := flag.String("usage", "", "write a C# file that uses every old public member, to compile against the new code")
	allow := flag.Bool("allow-breaking", false, "accept removed or changed members; needs a major or minor version bump in package.json")
	flag.Parse()
	old, err := parse(*oldPath)
	if err != nil {
		fail(err)
	}
	cur, err := parse(*newPath)
	if err != nil {
		fail(err)
	}
	r := compare(old, cur)
	fmt.Printf("apicompat: old %d classes / %d members, new %d classes / %d members, %d members added\n",
		len(old.Classes), len(old.Members), len(cur.Classes), len(cur.Members), r.Added)
	bad := false
	if len(r.JSON) > 0 {
		bad = true
		fmt.Fprintln(os.Stderr, "apicompat: JSON compatibility rules broken (no override for these):")
		for _, l := range r.JSON {
			fmt.Fprintln(os.Stderr, "  - "+l)
		}
	}
	breaking := len(r.Removed) + len(r.Changed)
	if breaking > 0 {
		fmt.Fprintf(os.Stderr, "apicompat: %d breaking changes against the committed Rpcs.g.cs:\n", breaking)
		for _, l := range r.Removed {
			fmt.Fprintln(os.Stderr, "  - removed "+l)
		}
		for _, l := range r.Changed {
			fmt.Fprintln(os.Stderr, "  - changed "+l)
		}
		if !*allow {
			fmt.Fprintln(os.Stderr, "apicompat: FAILED. Game projects that use these members would stop compiling.")
			fmt.Fprintln(os.Stderr, "apicompat: fix the server or the generator, or rerun with --allow-breaking after a major or minor version bump.")
			bad = true
		} else {
			ov, om, err := version(*oldPkg)
			if err != nil {
				fail(err)
			}
			nv, nm, err := version(*newPkg)
			if err != nil {
				fail(err)
			}
			if nm[0] > om[0] || (nm[0] == om[0] && nm[1] > om[1]) {
				fmt.Printf("apicompat: breaking changes accepted, version %s → %s\n", ov, nv)
			} else {
				fmt.Fprintf(os.Stderr, "apicompat: --allow-breaking needs a major or minor bump; package.json is %s, committed %s\n", nv, ov)
				bad = true
			}
		}
	}
	if bad {
		os.Exit(1)
	}
	if *usage != "" {
		if err := os.WriteFile(*usage, []byte(usageFile(old, cur)), 0o644); err != nil {
			fail(err)
		}
	}
	fmt.Println("apicompat: ok, every public member of the committed wrappers is still there with the same type")
}

func fail(err error) {
	fmt.Fprintln(os.Stderr, "apicompat:", err)
	os.Exit(1)
}

var reIdent = regexp.MustCompile(`[A-Za-z_]\w*`)

func qualify(cls string, typ string, classes map[string]string) string {
	return reIdent.ReplaceAllStringFunc(typ, func(id string) string {
		parts := strings.Split(cls, ".")
		for i := len(parts); i >= 0; i-- {
			cand := strings.Join(append(append([]string{}, parts[:i]...), id), ".")
			if _, ok := classes[cand]; ok {
				return "global::NakamaFarsi.Sdk.Generated." + cand
			}
		}
		return id
	})
}

func usageFile(old, cur *surface) string {
	var b strings.Builder
	b.WriteString("#pragma warning disable 1591\nusing System.Collections.Generic;\nusing System.Threading;\nusing System.Threading.Tasks;\nusing Newtonsoft.Json.Linq;\n\n")
	b.WriteString("namespace NakamaFarsi.ApiCompat\n{\n    public static class OldApiUsage\n    {\n")
	n := 0
	for _, cls := range sortedKeys(old.Classes) {
		if strings.Contains(old.Classes[cls], "static") {
			continue
		}
		g := "global::NakamaFarsi.Sdk.Generated." + cls
		lines := []string{}
		for _, key := range sortedKeys(old.Members) {
			m := old.Members[key]
			if m.Class != cls {
				continue
			}
			switch m.Kind {
			case "property":
				t := qualify(cls, m.Type, old.Classes)
				if strings.Contains(m.Sig, "{get set}") {
					lines = append(lines, fmt.Sprintf("            { var o = new %s(); %s v = o.%s; o.%s = v; }", g, t, m.Name, m.Name))
				} else if cls == "NakamaFarsiRpcs" {
					lines = append(lines, fmt.Sprintf("            { %s v = rpcs.%s; }", t, m.Name))
				}
			case "method":
				if mod, ok := old.Modules[cls]; ok {
					ret := qualify(cls, m.Type, old.Classes)
					params := m.Sig[strings.Index(m.Sig, "(")+1 : len(m.Sig)-1]
					req := strings.TrimSpace(strings.Split(paramTypes(params), ",")[0])
					lines = append(lines, fmt.Sprintf("            { %s t = rpcs.%s.%s(new %s(), CancellationToken.None); }", ret, mod, m.Name, qualify(cls, req, old.Classes)))
					lines = append(lines, fmt.Sprintf("            { %s t = rpcs.%s.%s(); }", ret, mod, m.Name))
				}
			}
		}
		if strings.Contains(old.Classes[cls], "IRawResponse") {
			lines = append(lines, fmt.Sprintf("            { global::NakamaFarsi.Sdk.IRawResponse r = new %s(); JObject raw = r.Raw; }", g))
		}
		if len(lines) == 0 {
			continue
		}
		n++
		fmt.Fprintf(&b, "        public static void Use%d(global::NakamaFarsi.Sdk.Generated.NakamaFarsiRpcs rpcs)\n        {\n", n)
		b.WriteString(strings.Join(lines, "\n"))
		b.WriteString("\n        }\n\n")
	}
	consts := []string{}
	for _, key := range sortedKeys(old.Members) {
		m := old.Members[key]
		if m.Kind == "const" {
			consts = append(consts, fmt.Sprintf("            { const string v = global::NakamaFarsi.Sdk.Generated.%s.%s; }", m.Class, m.Name))
		}
	}
	b.WriteString("        public static void Ids()\n        {\n" + strings.Join(consts, "\n") + "\n        }\n    }\n}\n")
	_ = cur
	return b.String()
}
