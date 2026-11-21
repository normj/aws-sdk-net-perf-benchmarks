```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.87 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |------------:|---------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,119.2 ns |  8.47 ns |  5.60 ns | 0.0627 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    871.1 ns |  6.68 ns |  3.98 ns | 0.0615 |   1.75 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |    899.9 ns | 10.71 ns |  7.08 ns | 0.0652 |   1.82 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,350.8 ns |  9.29 ns |  4.86 ns | 0.0658 |   2.04 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,413.1 ns | 11.06 ns |  7.32 ns | 0.0773 |   2.18 KB |
| Telemetry_InvokeSync                            | 16,891.6 ns | 50.83 ns | 33.62 ns | 0.4730 |  14.89 KB |
| Telemetry_InvokeAsync                           | 19,472.7 ns | 67.59 ns | 44.71 ns | 0.5448 |  16.15 KB |
