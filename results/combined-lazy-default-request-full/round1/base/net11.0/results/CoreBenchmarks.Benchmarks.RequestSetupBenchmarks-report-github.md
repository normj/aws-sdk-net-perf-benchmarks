```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.16 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |------------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,099.2 ns |  26.63 ns |  13.93 ns | 0.0656 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    872.8 ns |   1.94 ns |   1.15 ns | 0.0627 |   1.75 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |    885.4 ns |   5.06 ns |   3.35 ns | 0.0635 |   1.82 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,418.7 ns |  28.23 ns |  14.76 ns | 0.0675 |   2.04 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,422.7 ns |   8.05 ns |   5.32 ns | 0.0776 |   2.18 KB |
| Telemetry_InvokeSync                            | 17,669.4 ns |  37.83 ns |  22.51 ns | 0.4944 |  14.89 KB |
| Telemetry_InvokeAsync                           | 20,396.1 ns |  99.68 ns |  52.14 ns | 0.5217 |  16.15 KB |
| NewRequest_InvokeSync                           | 13,431.0 ns |  53.25 ns |  31.69 ns | 0.3746 |  10.73 KB |
| NewRequest_InvokeAsync                          | 15,545.8 ns |  43.08 ns |  28.49 ns | 0.4345 |  11.98 KB |
| RefreshingCredentials_InvokeAsync               | 16,576.9 ns | 247.42 ns | 129.41 ns | 0.3960 |  12.27 KB |
