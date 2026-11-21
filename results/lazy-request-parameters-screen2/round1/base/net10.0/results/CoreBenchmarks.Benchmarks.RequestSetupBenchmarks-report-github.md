```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.06 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                          | Mean      | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |----------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1.518 μs | 0.2988 μs | 0.1065 μs | 0.0624 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |  1.047 μs | 0.0531 μs | 0.0190 μs | 0.0600 |   1.76 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |  1.106 μs | 0.0599 μs | 0.0155 μs | 0.0634 |   1.83 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2.532 μs | 0.0221 μs | 0.0079 μs | 0.0719 |   2.05 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2.602 μs | 0.0282 μs | 0.0100 μs | 0.0726 |   2.19 KB |
| Telemetry_InvokeSync                            | 19.442 μs | 1.1128 μs | 0.2890 μs | 0.5342 |  14.89 KB |
| Telemetry_InvokeAsync                           | 22.472 μs | 1.3691 μs | 0.4882 μs | 0.5350 |  16.23 KB |
