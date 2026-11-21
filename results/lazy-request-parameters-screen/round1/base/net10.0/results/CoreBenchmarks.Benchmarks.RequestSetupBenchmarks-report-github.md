```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.15 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                          | Mean      | Error      | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |----------:|-----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1.440 μs |  0.0415 μs | 0.0148 μs | 0.0631 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |  1.040 μs |  0.0539 μs | 0.0140 μs | 0.0629 |   1.76 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |  1.098 μs |  0.0350 μs | 0.0125 μs | 0.0632 |   1.83 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2.885 μs |  0.3983 μs | 0.1034 μs | 0.0720 |   2.05 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2.954 μs |  0.3141 μs | 0.1120 μs | 0.0688 |   2.19 KB |
| Telemetry_InvokeSync                            | 25.135 μs | 13.2929 μs | 4.7404 μs | 0.4371 |  14.89 KB |
| Telemetry_InvokeAsync                           | 23.856 μs |  2.1544 μs | 0.7683 μs | 0.5547 |  16.23 KB |
