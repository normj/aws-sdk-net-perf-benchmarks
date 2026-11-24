```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.28 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean      | Error      | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |----------:|-----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1.380 μs |  0.1143 μs | 0.0756 μs | 0.0615 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |  1.019 μs |  0.0297 μs | 0.0196 μs | 0.0602 |   1.76 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |  1.068 μs |  0.0145 μs | 0.0086 μs | 0.0630 |   1.83 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2.565 μs |  0.0802 μs | 0.0530 μs | 0.0637 |   2.05 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2.569 μs |  0.0323 μs | 0.0192 μs | 0.0712 |   2.19 KB |
| Telemetry_InvokeSync                            | 18.998 μs |  0.1830 μs | 0.1210 μs | 0.5355 |  14.89 KB |
| Telemetry_InvokeAsync                           | 22.449 μs |  0.2056 μs | 0.1360 μs | 0.5350 |  16.23 KB |
| NewRequest_InvokeSync                           | 22.698 μs |  2.7078 μs | 1.7910 μs | 0.3555 |  10.73 KB |
| NewRequest_InvokeAsync                          | 26.694 μs |  2.4171 μs | 1.5987 μs | 0.3301 |  12.06 KB |
| RefreshingCredentials_InvokeAsync               | 25.498 μs | 13.0852 μs | 7.7868 μs | 0.3825 |  12.35 KB |
