#!/usr/bin/env bash
# Run a heavy command that must not overlap a benchmark measurement (unit tests, full builds):
#   ./with-test-lock.sh dotnet test ...
# Any number of these can run at the same time. They take the benchmark lock in shared mode, so
# they only wait while ab.sh is measuring, or has queued to measure (the gate gives benchmarks
# priority). The lock is held by the flock process (-o), never inherited by dotnet's build servers.
set -euo pipefail
LOCK=${AB_LOCK:-/tmp/core-bench.lock}
GATE=${AB_GATE:-$LOCK.gate}
flock -s "$GATE" true
exec flock -s -o "$LOCK" "$@"
