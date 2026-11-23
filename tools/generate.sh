#!/usr/bin/env bash
set -euo pipefail
cd "$(dirname "$0")"
if [ -n "${NF:-}${REV:-}${EXTRA:-}${MODULES:-}" ]; then
  echo "generate.sh: NF, REV, EXTRA and MODULES are gone. A run from one repo drops the RPCs of the other games." >&2
  echo "generate.sh: every project is listed in tools/projects.txt; pin one with REV_<name>=<rev> tools/generate-all.sh" >&2
  exit 1
fi
echo "generate.sh: running tools/generate-all.sh (all projects in tools/projects.txt)" >&2
exec ./generate-all.sh "$@"
