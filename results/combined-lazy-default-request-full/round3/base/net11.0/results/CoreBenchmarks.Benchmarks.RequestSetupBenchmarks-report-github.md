```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.53 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |------------:|---------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,192.9 ns | 17.79 ns | 11.77 ns | 0.0664 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    959.8 ns |  9.08 ns |  5.40 ns | 0.0618 |   1.75 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |  1,008.2 ns | 10.33 ns |  6.83 ns | 0.0645 |   1.82 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,430.5 ns |  6.47 ns |  4.28 ns | 0.0682 |   2.04 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,520.3 ns |  7.45 ns |  4.93 ns | 0.0703 |   2.18 KB |
| Telemetry_InvokeSync                            | 18,547.6 ns | 45.86 ns | 30.33 ns | 0.5202 |  14.89 KB |
| Telemetry_InvokeAsync                           | 21,148.7 ns | 32.27 ns | 19.20 ns | 0.5081 |  16.15 KB |
| NewRequest_InvokeSync                           | 14,206.1 ns | 72.23 ns | 42.98 ns | 0.3400 |  10.73 KB |
| NewRequest_InvokeAsync                          | 16,461.7 ns | 59.66 ns | 35.50 ns | 0.3956 |  11.98 KB |
| RefreshingCredentials_InvokeAsync               | 17,551.5 ns | 56.04 ns | 33.35 ns | 0.4213 |  12.27 KB |
