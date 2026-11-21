```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.82 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean      | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |----------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1.266 μs | 0.0025 μs | 0.0015 μs | 0.0655 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |  1.003 μs | 0.0162 μs | 0.0107 μs | 0.0637 |   1.76 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |  1.048 μs | 0.0024 μs | 0.0014 μs | 0.0628 |   1.83 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2.470 μs | 0.0059 μs | 0.0039 μs | 0.0692 |   2.05 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2.530 μs | 0.0105 μs | 0.0070 μs | 0.0707 |   2.19 KB |
| Telemetry_InvokeSync                            | 19.304 μs | 0.0912 μs | 0.0603 μs | 0.5375 |  14.89 KB |
| Telemetry_InvokeAsync                           | 22.604 μs | 0.1672 μs | 0.1106 μs | 0.5380 |  16.23 KB |
