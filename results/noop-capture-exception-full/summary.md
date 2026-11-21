### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `862cb393ed10461a63d5d8c08fedc5fa769f7382`
- Filter: `*PipelineBenchmarks*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@3da4269379c2c79cff44e45bd2afb3325f06f60d`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.5 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** regression. At least one row is slower or allocates more.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | 15.40 us | 15.77 us | 1.02 | same | 11.77 KB | 11.77 KB | 1.00 | same |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | 14.03 us | 14.24 us | 1.01 | same | 11.77 KB | 11.77 KB | 1.00 | same |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | 21.93 us | 23.95 us | 1.09 | **slower** | 13.04 KB | 13.04 KB | 1.00 | same |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | 19.08 us | 20.70 us | 1.08 | same | 11.92 KB | 12.06 KB | 1.01 | **more** |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | 252.76 us | 122.86 us | 0.49 | faster | 108.74 KB | 44.60 KB | 0.41 | less |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | 224.68 us | 101.70 us | 0.45 | faster | 108.81 KB | 44.67 KB | 0.41 | less |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 13.44 us | 13.45 us | 1.00 | same | 10.51 KB | 10.51 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | 12.23 us | 12.29 us | 1.00 | same | 10.51 KB | 10.51 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | 57.81 us | 39.35 us | 0.68 | faster | 44.53 KB | 15.14 KB | 0.34 | less |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | 51.15 us | 34.21 us | 0.67 | faster | 44.53 KB | 15.14 KB | 0.34 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | base | 16.35 us / 11.77 KB | 15.40 us / 11.77 KB | 15.22 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | pr | 15.77 us / 11.77 KB | 16.07 us / 11.77 KB | 15.41 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | base | 14.13 us / 11.77 KB | 13.96 us / 11.77 KB | 14.03 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | pr | 13.92 us / 11.77 KB | 15.18 us / 11.77 KB | 14.24 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | base | 21.93 us / 13.04 KB | 22.41 us / 13.04 KB | 21.92 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | pr | 23.95 us / 13.04 KB | 32.20 us / 13.04 KB | 22.47 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | base | 20.76 us / 11.95 KB | 18.83 us / 11.90 KB | 19.08 us / 11.92 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | pr | 20.70 us / 12.24 KB | 23.75 us / 12.06 KB | 19.57 us / 11.96 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | base | 268.78 us / 108.75 KB | 250.24 us / 108.74 KB | 252.76 us / 108.71 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | pr | 121.54 us / 44.60 KB | 150.95 us / 44.60 KB | 122.86 us / 44.60 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | base | 224.68 us / 108.81 KB | 253.12 us / 108.80 KB | 220.68 us / 108.81 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | pr | 101.70 us / 44.67 KB | 117.24 us / 44.67 KB | 100.35 us / 44.67 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 13.60 us / 10.51 KB | 13.44 us / 10.51 KB | 13.05 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 13.45 us / 10.51 KB | 13.73 us / 10.51 KB | 12.86 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | base | 12.38 us / 10.51 KB | 12.23 us / 10.51 KB | 12.07 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | pr | 12.29 us / 10.51 KB | 13.22 us / 10.51 KB | 12.25 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | base | 57.87 us / 44.53 KB | 57.81 us / 44.53 KB | 56.84 us / 44.53 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | pr | 39.30 us / 15.14 KB | 40.29 us / 15.14 KB | 39.35 us / 15.14 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | base | 51.15 us / 44.53 KB | 50.31 us / 44.53 KB | 55.13 us / 48.61 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | pr | 34.08 us / 15.14 KB | 35.21 us / 15.14 KB | 34.21 us / 15.14 KB |

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
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.22 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
