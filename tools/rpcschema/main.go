package main

import (
	"flag"
	"fmt"
	"os"
	"strings"

	"nakamafarsi/unity-tools/rpcschema/gen"
)

func main() {
	root := flag.String("root", "../nakama-farsi", "nakama-farsi repository root")
	out := flag.String("out", "tools/schema", "folder for rpc-schema.json and codes.json")
	extra := flag.String("modules", "", "extra modules as name=dir,name=dir (game plugins)")
	flag.Parse()
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
