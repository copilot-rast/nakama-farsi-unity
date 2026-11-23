package main

import (
	"flag"
	"fmt"
	"os"
	"strings"

	"nakamafarsi/unity-tools/rpcschema/gen"
)

type sourceList []gen.Source

func (s *sourceList) String() string { return fmt.Sprint(len(*s)) }

func (s *sourceList) Set(v string) error {
	head, root, ok := strings.Cut(v, "=")
	if !ok || root == "" {
		return fmt.Errorf("want name@commit=dir, got %q", v)
	}
	name, commit, _ := strings.Cut(head, "@")
	*s = append(*s, gen.Source{Name: name, Commit: commit, Root: root})
	return nil
}

func main() {
	root := flag.String("root", "", "one repository root (old single-project mode)")
	out := flag.String("out", "tools/schema", "folder for rpc-schema.json and codes.json")
	extra := flag.String("modules", "", "extra modules as name=dir,name=dir (single-project mode)")
	keep := flag.String("keep", "", "previous rpc-schema.json: shapes the scan no longer resolves are kept from it")
	exclude := flag.String("exclude", "", "file of RPC ids that are server-only and get no wrapper")
	var sources sourceList
	flag.Var(&sources, "source", "project as name@commit=dir; repeat for every project, the first one wins on conflicts")
	flag.Parse()
	var previous []byte
	if *keep != "" {
		previous, _ = os.ReadFile(*keep)
	}
	if len(sources) > 0 {
		runMulti(sources, *out, *exclude)
	} else {
		if *root == "" {
			fmt.Fprintln(os.Stderr, "rpcschema: give -source for every project (tools/generate-all.sh does this)")
			os.Exit(2)
		}
		modules := append([]gen.Module{}, gen.DefaultModules...)
		for _, part := range strings.Split(*extra, ",") {
			name, dir, ok := strings.Cut(strings.TrimSpace(part), "=")
			if ok && name != "" && dir != "" {
				modules = append(modules, gen.Module{Name: name, Dir: dir})
			}
		}
		if err := gen.Write(*root, *out, modules); err != nil {
			fmt.Fprintln(os.Stderr, err)
			os.Exit(1)
		}
	}
	if err := gen.KeepKnown(*out, previous); err != nil {
		fmt.Fprintln(os.Stderr, err)
		os.Exit(1)
	}
}

func runMulti(sources []gen.Source, out, excludePath string) {
	res, err := gen.BuildMulti(sources)
	if err != nil {
		fmt.Fprintln(os.Stderr, "rpcschema:", err)
		os.Exit(1)
	}
	exclude, err := gen.ReadExclude(excludePath)
	if err != nil {
		fmt.Fprintln(os.Stderr, "rpcschema:", err)
		os.Exit(1)
	}
	gen.DropExcluded(res, exclude)
	per := map[string]int{}
	for _, r := range res.RPCs {
		for _, p := range r.Projects {
			per[p]++
		}
	}
	for _, s := range sources {
		fmt.Printf("rpcschema: %-14s %s  %d RPCs\n", s.Name, s.Commit, per[s.Name])
	}
	for _, c := range res.Conflicts {
		fmt.Printf("rpcschema: note %s in %s: %s\n", c.ID, c.Project, c.Detail)
	}
	if problems := gen.CoverageReport(res, exclude); len(problems) > 0 {
		fmt.Fprintln(os.Stderr, "rpcschema: coverage check FAILED, nothing was written:")
		for _, p := range problems {
			fmt.Fprintln(os.Stderr, "  - "+p)
		}
		os.Exit(1)
	}
	if err := gen.WriteMulti(out, sources, res); err != nil {
		fmt.Fprintln(os.Stderr, "rpcschema:", err)
		os.Exit(1)
	}
	fmt.Printf("rpcschema: coverage ok, %d RPCs from %d projects (%d server-only skipped)\n", len(res.RPCs), len(sources), len(exclude))
}
