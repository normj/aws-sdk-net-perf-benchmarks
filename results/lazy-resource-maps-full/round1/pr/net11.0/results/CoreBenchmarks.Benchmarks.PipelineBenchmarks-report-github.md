```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.62 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|----------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.44 μs |  0.264 μs |  0.157 μs | 0.3227 |  10.27 KB |
| InvokeAsync_JsonPost                              |  20.46 μs |  3.423 μs |  2.037 μs | 0.4159 |  11.53 KB |
| InvokeAsync_JsonPost_Yielding                     |  28.91 μs |  9.710 μs |  6.422 μs | 0.2934 |  11.75 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.52 μs |  0.160 μs |  0.095 μs | 0.4058 |  11.95 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  22.79 μs |  0.738 μs |  0.386 μs | 0.4793 |  13.57 KB |
| InvokeSync_ServiceError                           |  57.48 μs |  1.127 μs |  0.746 μs | 1.6085 |  48.04 KB |
| InvokeAsync_ServiceError_Yielding                 | 248.24 μs | 19.503 μs | 12.900 μs | 3.8462 | 108.34 KB |
