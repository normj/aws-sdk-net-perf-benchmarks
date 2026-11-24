```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.57 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error     | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |------------:|----------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,175.2 ns |   7.79 ns |  5.15 ns | 0.0516 |   1.44 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    935.9 ns |   9.60 ns |  6.35 ns | 0.0485 |   1.35 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |    978.2 ns |   6.63 ns |  4.38 ns | 0.0508 |   1.42 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,441.2 ns |  13.94 ns |  8.30 ns | 0.0586 |   1.64 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,506.5 ns |  13.86 ns |  9.17 ns | 0.0598 |   1.78 KB |
| Telemetry_InvokeSync                            | 18,695.3 ns |  61.09 ns | 40.41 ns | 0.5215 |  14.44 KB |
| Telemetry_InvokeAsync                           | 21,580.5 ns |  87.23 ns | 57.69 ns | 0.5172 |   15.7 KB |
| NewRequest_InvokeSync                           | 14,083.4 ns |  43.85 ns | 29.01 ns | 0.3378 |  10.27 KB |
| NewRequest_InvokeAsync                          | 16,652.7 ns |  63.00 ns | 41.67 ns | 0.3981 |  11.53 KB |
| RefreshingCredentials_InvokeAsync               | 17,715.0 ns | 113.73 ns | 75.22 ns | 0.4223 |  11.82 KB |
