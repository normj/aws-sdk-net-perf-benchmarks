```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.83 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean      | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |----------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1.282 μs | 0.0023 μs | 0.0013 μs | 0.0617 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |  1.004 μs | 0.0199 μs | 0.0118 μs | 0.0607 |   1.76 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |  1.030 μs | 0.0014 μs | 0.0007 μs | 0.0623 |   1.83 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2.482 μs | 0.0080 μs | 0.0048 μs | 0.0695 |   2.05 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2.512 μs | 0.0074 μs | 0.0044 μs | 0.0705 |   2.19 KB |
| Telemetry_InvokeSync                            | 18.829 μs | 0.0655 μs | 0.0343 μs | 0.5271 |  14.89 KB |
| Telemetry_InvokeAsync                           | 21.810 μs | 0.0986 μs | 0.0652 μs | 0.5230 |  16.23 KB |
| NewRequest_InvokeSync                           | 14.357 μs | 0.0837 μs | 0.0438 μs | 0.3434 |  10.73 KB |
| NewRequest_InvokeAsync                          | 16.921 μs | 0.0446 μs | 0.0233 μs | 0.4063 |  12.06 KB |
| RefreshingCredentials_InvokeAsync               | 18.092 μs | 0.0736 μs | 0.0438 μs | 0.4340 |  12.35 KB |
