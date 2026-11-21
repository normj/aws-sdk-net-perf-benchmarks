```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.48 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                          | Mean      | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |----------:|----------:|----------:|-------:|----------:|
| AuthResolver_PreInvokeAsync_ExplicitCredentials |  1.036 μs | 0.0137 μs | 0.0036 μs | 0.0639 |   1.83 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2.501 μs | 0.0307 μs | 0.0109 μs | 0.0703 |   2.19 KB |
| Telemetry_InvokeAsync                           | 20.657 μs | 0.2268 μs | 0.0809 μs | 0.5849 |  16.23 KB |
| NewRequest_InvokeAsync                          | 16.790 μs | 0.3498 μs | 0.0908 μs | 0.4019 |  12.06 KB |
| RefreshingCredentials_InvokeAsync               | 18.973 μs | 0.9237 μs | 0.3294 μs | 0.4371 |  12.35 KB |
