### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `05ef1d7349a7b6e59cc6b5051127c79c800a23bd`
- Filter: `*SigningBenchmarks.Sign_S3*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@e476b0db37ef8af19ea2212b80411fb387a51e5f`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.7 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 0/6 rows faster, 2/6 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | 5.37 us | 5.34 us | 1.00 | same | 4.44 KB | 4.44 KB | 1.00 | same |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | 5.26 us | 5.32 us | 1.01 | same | 4.44 KB | 4.44 KB | 1.00 | same |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | 5.55 us | 5.57 us | 1.00 | same | 4.51 KB | 4.51 KB | 1.00 | same |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | 5.40 us | 5.48 us | 1.02 | same | 4.51 KB | 4.51 KB | 1.00 | same |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net10.0 | 6.80 us | 6.55 us | 0.96 | same | 5.84 KB | 5.56 KB | 0.95 | less |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net11.0 | 6.66 us | 6.54 us | 0.98 | same | 5.84 KB | 5.56 KB | 0.95 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | base | 5.42 us / 4.44 KB | 5.37 us / 4.44 KB | 5.34 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | pr | 5.45 us / 4.44 KB | 5.31 us / 4.44 KB | 5.34 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | base | 5.24 us / 4.44 KB | 5.31 us / 4.44 KB | 5.26 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | pr | 5.27 us / 4.44 KB | 5.51 us / 4.44 KB | 5.32 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | base | 5.70 us / 4.51 KB | 5.55 us / 4.51 KB | 5.55 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | pr | 5.63 us / 4.51 KB | 5.57 us / 4.51 KB | 5.55 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | base | 5.40 us / 4.51 KB | 5.41 us / 4.51 KB | 5.40 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | pr | 5.48 us / 4.51 KB | 5.65 us / 4.51 KB | 5.44 us / 4.51 KB |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net10.0 | base | 6.71 us / 5.84 KB | 6.88 us / 5.84 KB | 6.80 us / 5.84 KB |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net10.0 | pr | 6.67 us / 5.56 KB | 6.55 us / 5.56 KB | 6.55 us / 5.56 KB |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net11.0 | base | 6.62 us / 5.84 KB | 6.66 us / 5.84 KB | 6.71 us / 5.84 KB |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net11.0 | pr | 6.47 us / 5.56 KB | 6.75 us / 5.56 KB | 6.54 us / 5.56 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.53 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.21 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
