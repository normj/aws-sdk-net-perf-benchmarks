```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.17 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error       | StdDev      | Gen0   | Allocated |
|------------------------------------------------ |------------:|------------:|------------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,052.0 ns |    16.80 ns |    10.00 ns | 0.0479 |   1.44 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    925.4 ns |   300.07 ns |   198.48 ns | 0.0483 |   1.35 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |    851.0 ns |     2.16 ns |     1.29 ns | 0.0511 |   1.42 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,268.4 ns |    10.35 ns |     6.85 ns | 0.0543 |   1.64 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,277.9 ns |    21.79 ns |    12.97 ns | 0.0634 |   1.78 KB |
| Telemetry_InvokeSync                            | 17,113.8 ns |    55.20 ns |    32.85 ns | 0.4776 |  14.44 KB |
| Telemetry_InvokeAsync                           | 21,606.2 ns | 4,433.11 ns | 2,932.23 ns | 0.5517 |   15.7 KB |
| NewRequest_InvokeSync                           | 13,043.9 ns |    56.98 ns |    33.91 ns | 0.3649 |  10.27 KB |
| NewRequest_InvokeAsync                          | 15,134.7 ns |    30.06 ns |    15.72 ns | 0.3637 |  11.53 KB |
| RefreshingCredentials_InvokeAsync               | 17,628.2 ns | 3,057.99 ns | 2,022.67 ns | 0.3910 |  11.82 KB |
