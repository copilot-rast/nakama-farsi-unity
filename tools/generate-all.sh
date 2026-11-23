#!/usr/bin/env bash
set -euo pipefail
cd "$(dirname "$0")"
tools=$(pwd)
pkg=../Packages/Nakama
target=$pkg/Farsi/Runtime/Generated/Rpcs.g.cs
allow=0
check=0
for arg in "$@"; do
  case "$arg" in
    --allow-breaking) allow=1 ;;
    --check) check=1 ;;
    *) echo "usage: tools/generate-all.sh [--check] [--allow-breaking]" >&2; exit 2 ;;
  esac
done
work=$(mktemp -d)
trap 'rm -rf "$work"' EXIT
sources=()
while read -r name repo rev; do
  case "$name" in ''|'#'*) continue ;; esac
  var="REV_${name//-/_}"
  rev=${!var:-$rev}
  if ! git -C "$repo" rev-parse --verify --quiet "$rev^{commit}" >/dev/null; then
    echo "generate-all: $name: $repo has no $rev; every project in projects.txt must be on disk" >&2
    exit 1
  fi
  commit=$(git -C "$repo" rev-parse --short "$rev")
  mkdir -p "$work/src/$name"
  git -C "$repo" archive "$rev" integrations internal | LC_ALL=C tar -x -C "$work/src/$name"
  sources+=(-source "$name@$commit=$work/src/$name")
done < projects.txt
mkdir -p "$work/schema" "$work/out"
git -C .. show "HEAD:tools/schema/rpc-schema.json" > "$work/old-schema.json"
go run ./rpcschema "${sources[@]}" -out "$work/schema" -exclude rpc-exclude.txt -keep "$work/old-schema.json"
go run ./rpcgen -schema "$work/schema/rpc-schema.json" -out "$work/out/Rpcs.g.cs"
git -C .. show "HEAD:Packages/Nakama/Farsi/Runtime/Generated/Rpcs.g.cs" > "$work/old.cs"
git -C .. show "HEAD:Packages/Nakama/package.json" > "$work/old-package.json"
gate=(-old "$work/old.cs" -new "$work/out/Rpcs.g.cs" -old-package "$work/old-package.json" -new-package "$pkg/package.json" -usage "$work/out/OldApiUsage.g.cs")
if [ "$allow" = 1 ]; then gate+=(-allow-breaking); fi
go run ./apicompat "${gate[@]}"
if [ "$check" = 1 ]; then
  if cmp -s "$work/out/Rpcs.g.cs" "$target"; then
    echo "generate-all: $target is up to date"
    exit 0
  fi
  echo "generate-all: $target is stale; run tools/generate-all.sh" >&2
  exit 1
fi
cp "$work/schema/rpc-schema.json" "$work/schema/codes.json" schema/
cp "$work/out/Rpcs.g.cs" "$target"
cp "$work/out/OldApiUsage.g.cs" "$pkg/Farsi/Tests~/ApiCompatCheck/OldApiUsage.g.cs"
echo "generate-all: wrote $target"
