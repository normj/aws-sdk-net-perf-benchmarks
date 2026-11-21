```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.66 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                          | Mean      | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |----------:|----------:|----------:|-------:|----------:|
| AuthResolver_PreInvokeAsync_ExplicitCredentials |  1.128 μs | 0.1362 μs | 0.0486 μs | 0.0637 |   1.83 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2.677 μs | 0.1600 μs | 0.0571 μs | 0.0726 |   2.19 KB |
| Telemetry_InvokeAsync                           | 20.781 μs | 0.9519 μs | 0.3395 μs | 0.5726 |  16.09 KB |
| NewRequest_InvokeAsync                          | 16.941 μs | 0.9178 μs | 0.3273 μs | 0.4032 |  11.92 KB |
| RefreshingCredentials_InvokeAsync               | 20.377 μs | 4.2386 μs | 1.1008 μs | 0.3830 |  12.21 KB |
