#!/usr/bin/env python3
"""Combine BenchmarkDotNet JSON reports written by ab.sh into a markdown summary.

Layout read: <out>/round<N>/<base|pr>/<tfm>/results/*-report-full-compressed.json,
plus the optional <out>/round<N>/<base|pr>/<tfm>/load.txt that ab.sh writes before each measurement.
"""
import argparse
import glob
import json
import os
import re
import statistics
import sys

RUNTIME_RE = re.compile(r"Runtime=([^,)]+)")


def fmt_time(ns):
    if ns is None:
        return "n/a"
    for unit, scale in (("s", 1e9), ("ms", 1e6), ("us", 1e3)):
        if ns >= scale:
            return f"{ns / scale:,.2f} {unit}"
    return f"{ns:,.2f} ns"


def fmt_bytes(b):
    if b is None:
        return "n/a"
    if b >= 1024 * 1024:
        return f"{b / (1024 * 1024):,.2f} MB"
    if b >= 1024:
        return f"{b / 1024:,.2f} KB"
    return f"{b:,} B"


def ratio(new, old):
    if new is None or old is None:
        return "n/a"
    if old == 0:
        return "1.00" if new == 0 else "new"
    return f"{new / old:.2f}"


def load(out_dir):
    """Return {side: {key: [(mean_ns, alloc_bytes), ...per round]}}, env_header."""
    data = {"base": {}, "pr": {}}
    env_headers = {}
    rounds = sorted(
        (d for d in glob.glob(os.path.join(out_dir, "round*")) if os.path.isdir(d)),
        key=lambda p: int(re.sub(r"\D", "", os.path.basename(p)) or 0),
    )
    for rdir in rounds:
        for side in ("base", "pr"):
            for path in glob.glob(os.path.join(rdir, side, "**", "*-report-full-compressed.json"), recursive=True):
                with open(path) as f:
                    report = json.load(f)
                for b in report.get("Benchmarks", []):
                    stats = b.get("Statistics") or {}
                    if not stats:
                        continue  # failed benchmark case
                    # ab.sh writes each runtime to <side>/<tfm>/...; fall back to DisplayInfo.
                    rel = os.path.relpath(path, os.path.join(rdir, side)).split(os.sep)
                    if len(rel) > 1 and rel[0].startswith("net"):
                        runtime = rel[0]
                    else:
                        m = RUNTIME_RE.search(b.get("DisplayInfo", ""))
                        runtime = m.group(1).strip() if m else "?"
                    params = b.get("Parameters") or ""
                    name = f"{b['Type']}.{b['Method']}" + (f"({params})" if params else "")
                    key = (name, runtime)
                    alloc = (b.get("Memory") or {}).get("BytesAllocatedPerOperation")
                    data[side].setdefault(key, []).append((stats["Mean"], alloc))
                if runtime not in env_headers and side == "base":
                    md = path.replace("-report-full-compressed.json", "-report-github.md")
                    if os.path.exists(md):
                        with open(md) as f:
                            text = f.read()
                        mm = re.search(r"```(.*?)```", text, re.S)
                        if mm:
                            env_headers[runtime] = mm.group(1).strip()
    return data, env_headers, len(rounds)


TIME_THRESHOLD = 0.05   # median change needed for a time verdict
ALLOC_THRESHOLD = 0.01  # median change needed for an allocation verdict; allocation is near-deterministic


def _consistent(base, pr, threshold, better, worse):
    """better/worse only when the median moves by threshold AND every PR round is on the same side of every base round."""
    if not base or not pr:
        return "incomplete"
    b_med, p_med = statistics.median(base), statistics.median(pr)
    if b_med == 0:
        return "same" if p_med == 0 else worse
    change = (p_med - b_med) / b_med
    if max(pr) < min(base) and change <= -threshold:
        return better
    if min(pr) > max(base) and change >= threshold:
        return worse
    return "same"


def verdict(base_means, pr_means):
    return _consistent(base_means, pr_means, TIME_THRESHOLD, "faster", "**slower**")


def alloc_verdict(base_allocs, pr_allocs):
    return _consistent(base_allocs, pr_allocs, ALLOC_THRESHOLD, "less", "**more**")


def load_notes(out_dir):
    """Return (busiest start seen, list of measurements that started above the threshold)."""
    seen, busy = [], []
    for path in sorted(glob.glob(os.path.join(out_dir, "round*", "*", "*", "load.txt"))):
        with open(path) as f:
            fields = dict(kv.split("=", 1) for kv in f.read().split() if "=" in kv)
        try:
            load, limit = float(fields["load1"]), float(fields["max"])
        except (KeyError, ValueError):
            continue
        seen.append(load)
        if load > limit:
            busy.append((os.path.relpath(os.path.dirname(path), out_dir), load, limit))
    return (max(seen) if seen else None), busy


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("out_dir")
    ap.add_argument("--base", required=True)
    ap.add_argument("--pr", required=True)
    ap.add_argument("--filter", default="")
    ap.add_argument("--bench", default="", help="commit of the benchmarks repo the benchmark source came from")
    args = ap.parse_args()

    data, env_headers, n_rounds = load(args.out_dir)
    keys = sorted(set(data["base"]) | set(data["pr"]), key=lambda k: (k[0], k[1]))
    if not keys:
        print("No benchmark results found.", file=sys.stderr)
        sys.exit(1)

    lines = []
    lines.append("### BenchmarkDotNet A/B results")
    lines.append("")
    lines.append(f"- Base: `{args.base}`")
    lines.append(f"- PR: `{args.pr}`")
    lines.append(f"- Filter: `{args.filter}`")
    if args.bench:
        lines.append(f"- Benchmark source: `aws-sdk-net-perf-benchmarks@{args.bench}`")
    lines.append(f"- {n_rounds} interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. "
                 "Values are the median of the per-round means.")
    lines.append("- Time verdict is `faster` or `slower` only when the median changes by at least 5% "
                 "and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule "
                 "with a 1% threshold.")
    max_load, busy = load_notes(args.out_dir)
    if max_load is not None:
        lines.append(f"- Busiest start of a measurement: {max_load:.1f} other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).")
    if busy:
        lines.append("")
        lines.append(f"> [!WARNING]")
        lines.append(f"> {len(busy)} measurement(s) started while the machine was busy, so time numbers may be noisy: "
                     + ", ".join(f"`{where}` ({load:.1f} runnable tasks > {limit:g})" for where, load, limit in busy) + ".")
    lines.append("")
    lines.append("| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |")
    lines.append("|---|---|---:|---:|---:|---|---:|---:|---:|---|")
    time_verdicts, alloc_verdicts = [], []
    for key in keys:
        b = data["base"].get(key, [])
        p = data["pr"].get(key, [])
        bm = [x[0] for x in b]
        pm = [x[0] for x in p]
        ba = [x[1] for x in b if x[1] is not None]
        pa = [x[1] for x in p if x[1] is not None]
        b_mean = statistics.median(bm) if bm else None
        p_mean = statistics.median(pm) if pm else None
        b_alloc = int(statistics.median(ba)) if ba else None
        p_alloc = int(statistics.median(pa)) if pa else None
        tv = verdict(bm, pm)
        av = alloc_verdict(ba, pa) if ba and pa else "n/a"
        time_verdicts.append(tv)
        alloc_verdicts.append(av)
        lines.append(
            f"| {key[0]} | {key[1]} | {fmt_time(b_mean)} | {fmt_time(p_mean)} | {ratio(p_mean, b_mean)} | {tv} "
            f"| {fmt_bytes(b_alloc)} | {fmt_bytes(p_alloc)} | {ratio(p_alloc, b_alloc)} | {av} |"
        )

    # Overall line, matching the perf-PR bar: a consistent time win of at least 5% or any
    # consistent allocation reduction, with no row getting slower or allocating more.
    regressed = [v for v in time_verdicts + alloc_verdicts if v in ("**slower**", "**more**")]
    wins = [v for v in time_verdicts if v == "faster"] + [v for v in alloc_verdicts if v == "less"]
    incomplete = [v for v in time_verdicts if v == "incomplete"]
    if regressed:
        overall = "regression. At least one row is slower or allocates more"
    elif incomplete:
        overall = "incomplete: some rows are missing base or PR results"
    elif wins:
        overall = (f"win: {time_verdicts.count('faster')}/{len(time_verdicts)} rows faster, "
                   f"{alloc_verdicts.count('less')}/{len(alloc_verdicts)} rows allocate less")
    else:
        overall = "no measurable change: below the 5% time bar and no allocation reduction"
    lines.insert(lines.index("| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |") - 1,
                 f"\n**Overall:** {overall}.")

    lines.append("")
    lines.append("<details><summary>Per-round means</summary>")
    lines.append("")
    lines.append("| Benchmark | Runtime | Side | " + " | ".join(f"Round {i}" for i in range(1, n_rounds + 1)) + " |")
    lines.append("|---|---|---|" + "---:|" * n_rounds)
    for key in keys:
        for side in ("base", "pr"):
            vals = data[side].get(key, [])
            cells = [f"{fmt_time(v[0])} / {fmt_bytes(v[1])}" for v in vals]
            cells += [""] * (n_rounds - len(cells))
            lines.append(f"| {key[0]} | {key[1]} | {side} | " + " | ".join(cells) + " |")
    lines.append("")
    lines.append("</details>")

    if env_headers:
        lines.append("")
        lines.append("<details><summary>Environment</summary>")
        for rt in sorted(env_headers):
            lines.append("")
            lines.append("```")
            lines.append(env_headers[rt])
            lines.append("```")
        lines.append("")
        lines.append("</details>")

    print("\n".join(lines))


if __name__ == "__main__":
    main()
