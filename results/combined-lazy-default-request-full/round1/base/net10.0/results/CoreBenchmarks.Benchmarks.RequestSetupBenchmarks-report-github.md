```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.82 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean      | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |----------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1.276 μs | 0.0115 μs | 0.0068 μs | 0.0661 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |  1.028 μs | 0.1448 μs | 0.0758 μs | 0.0608 |   1.76 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |  1.094 μs | 0.0542 μs | 0.0323 μs | 0.0644 |   1.83 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2.496 μs | 0.0661 μs | 0.0437 μs | 0.0696 |   2.05 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2.496 μs | 0.0237 μs | 0.0141 μs | 0.0742 |   2.19 KB |
| Telemetry_InvokeSync                            | 18.673 μs | 0.0907 μs | 0.0540 μs | 0.5375 |  14.89 KB |
| Telemetry_InvokeAsync                           | 21.663 μs | 0.0287 μs | 0.0190 μs | 0.5194 |  16.23 KB |
| NewRequest_InvokeSync                           | 14.402 μs | 0.0607 μs | 0.0401 μs | 0.3543 |  10.73 KB |
| NewRequest_InvokeAsync                          | 16.918 μs | 0.0777 μs | 0.0463 μs | 0.4050 |  12.06 KB |
| RefreshingCredentials_InvokeAsync               | 17.861 μs | 0.0229 μs | 0.0120 μs | 0.4296 |  12.35 KB |
