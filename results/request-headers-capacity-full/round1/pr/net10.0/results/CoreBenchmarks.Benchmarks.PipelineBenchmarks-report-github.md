```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.42 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|----------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.04 μs |  0.099 μs |  0.065 μs | 0.3643 |  10.13 KB |
| InvokeAsync_JsonPost                              |  15.33 μs |  0.074 μs |  0.049 μs | 0.3673 |   11.4 KB |
| InvokeAsync_JsonPost_Yielding                     |  22.05 μs |  1.995 μs |  1.320 μs | 0.4275 |  12.66 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.78 μs |  0.180 μs |  0.119 μs | 0.4096 |  11.81 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  25.49 μs |  1.929 μs |  1.276 μs | 0.5115 |  14.34 KB |
| InvokeSync_ServiceError                           |  60.14 μs |  0.496 μs |  0.328 μs | 1.6698 |   47.9 KB |
| InvokeAsync_ServiceError_Yielding                 | 264.60 μs | 33.436 μs | 22.116 μs | 2.9762 | 108.04 KB |
