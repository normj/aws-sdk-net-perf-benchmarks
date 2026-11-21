```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.51 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|----------:|-------:|----------:|
| InvokeSync_JsonPost                               |  14.53 μs |  0.537 μs |  0.355 μs | 0.3595 |  10.27 KB |
| InvokeAsync_JsonPost                              |  16.25 μs |  0.230 μs |  0.152 μs | 0.3882 |  11.54 KB |
| InvokeAsync_JsonPost_Yielding                     |  26.62 μs |  2.149 μs |  1.422 μs | 0.3956 |   12.8 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  16.35 μs |  0.309 μs |  0.204 μs | 0.3776 |  11.95 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  30.55 μs |  1.767 μs |  1.052 μs | 0.4488 |  14.48 KB |
| InvokeSync_ServiceError                           |  61.49 μs |  2.366 μs |  1.565 μs | 1.4205 |     44 KB |
| InvokeAsync_ServiceError_Yielding                 | 296.62 μs | 21.138 μs | 13.981 μs | 3.6058 | 108.24 KB |
