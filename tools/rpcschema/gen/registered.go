package gen

import (
	"fmt"
	"go/ast"
	"go/parser"
	"go/token"
	"os"
	"path/filepath"
	"sort"
)

type regPkg struct {
	funcs   map[string][]*ast.FuncDecl
	consts  map[string]string
	appends map[string][]ast.Expr
}

func RegisteredIDs(root string) (map[string]string, []string, error) {
	ids := map[string]string{}
	unknown := []string{}
	for _, top := range []string{"integrations", "internal"} {
		entries, err := os.ReadDir(filepath.Join(root, top))
		if err != nil {
			if os.IsNotExist(err) {
				continue
			}
			return nil, nil, err
		}
		for _, e := range entries {
			if !e.IsDir() {
				continue
			}
			dir := filepath.Join(root, top, e.Name())
			files, err := goFiles(dir, false)
			if err != nil {
				return nil, nil, err
			}
			if err := scanRegistrations(root, files, ids, &unknown); err != nil {
				return nil, nil, err
			}
		}
	}
	sort.Strings(unknown)
	return ids, unknown, nil
}

func scanRegistrations(root string, files []string, ids map[string]string, unknown *[]string) error {
	fset := token.NewFileSet()
	p := &regPkg{funcs: map[string][]*ast.FuncDecl{}, consts: map[string]string{}, appends: map[string][]ast.Expr{}}
	parsed := []*ast.File{}
	for _, f := range files {
		file, err := parser.ParseFile(fset, f, nil, 0)
		if err != nil {
			return err
		}
		parsed = append(parsed, file)
		ast.Inspect(file, func(n ast.Node) bool {
			as, ok := n.(*ast.AssignStmt)
			if !ok || len(as.Lhs) != 1 || len(as.Rhs) != 1 {
				return true
			}
			lid, ok := as.Lhs[0].(*ast.Ident)
			call, cok := as.Rhs[0].(*ast.CallExpr)
			if ok && cok && calleeName(call.Fun) == "append" && len(call.Args) > 1 {
				if first, ok := call.Args[0].(*ast.Ident); ok && first.Name == lid.Name {
					p.appends[lid.Name] = append(p.appends[lid.Name], call.Args[1:]...)
				}
			}
			return true
		})
		for _, d := range file.Decls {
			switch decl := d.(type) {
			case *ast.FuncDecl:
				p.funcs[decl.Name.Name] = append(p.funcs[decl.Name.Name], decl)
			case *ast.GenDecl:
				for _, s := range decl.Specs {
					vs, ok := s.(*ast.ValueSpec)
					if !ok {
						continue
					}
					for i, n := range vs.Names {
						if i < len(vs.Values) {
							if v, ok := stringLit(vs.Values[i]); ok {
								p.consts[n.Name] = v
							}
						}
					}
				}
			}
		}
	}
	for _, file := range parsed {
		for _, d := range file.Decls {
			fd, ok := d.(*ast.FuncDecl)
			if !ok || fd.Body == nil {
				continue
			}
			var stack []ast.Node
			ast.Inspect(fd.Body, func(n ast.Node) bool {
				if n == nil {
					stack = stack[:len(stack)-1]
					return true
				}
				stack = append(stack, n)
				call, ok := n.(*ast.CallExpr)
				if !ok || calleeName(call.Fun) != "RegisterRpc" || len(call.Args) != 2 {
					return true
				}
				pos := fset.Position(call.Pos())
				rel, _ := filepath.Rel(root, pos.Filename)
				where := fmt.Sprintf("%s:%d", filepath.ToSlash(rel), pos.Line)
				found, ok := p.resolve(call.Args[0], stack, fd)
				if !ok {
					*unknown = append(*unknown, where)
					return true
				}
				for _, id := range found {
					if _, seen := ids[id]; !seen {
						ids[id] = where
					}
				}
				return true
			})
		}
	}
	return nil
}

func (p *regPkg) resolve(arg ast.Expr, stack []ast.Node, fd *ast.FuncDecl) ([]string, bool) {
	if s, ok := stringLit(arg); ok {
		return []string{s}, true
	}
	id, ok := arg.(*ast.Ident)
	if !ok {
		return nil, false
	}
	for i := len(stack) - 1; i >= 0; i-- {
		rs, ok := stack[i].(*ast.RangeStmt)
		if !ok {
			continue
		}
		key, ok := rs.Key.(*ast.Ident)
		if !ok || key.Name != id.Name {
			continue
		}
		return p.mapKeys(rs.X, fd, 0)
	}
	if v, ok := p.consts[id.Name]; ok {
		return []string{v}, true
	}
	return nil, false
}

func (p *regPkg) mapKeys(x ast.Expr, fd *ast.FuncDecl, depth int) ([]string, bool) {
	if depth > 4 {
		return nil, false
	}
	switch v := x.(type) {
	case *ast.CallExpr:
		name := calleeName(v.Fun)
		list := p.funcs[name]
		if len(list) == 0 {
			return nil, false
		}
		out := []string{}
		for _, f := range list {
			keys, ok := p.keysIn(f.Body, f, depth)
			if !ok {
				return nil, false
			}
			out = append(out, keys...)
		}
		return out, true
	case *ast.Ident:
		var src ast.Expr
		ast.Inspect(fd.Body, func(n ast.Node) bool {
			as, ok := n.(*ast.AssignStmt)
			if !ok || src != nil {
				return src == nil
			}
			for i, l := range as.Lhs {
				if lid, ok := l.(*ast.Ident); ok && lid.Name == v.Name && i < len(as.Rhs) {
					src = as.Rhs[i]
				}
			}
			return true
		})
		if src == nil {
			return nil, false
		}
		var base []string
		var ok bool
		if lit, isLit := src.(*ast.CompositeLit); isLit {
			base, ok = p.literalKeys(lit)
		} else {
			base, ok = p.mapKeys(src, fd, depth+1)
		}
		if !ok {
			return nil, false
		}
		more, ok := p.rangeIntoMap(fd, v.Name, depth)
		if !ok {
			return nil, false
		}
		return append(base, more...), true
	case *ast.CompositeLit:
		return p.literalKeys(v)
	}
	return nil, false
}

func (p *regPkg) rangeIntoMap(fd *ast.FuncDecl, target string, depth int) ([]string, bool) {
	out := []string{}
	ok := true
	ast.Inspect(fd.Body, func(n ast.Node) bool {
		rs, isRange := n.(*ast.RangeStmt)
		if !isRange || !ok {
			return ok
		}
		key, isIdent := rs.Key.(*ast.Ident)
		if !isIdent {
			return true
		}
		fills := false
		ast.Inspect(rs.Body, func(m ast.Node) bool {
			as, isAssign := m.(*ast.AssignStmt)
			if !isAssign {
				return true
			}
			for _, l := range as.Lhs {
				ix, isIndex := l.(*ast.IndexExpr)
				if !isIndex {
					continue
				}
				x, xok := ix.X.(*ast.Ident)
				k, kok := ix.Index.(*ast.Ident)
				if xok && kok && x.Name == target && k.Name == key.Name {
					fills = true
				}
			}
			return true
		})
		if !fills {
			return true
		}
		if keys, good := p.mapKeys(rs.X, fd, depth+1); good {
			out = append(out, keys...)
			return true
		}
		keys, good := p.providerKeys(fd, rs.X)
		if !good {
			ok = false
			return false
		}
		out = append(out, keys...)
		return true
	})
	return out, ok
}

func (p *regPkg) providerKeys(fd *ast.FuncDecl, x ast.Expr) ([]string, bool) {
	call, ok := x.(*ast.CallExpr)
	if !ok {
		return nil, false
	}
	fn, ok := call.Fun.(*ast.Ident)
	if !ok {
		return nil, false
	}
	list := ""
	ast.Inspect(fd.Body, func(n ast.Node) bool {
		rs, isRange := n.(*ast.RangeStmt)
		if !isRange {
			return true
		}
		if val, isIdent := rs.Value.(*ast.Ident); isIdent && val.Name == fn.Name {
			if v, isIdent := rs.X.(*ast.Ident); isIdent {
				list = v.Name
			}
		}
		return true
	})
	if list == "" {
		return nil, false
	}
	out := []string{}
	good := true
	for _, e := range p.appends[list] {
		ast.Inspect(e, func(n ast.Node) bool {
			lit, isLit := n.(*ast.CompositeLit)
			if !isLit {
				return true
			}
			if _, isMap := lit.Type.(*ast.MapType); !isMap {
				return true
			}
			keys, ok := p.literalKeys(lit)
			if !ok {
				good = false
			}
			out = append(out, keys...)
			return false
		})
	}
	return out, good
}

func (p *regPkg) keysIn(body *ast.BlockStmt, fd *ast.FuncDecl, depth int) ([]string, bool) {
	if body == nil {
		return nil, false
	}
	out := []string{}
	ok := true
	ast.Inspect(body, func(n ast.Node) bool {
		switch st := n.(type) {
		case *ast.CompositeLit:
			if _, isMap := st.Type.(*ast.MapType); isMap {
				keys, good := p.literalKeys(st)
				if !good {
					ok = false
				}
				out = append(out, keys...)
				return false
			}
		case *ast.AssignStmt:
			for _, l := range st.Lhs {
				ix, isIndex := l.(*ast.IndexExpr)
				if !isIndex {
					continue
				}
				if s, good := stringLit(ix.Index); good {
					out = append(out, s)
				} else if id, good := ix.Index.(*ast.Ident); good {
					if c, found := p.consts[id.Name]; found {
						out = append(out, c)
					}
				}
			}
		case *ast.RangeStmt:
			keys, good := p.mapKeys(st.X, fd, depth+1)
			if good {
				out = append(out, keys...)
			}
		}
		return true
	})
	return out, ok
}

func (p *regPkg) literalKeys(lit *ast.CompositeLit) ([]string, bool) {
	out := []string{}
	for _, el := range lit.Elts {
		kv, ok := el.(*ast.KeyValueExpr)
		if !ok {
			return nil, false
		}
		if s, ok := stringLit(kv.Key); ok {
			out = append(out, s)
			continue
		}
		if id, ok := kv.Key.(*ast.Ident); ok {
			if c, found := p.consts[id.Name]; found {
				out = append(out, c)
				continue
			}
		}
		return nil, false
	}
	return out, true
}
