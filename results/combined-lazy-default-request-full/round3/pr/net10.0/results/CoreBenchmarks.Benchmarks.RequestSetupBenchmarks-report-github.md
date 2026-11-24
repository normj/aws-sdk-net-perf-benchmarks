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
| Marshaller_PreInvoke                            |  1.344 μs | 0.0117 μs | 0.0077 μs | 0.0479 |   1.44 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |  1.099 μs | 0.0107 μs | 0.0070 μs | 0.0477 |   1.36 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |  1.120 μs | 0.0037 μs | 0.0024 μs | 0.0489 |   1.43 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2.625 μs | 0.0121 μs | 0.0080 μs | 0.0521 |   1.65 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2.689 μs | 0.0049 μs | 0.0029 μs | 0.0644 |   1.79 KB |
| Telemetry_InvokeSync                            | 20.412 μs | 0.0646 μs | 0.0384 μs | 0.4889 |  14.44 KB |
| Telemetry_InvokeAsync                           | 23.757 μs | 0.1402 μs | 0.0834 μs | 0.5690 |  15.77 KB |
| NewRequest_InvokeSync                           | 15.486 μs | 0.0678 μs | 0.0449 μs | 0.3717 |  10.27 KB |
| NewRequest_InvokeAsync                          | 17.998 μs | 0.1097 μs | 0.0726 μs | 0.3600 |  11.61 KB |
| RefreshingCredentials_InvokeAsync               | 19.366 μs | 0.0540 μs | 0.0357 μs | 0.3863 |   11.9 KB |
