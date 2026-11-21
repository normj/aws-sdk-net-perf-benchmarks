### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `ff81b2f7f24d3bf509c04865460871236bb6ae4e`
- Filter: `*MarshallingBenchmarks.Format_*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@0b1279d66e67db9ed95729ae9da868efeccdf8f3`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.2 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: MarshallingBenchmarks.Format_ISO8601 time, MarshallingBenchmarks.Format_ISO8601NoMs time, MarshallingBenchmarks.Format_RFC822 time.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.Format_ISO8601 | net10.0 | 149.93 ns | 23.35 ns | 0.16 | faster | 72 B | 72 B | 1.00 | same |
| MarshallingBenchmarks.Format_ISO8601NoMs | net10.0 | 79.72 ns | 17.90 ns | 0.22 | faster | 64 B | 64 B | 1.00 | same |
| MarshallingBenchmarks.Format_RFC822 | net10.0 | 116.29 ns | 21.58 ns | 0.19 | faster | 80 B | 80 B | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| MarshallingBenchmarks.Format_ISO8601 | net10.0 | base | 149.93 ns / 72 B |
| MarshallingBenchmarks.Format_ISO8601 | net10.0 | pr | 23.35 ns / 72 B |
| MarshallingBenchmarks.Format_ISO8601NoMs | net10.0 | base | 79.72 ns / 64 B |
| MarshallingBenchmarks.Format_ISO8601NoMs | net10.0 | pr | 17.90 ns / 64 B |
| MarshallingBenchmarks.Format_RFC822 | net10.0 | base | 116.29 ns / 80 B |
| MarshallingBenchmarks.Format_RFC822 | net10.0 | pr | 21.58 ns / 80 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.16 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
