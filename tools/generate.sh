#!/usr/bin/env bash
set -euo pipefail
cd "$(dirname "$0")"
NF=${NF:-../../nakama-farsi}
REV=${REV:-dev}
MODULES=${MODULES:-}
tmp=$(mktemp -d)
trap 'rm -rf "$tmp"' EXIT
git -C "$NF" archive "$REV" integrations | tar -x -C "$tmp"
go run ./rpcschema -root "$tmp" -out schema -modules "$MODULES"
go run ./rpcgen -schema schema/rpc-schema.json -out ../Packages/Nakama/Farsi/Runtime/Generated/Rpcs.g.cs
echo "generated from $(git -C "$NF" rev-parse --short "$REV")"
