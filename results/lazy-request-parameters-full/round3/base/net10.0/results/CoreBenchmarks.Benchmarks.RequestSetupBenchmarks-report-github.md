```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.71 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean      | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |----------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1.354 μs | 0.0511 μs | 0.0338 μs | 0.0640 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |  1.099 μs | 0.0336 μs | 0.0200 μs | 0.0636 |   1.76 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |  1.115 μs | 0.0327 μs | 0.0195 μs | 0.0620 |   1.83 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2.546 μs | 0.0347 μs | 0.0181 μs | 0.0720 |   2.05 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2.712 μs | 0.0796 μs | 0.0527 μs | 0.0735 |   2.19 KB |
| Telemetry_InvokeSync                            | 20.876 μs | 2.3367 μs | 1.5456 μs | 0.4596 |  14.89 KB |
| Telemetry_InvokeAsync                           | 22.676 μs | 0.2958 μs | 0.1760 μs | 0.5850 |  16.23 KB |
