```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.45 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean      | Error     | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.27 μs |  0.209 μs | 0.054 μs | 0.3759 |  10.51 KB |
| InvokeAsync_JsonPost                              |  15.28 μs |  0.136 μs | 0.035 μs | 0.3724 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  22.82 μs |  6.782 μs | 2.419 μs | 0.4408 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  15.08 μs |  0.195 μs | 0.070 μs | 0.4227 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  27.53 μs |  6.039 μs | 2.154 μs | 0.4401 |  14.72 KB |
| InvokeSync_ServiceError                           |  58.25 μs |  1.762 μs | 0.628 μs | 1.3889 |  44.31 KB |
| InvokeAsync_ServiceError_Yielding                 | 258.74 μs | 20.224 μs | 7.212 μs | 3.5377 | 108.49 KB |
