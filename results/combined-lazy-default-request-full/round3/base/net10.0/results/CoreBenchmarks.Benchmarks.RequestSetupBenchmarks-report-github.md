```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.56 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean      | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |----------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1.363 μs | 0.0046 μs | 0.0027 μs | 0.0655 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |  1.089 μs | 0.0105 μs | 0.0063 μs | 0.0606 |   1.76 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |  1.150 μs | 0.0035 μs | 0.0021 μs | 0.0644 |   1.83 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2.604 μs | 0.0072 μs | 0.0048 μs | 0.0728 |   2.05 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2.641 μs | 0.0152 μs | 0.0091 μs | 0.0742 |   2.19 KB |
| Telemetry_InvokeSync                            | 19.192 μs | 0.1438 μs | 0.0752 μs | 0.5388 |  14.89 KB |
| Telemetry_InvokeAsync                           | 21.576 μs | 0.1161 μs | 0.0607 μs | 0.5144 |  16.23 KB |
| NewRequest_InvokeSync                           | 14.350 μs | 0.1083 μs | 0.0716 μs | 0.3412 |  10.73 KB |
| NewRequest_InvokeAsync                          | 17.327 μs | 0.3834 μs | 0.2536 μs | 0.4067 |  12.06 KB |
| RefreshingCredentials_InvokeAsync               | 18.528 μs | 0.0685 μs | 0.0453 μs | 0.4422 |  12.35 KB |
