```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.95 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error     | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |------------:|----------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,170.6 ns |   1.48 ns |  0.77 ns | 0.0516 |   1.44 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    918.6 ns |   1.04 ns |  0.54 ns | 0.0477 |   1.36 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |    945.7 ns |   2.01 ns |  1.20 ns | 0.0468 |   1.43 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,393.7 ns |  26.24 ns | 17.35 ns | 0.0575 |   1.65 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,412.2 ns |  24.15 ns | 15.97 ns | 0.0574 |   1.79 KB |
| Telemetry_InvokeSync                            | 18,764.7 ns | 110.02 ns | 65.47 ns | 0.4491 |  14.44 KB |
| Telemetry_InvokeAsync                           | 21,801.7 ns |  86.14 ns | 51.26 ns | 0.5216 |  15.77 KB |
| NewRequest_InvokeSync                           | 14,288.1 ns |  61.08 ns | 36.35 ns | 0.3428 |  10.27 KB |
| NewRequest_InvokeAsync                          | 16,857.7 ns |  20.57 ns | 13.61 ns | 0.4063 |  11.61 KB |
| RefreshingCredentials_InvokeAsync               | 17,979.8 ns |  63.38 ns | 37.72 ns | 0.4305 |   11.9 KB |
