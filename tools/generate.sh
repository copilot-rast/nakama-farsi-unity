#!/usr/bin/env bash
set -euo pipefail
cd "$(dirname "$0")"
NF=${NF:-../../nakama-farsi}
REV=${REV:-dev}
MODULES=${MODULES:-}
tmp=$(mktemp -d)
trap 'rm -rf "$tmp"' EXIT
git -C "$NF" archive "$REV" integrations internal | tar -x -C "$tmp"
for extra in ${EXTRA:-}; do
  repo=${extra%%:*}; rest=${extra#*:}
  git -C "$repo" archive "${rest%%:*}" "${rest#*:}" | tar -x -C "$tmp"
done
go run ./rpcschema -root "$tmp" -out schema -modules "$MODULES"
go run ./rpcgen -schema schema/rpc-schema.json -out ../Packages/Nakama/Farsi/Runtime/Generated/Rpcs.g.cs
echo "generated from $(git -C "$NF" rev-parse --short "$REV")"
