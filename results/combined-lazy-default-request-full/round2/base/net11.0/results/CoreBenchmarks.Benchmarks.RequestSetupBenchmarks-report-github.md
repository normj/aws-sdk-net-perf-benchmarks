```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.11 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |------------:|---------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,158.3 ns | 40.10 ns | 26.52 ns | 0.0666 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    866.8 ns | 21.94 ns | 13.06 ns | 0.0601 |   1.75 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |    899.8 ns | 13.22 ns |  7.86 ns | 0.0648 |   1.82 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,423.3 ns | 13.88 ns |  7.26 ns | 0.0668 |   2.04 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,447.5 ns | 26.23 ns | 17.35 ns | 0.0785 |   2.18 KB |
| Telemetry_InvokeSync                            | 17,824.4 ns | 41.56 ns | 24.73 ns | 0.4972 |  14.89 KB |
| Telemetry_InvokeAsync                           | 20,564.9 ns | 61.66 ns | 40.78 ns | 0.5810 |  16.15 KB |
| NewRequest_InvokeSync                           | 13,449.9 ns | 39.09 ns | 20.44 ns | 0.3775 |  10.73 KB |
| NewRequest_InvokeAsync                          | 15,896.2 ns | 61.92 ns | 32.38 ns | 0.3819 |  11.98 KB |
| RefreshingCredentials_InvokeAsync               | 17,196.1 ns | 59.13 ns | 35.19 ns | 0.4121 |  12.27 KB |
