```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.93 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |------------:|---------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,044.6 ns |  2.95 ns |  1.95 ns | 0.0502 |   1.44 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    791.5 ns |  1.03 ns |  0.54 ns | 0.0474 |   1.35 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |    836.8 ns |  1.47 ns |  0.87 ns | 0.0502 |   1.42 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,290.2 ns |  6.23 ns |  3.26 ns | 0.0554 |   1.64 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,354.7 ns |  8.01 ns |  4.76 ns | 0.0564 |   1.78 KB |
| Telemetry_InvokeSync                            | 17,013.1 ns | 69.19 ns | 45.76 ns | 0.4761 |  14.44 KB |
| Telemetry_InvokeAsync                           | 19,953.7 ns | 29.38 ns | 17.48 ns | 0.5580 |   15.7 KB |
| NewRequest_InvokeSync                           | 12,928.6 ns | 48.30 ns | 31.95 ns | 0.3625 |  10.27 KB |
| NewRequest_InvokeAsync                          | 15,591.0 ns | 93.10 ns | 61.58 ns | 0.3739 |  11.53 KB |
| RefreshingCredentials_InvokeAsync               | 16,467.3 ns | 88.80 ns | 58.74 ns | 0.3943 |  11.82 KB |
