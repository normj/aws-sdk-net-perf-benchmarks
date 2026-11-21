```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.75 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean      | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |----------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1.913 μs | 0.2815 μs | 0.1862 μs | 0.0647 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |  2.121 μs | 1.0273 μs | 0.6795 μs | 0.0583 |   1.75 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |  1.692 μs | 0.2072 μs | 0.1084 μs | 0.0620 |   1.82 KB |
| AuthResolver_PreInvoke_DefaultChain             |  3.970 μs | 0.5506 μs | 0.3277 μs | 0.0723 |   2.04 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  4.001 μs | 0.6429 μs | 0.3826 μs | 0.0655 |   2.18 KB |
| Telemetry_InvokeSync                            | 23.305 μs | 7.7541 μs | 5.1289 μs | 0.4990 |  14.89 KB |
| Telemetry_InvokeAsync                           | 20.058 μs | 0.1069 μs | 0.0636 μs | 0.5623 |  16.15 KB |
