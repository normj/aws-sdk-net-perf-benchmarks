### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `ff81b2f7f24d3bf509c04865460871236bb6ae4e`
- Filter: `*MarshallingBenchmarks.Format_*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@0b1279d66e67db9ed95729ae9da868efeccdf8f3`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.9 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 6/6 rows faster, 0/6 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.Format_ISO8601 | net10.0 | 149.42 ns | 24.90 ns | 0.17 | faster | 72 B | 72 B | 1.00 | same |
| MarshallingBenchmarks.Format_ISO8601 | net11.0 | 153.70 ns | 21.32 ns | 0.14 | faster | 72 B | 72 B | 1.00 | same |
| MarshallingBenchmarks.Format_ISO8601NoMs | net10.0 | 81.03 ns | 19.17 ns | 0.24 | faster | 64 B | 64 B | 1.00 | same |
| MarshallingBenchmarks.Format_ISO8601NoMs | net11.0 | 84.80 ns | 18.97 ns | 0.22 | faster | 64 B | 64 B | 1.00 | same |
| MarshallingBenchmarks.Format_RFC822 | net10.0 | 116.90 ns | 26.28 ns | 0.22 | faster | 80 B | 80 B | 1.00 | same |
| MarshallingBenchmarks.Format_RFC822 | net11.0 | 113.88 ns | 21.79 ns | 0.19 | faster | 80 B | 80 B | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| MarshallingBenchmarks.Format_ISO8601 | net10.0 | base | 149.42 ns / 72 B | 151.67 ns / 72 B | 148.37 ns / 72 B |
| MarshallingBenchmarks.Format_ISO8601 | net10.0 | pr | 24.90 ns / 72 B | 31.96 ns / 72 B | 23.36 ns / 72 B |
| MarshallingBenchmarks.Format_ISO8601 | net11.0 | base | 171.00 ns / 72 B | 153.70 ns / 72 B | 143.88 ns / 72 B |
| MarshallingBenchmarks.Format_ISO8601 | net11.0 | pr | 22.00 ns / 72 B | 21.15 ns / 72 B | 21.32 ns / 72 B |
| MarshallingBenchmarks.Format_ISO8601NoMs | net10.0 | base | 81.03 ns / 64 B | 81.31 ns / 64 B | 79.71 ns / 64 B |
| MarshallingBenchmarks.Format_ISO8601NoMs | net10.0 | pr | 19.17 ns / 64 B | 31.23 ns / 64 B | 17.92 ns / 64 B |
| MarshallingBenchmarks.Format_ISO8601NoMs | net11.0 | base | 89.00 ns / 64 B | 84.80 ns / 64 B | 77.58 ns / 64 B |
| MarshallingBenchmarks.Format_ISO8601NoMs | net11.0 | pr | 20.79 ns / 64 B | 18.97 ns / 64 B | 17.71 ns / 64 B |
| MarshallingBenchmarks.Format_RFC822 | net10.0 | base | 118.36 ns / 80 B | 116.90 ns / 80 B | 113.17 ns / 80 B |
| MarshallingBenchmarks.Format_RFC822 | net10.0 | pr | 24.26 ns / 80 B | 33.92 ns / 80 B | 26.28 ns / 80 B |
| MarshallingBenchmarks.Format_RFC822 | net11.0 | base | 127.42 ns / 80 B | 113.88 ns / 80 B | 108.09 ns / 80 B |
| MarshallingBenchmarks.Format_RFC822 | net11.0 | pr | 33.44 ns / 80 B | 21.32 ns / 80 B | 21.79 ns / 80 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 7.21 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.43GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.24 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
