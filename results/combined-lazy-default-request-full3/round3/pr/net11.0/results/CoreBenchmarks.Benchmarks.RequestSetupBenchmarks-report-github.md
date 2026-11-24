```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.93 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |------------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,056.3 ns |   1.25 ns |   0.74 ns | 0.0506 |   1.44 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    797.6 ns |   6.30 ns |   4.17 ns | 0.0478 |   1.35 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |    818.6 ns |   5.54 ns |   3.30 ns | 0.0491 |   1.42 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,285.4 ns |  10.30 ns |   6.81 ns | 0.0547 |   1.64 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,338.7 ns |   6.27 ns |   3.73 ns | 0.0561 |   1.78 KB |
| Telemetry_InvokeSync                            | 17,064.4 ns | 182.61 ns | 120.79 ns | 0.4761 |  14.44 KB |
| Telemetry_InvokeAsync                           | 19,997.1 ns | 198.60 ns | 131.36 ns | 0.5573 |   15.7 KB |
| NewRequest_InvokeSync                           | 13,142.8 ns | 105.57 ns |  69.83 ns | 0.3676 |  10.27 KB |
| NewRequest_InvokeAsync                          | 15,418.7 ns |  58.51 ns |  34.82 ns | 0.3728 |  11.53 KB |
| RefreshingCredentials_InvokeAsync               | 16,550.9 ns |  34.22 ns |  17.90 ns | 0.3972 |  11.82 KB |
