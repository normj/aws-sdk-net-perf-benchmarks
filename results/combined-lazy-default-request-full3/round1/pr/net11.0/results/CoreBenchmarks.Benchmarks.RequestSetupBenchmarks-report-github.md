```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.82 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |------------:|---------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,054.2 ns |  3.61 ns |  1.89 ns | 0.0506 |   1.44 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    799.8 ns |  4.99 ns |  2.61 ns | 0.0473 |   1.35 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |    907.0 ns |  2.22 ns |  1.32 ns | 0.0507 |   1.42 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,263.1 ns |  7.39 ns |  4.40 ns | 0.0544 |   1.64 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,374.0 ns | 12.83 ns |  7.63 ns | 0.0569 |   1.78 KB |
| Telemetry_InvokeSync                            | 17,356.6 ns | 52.45 ns | 31.21 ns | 0.4850 |  14.44 KB |
| Telemetry_InvokeAsync                           | 20,094.7 ns | 56.94 ns | 33.88 ns | 0.5689 |   15.7 KB |
| NewRequest_InvokeSync                           | 13,105.4 ns | 27.43 ns | 16.32 ns | 0.3658 |  10.27 KB |
| NewRequest_InvokeAsync                          | 15,439.1 ns | 42.86 ns | 22.42 ns | 0.3706 |  11.53 KB |
| RefreshingCredentials_InvokeAsync               | 16,421.7 ns | 38.37 ns | 22.83 ns | 0.3939 |  11.82 KB |
