```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.95 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error     | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |------------:|----------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,315.5 ns |  14.65 ns |  7.66 ns | 0.0627 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    994.0 ns |   1.61 ns |  0.96 ns | 0.0637 |   1.76 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |  1,044.8 ns |   4.83 ns |  2.53 ns | 0.0630 |   1.83 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,454.0 ns |   6.97 ns |  4.61 ns | 0.0689 |   2.05 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,470.5 ns |   2.71 ns |  1.42 ns | 0.0791 |   2.19 KB |
| Telemetry_InvokeSync                            | 18,466.7 ns |  79.06 ns | 52.29 ns | 0.5165 |  14.89 KB |
| Telemetry_InvokeAsync                           | 21,543.8 ns | 156.81 ns | 82.01 ns | 0.5158 |  16.23 KB |
| NewRequest_InvokeSync                           | 14,239.2 ns |  87.51 ns | 52.07 ns | 0.3409 |  10.73 KB |
| NewRequest_InvokeAsync                          | 16,790.6 ns |  86.08 ns | 56.94 ns | 0.4019 |  12.06 KB |
| RefreshingCredentials_InvokeAsync               | 17,866.7 ns |  35.81 ns | 18.73 ns | 0.4291 |  12.35 KB |
