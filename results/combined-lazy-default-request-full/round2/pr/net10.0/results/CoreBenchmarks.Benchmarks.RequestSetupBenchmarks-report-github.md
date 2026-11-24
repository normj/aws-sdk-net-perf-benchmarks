```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.6 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error     | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |------------:|----------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,249.2 ns |   3.00 ns |  1.78 ns | 0.0500 |   1.44 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    943.6 ns |  11.24 ns |  7.43 ns | 0.0486 |   1.36 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |    968.9 ns |   1.33 ns |  0.79 ns | 0.0504 |   1.43 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,510.0 ns |  15.17 ns |  9.03 ns | 0.0502 |   1.65 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,443.8 ns |   5.60 ns |  3.70 ns | 0.0586 |   1.79 KB |
| Telemetry_InvokeSync                            | 18,455.5 ns | 107.07 ns | 70.82 ns | 0.5153 |  14.44 KB |
| Telemetry_InvokeAsync                           | 21,260.6 ns | 146.69 ns | 87.29 ns | 0.5081 |  15.77 KB |
| NewRequest_InvokeSync                           | 13,935.4 ns |  24.74 ns | 16.37 ns | 0.3339 |  10.27 KB |
| NewRequest_InvokeAsync                          | 16,331.8 ns |  67.48 ns | 44.64 ns | 0.3914 |  11.61 KB |
| RefreshingCredentials_InvokeAsync               | 17,646.2 ns |  88.66 ns | 58.65 ns | 0.4228 |   11.9 KB |
