```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.13 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error     | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |------------:|----------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,121.5 ns |   2.58 ns |  1.71 ns | 0.0627 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    865.9 ns |   0.59 ns |  0.35 ns | 0.0622 |   1.75 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |    939.8 ns |   2.89 ns |  1.91 ns | 0.0632 |   1.82 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,334.6 ns |   3.11 ns |  2.06 ns | 0.0657 |   2.04 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,399.0 ns |  10.73 ns |  5.61 ns | 0.0767 |   2.18 KB |
| Telemetry_InvokeSync                            | 17,896.0 ns |  76.43 ns | 39.97 ns | 0.5000 |  14.89 KB |
| Telemetry_InvokeAsync                           | 20,674.2 ns |  51.24 ns | 30.49 ns | 0.5779 |  16.15 KB |
| NewRequest_InvokeSync                           | 13,459.8 ns |  29.89 ns | 15.64 ns | 0.3768 |  10.73 KB |
| NewRequest_InvokeAsync                          | 15,771.5 ns |  41.54 ns | 24.72 ns | 0.3784 |  11.98 KB |
| RefreshingCredentials_InvokeAsync               | 17,011.6 ns | 121.11 ns | 80.10 ns | 0.4067 |  12.27 KB |
