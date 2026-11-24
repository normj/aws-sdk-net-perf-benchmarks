```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.57 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |------------:|---------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,182.9 ns |  3.55 ns |  1.86 ns | 0.0475 |   1.44 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    941.1 ns |  3.78 ns |  2.50 ns | 0.0454 |   1.35 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |  1,033.1 ns |  4.52 ns |  2.99 ns | 0.0496 |   1.42 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,467.0 ns |  6.83 ns |  4.06 ns | 0.0592 |   1.64 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,530.1 ns |  9.83 ns |  6.50 ns | 0.0604 |   1.78 KB |
| Telemetry_InvokeSync                            | 19,014.4 ns | 50.80 ns | 30.23 ns | 0.4562 |  14.44 KB |
| Telemetry_InvokeAsync                           | 21,840.0 ns | 82.99 ns | 54.89 ns | 0.5245 |   15.7 KB |
| NewRequest_InvokeSync                           | 14,085.7 ns | 70.29 ns | 41.83 ns | 0.3378 |  10.27 KB |
| NewRequest_InvokeAsync                          | 16,749.7 ns | 47.81 ns | 31.63 ns | 0.4011 |  11.53 KB |
| RefreshingCredentials_InvokeAsync               | 17,847.0 ns | 58.35 ns | 38.59 ns | 0.4286 |  11.82 KB |
