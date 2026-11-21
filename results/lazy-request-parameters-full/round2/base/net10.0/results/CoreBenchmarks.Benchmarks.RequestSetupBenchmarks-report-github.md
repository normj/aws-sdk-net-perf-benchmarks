```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.43 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |------------:|---------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,277.0 ns |  2.89 ns |  1.91 ns | 0.0663 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    994.0 ns | 13.20 ns |  8.73 ns | 0.0601 |   1.76 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |  1,097.9 ns | 11.30 ns |  6.73 ns | 0.0647 |   1.83 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,512.9 ns | 14.05 ns |  8.36 ns | 0.0698 |   2.05 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,618.8 ns |  7.88 ns |  4.69 ns | 0.0732 |   2.19 KB |
| Telemetry_InvokeSync                            | 19,018.8 ns | 77.07 ns | 45.86 ns | 0.5309 |  14.89 KB |
| Telemetry_InvokeAsync                           | 21,919.9 ns | 94.18 ns | 49.26 ns | 0.5259 |  16.23 KB |
