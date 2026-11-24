# Benchmarks for normj/aws-sdk-net#66

PR: [perf(core): SigV4 signing without canonical-request and string-to-sign strings (combines #2 and #3)](https://github.com/normj/aws-sdk-net/pull/66)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [combined-string-to-sign-full](combined-string-to-sign-full/summary.md) | 2026-11-24 | `152274655ca` | `63acef10855` | `152274655ca` | Combines #2 and #3. Full run vs main, direct runs vs each original head, and Presign-only re-runs (combined and #3) vs main. |
| [combined-string-to-sign-vs-pr2-full](combined-string-to-sign-vs-pr2-full/summary.md) | 2026-11-24 | `152274655ca` | `37aaf04a222` | `152274655ca` | Combines #2 and #3. Full run vs main, direct runs vs each original head, and Presign-only re-runs (combined and #3) vs main. |
| [combined-string-to-sign-vs-pr3-full](combined-string-to-sign-vs-pr3-full/summary.md) | 2026-11-24 | `152274655ca` | `3cf3bc5aa11` | `152274655ca` | Combines #2 and #3. Full run vs main, direct runs vs each original head, and Presign-only re-runs (combined and #3) vs main. |
| [combined-string-to-sign-presign-rerun2-full](combined-string-to-sign-presign-rerun2-full/summary.md) | 2026-11-24 | `152274655ca` | `63acef10855` | `152274655ca` | Combines #2 and #3. Full run vs main, direct runs vs each original head, and Presign-only re-runs (combined and #3) vs main. |
| [combined-string-to-sign-pr3-presign-vs-main2-full](combined-string-to-sign-pr3-presign-vs-main2-full/summary.md) | 2026-11-24 | `152274655ca` | `63acef10855` | `3cf3bc5aa11` | Combines #2 and #3. Full run vs main, direct runs vs each original head, and Presign-only re-runs (combined and #3) vs main. |
