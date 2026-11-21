```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.61 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                          | Mean      | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |----------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1.299 μs | 0.0401 μs | 0.0143 μs | 0.0568 |   1.67 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |  1.057 μs | 0.0749 μs | 0.0267 μs | 0.0544 |   1.59 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |  1.063 μs | 0.0253 μs | 0.0090 μs | 0.0603 |   1.66 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2.575 μs | 0.0753 μs | 0.0269 μs | 0.0621 |   1.88 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2.699 μs | 0.1598 μs | 0.0570 μs | 0.0633 |   2.02 KB |
| Telemetry_InvokeSync                            | 19.710 μs | 1.8781 μs | 0.6697 μs | 0.4717 |  14.67 KB |
| Telemetry_InvokeAsync                           | 22.732 μs | 0.7696 μs | 0.2744 μs | 0.5539 |  16.01 KB |
