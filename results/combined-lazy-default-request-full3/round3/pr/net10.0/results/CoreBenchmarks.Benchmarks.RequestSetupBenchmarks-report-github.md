```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.98 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |------------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,175.4 ns |   6.10 ns |   4.04 ns | 0.0516 |   1.44 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    923.0 ns |  15.16 ns |  10.03 ns | 0.0480 |   1.36 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |    963.5 ns |   3.18 ns |   2.10 ns | 0.0500 |   1.43 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,394.6 ns |  12.63 ns |   7.52 ns | 0.0576 |   1.65 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,509.3 ns |   5.83 ns |   3.47 ns | 0.0601 |   1.79 KB |
| Telemetry_InvokeSync                            | 18,615.1 ns | 263.57 ns | 156.85 ns | 0.5196 |  14.44 KB |
| Telemetry_InvokeAsync                           | 21,175.5 ns |  76.60 ns |  50.67 ns | 0.5095 |  15.77 KB |
| NewRequest_InvokeSync                           | 14,280.4 ns | 107.40 ns |  63.91 ns | 0.3422 |  10.27 KB |
| NewRequest_InvokeAsync                          | 16,501.7 ns |  43.67 ns |  25.99 ns | 0.3960 |  11.61 KB |
| RefreshingCredentials_InvokeAsync               | 17,483.6 ns |  38.01 ns |  22.62 ns | 0.4199 |   11.9 KB |
