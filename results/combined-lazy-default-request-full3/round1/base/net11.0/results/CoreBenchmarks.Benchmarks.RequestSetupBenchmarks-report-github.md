```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.84 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |------------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,102.0 ns |   2.70 ns |   1.78 ns | 0.0661 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    866.9 ns |   2.62 ns |   1.56 ns | 0.0623 |   1.75 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |    892.6 ns |   2.84 ns |   1.69 ns | 0.0640 |   1.82 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,365.7 ns |   7.09 ns |   4.69 ns | 0.0662 |   2.04 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,466.1 ns |  98.55 ns |  65.18 ns | 0.0770 |   2.18 KB |
| Telemetry_InvokeSync                            | 17,705.1 ns | 108.85 ns |  64.78 ns | 0.4927 |  14.89 KB |
| Telemetry_InvokeAsync                           | 20,482.6 ns |  42.49 ns |  25.29 ns | 0.5734 |  16.15 KB |
| NewRequest_InvokeSync                           | 13,717.2 ns | 176.79 ns | 116.93 ns | 0.3821 |  10.73 KB |
| NewRequest_InvokeAsync                          | 15,890.1 ns |  30.42 ns |  20.12 ns | 0.3815 |  11.98 KB |
| RefreshingCredentials_InvokeAsync               | 16,838.9 ns |  79.03 ns |  52.27 ns | 0.4037 |  12.27 KB |
