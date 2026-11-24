```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.15 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean      | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |----------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1.315 μs | 0.0176 μs | 0.0105 μs | 0.0623 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |  1.000 μs | 0.0058 μs | 0.0039 μs | 0.0601 |   1.76 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |  1.130 μs | 0.2310 μs | 0.1375 μs | 0.0627 |   1.83 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2.505 μs | 0.0057 μs | 0.0037 μs | 0.0702 |   2.05 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2.570 μs | 0.0145 μs | 0.0096 μs | 0.0715 |   2.19 KB |
| Telemetry_InvokeSync                            | 18.637 μs | 0.0627 μs | 0.0373 μs | 0.4800 |  14.89 KB |
| Telemetry_InvokeAsync                           | 21.764 μs | 0.0519 μs | 0.0343 μs | 0.5216 |  16.23 KB |
| NewRequest_InvokeSync                           | 14.678 μs | 0.0597 μs | 0.0355 μs | 0.3511 |  10.73 KB |
| NewRequest_InvokeAsync                          | 17.197 μs | 0.3681 μs | 0.2190 μs | 0.4089 |  12.06 KB |
| RefreshingCredentials_InvokeAsync               | 18.104 μs | 0.0501 μs | 0.0332 μs | 0.4325 |  12.35 KB |
