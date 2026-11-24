```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |------------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,106.0 ns |   7.25 ns |   4.80 ns | 0.0622 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    867.3 ns |   3.02 ns |   2.00 ns | 0.0626 |   1.75 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |    905.3 ns |   2.56 ns |   1.70 ns | 0.0654 |   1.82 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,422.5 ns |  12.31 ns |   6.44 ns | 0.0675 |   2.04 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,455.2 ns |  19.70 ns |  13.03 ns | 0.0787 |   2.18 KB |
| Telemetry_InvokeSync                            | 17,860.1 ns | 101.48 ns |  60.39 ns | 0.4989 |  14.89 KB |
| Telemetry_InvokeAsync                           | 20,508.5 ns |  94.22 ns |  56.07 ns | 0.5734 |  16.15 KB |
| NewRequest_InvokeSync                           | 13,669.5 ns | 199.33 ns | 118.62 ns | 0.3788 |  10.73 KB |
| NewRequest_InvokeAsync                          | 15,943.5 ns | 195.40 ns | 129.25 ns | 0.3842 |  11.98 KB |
| RefreshingCredentials_InvokeAsync               | 16,829.4 ns |  75.06 ns |  49.64 ns | 0.4045 |  12.27 KB |
