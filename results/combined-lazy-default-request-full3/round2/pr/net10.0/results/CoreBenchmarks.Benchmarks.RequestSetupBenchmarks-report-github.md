```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.12 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error     | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |------------:|----------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,212.6 ns |  17.55 ns | 11.61 ns | 0.0481 |   1.44 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    944.4 ns |   8.01 ns |  5.30 ns | 0.0489 |   1.36 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |    967.5 ns |   8.84 ns |  5.26 ns | 0.0498 |   1.43 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,453.7 ns |   8.37 ns |  5.54 ns | 0.0587 |   1.65 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,484.2 ns |  15.51 ns | 10.26 ns | 0.0591 |   1.79 KB |
| Telemetry_InvokeSync                            | 18,652.4 ns |  39.19 ns | 25.92 ns | 0.5221 |  14.44 KB |
| Telemetry_InvokeAsync                           | 21,349.4 ns | 114.79 ns | 60.04 ns | 0.5137 |  15.77 KB |
| NewRequest_InvokeSync                           | 14,263.9 ns |  43.42 ns | 25.84 ns | 0.3415 |  10.27 KB |
| NewRequest_InvokeAsync                          | 16,763.5 ns |  99.21 ns | 65.62 ns | 0.4002 |  11.61 KB |
| RefreshingCredentials_InvokeAsync               | 17,757.4 ns | 127.61 ns | 84.40 ns | 0.4233 |   11.9 KB |
