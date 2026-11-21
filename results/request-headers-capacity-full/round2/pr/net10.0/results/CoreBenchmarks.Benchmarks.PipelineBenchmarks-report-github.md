```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.23 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|----------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.83 μs |  0.117 μs |  0.077 μs | 0.3557 |  10.13 KB |
| InvokeAsync_JsonPost                              |  14.88 μs |  0.087 μs |  0.052 μs | 0.3571 |   11.4 KB |
| InvokeAsync_JsonPost_Yielding                     |  21.32 μs |  1.846 μs |  1.098 μs | 0.4439 |  12.66 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.57 μs |  0.052 μs |  0.027 μs | 0.4081 |  11.81 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  25.02 μs |  3.249 μs |  1.699 μs | 0.4230 |  14.34 KB |
| InvokeSync_ServiceError                           |  56.83 μs |  1.310 μs |  0.685 μs | 1.5737 |  43.87 KB |
| InvokeAsync_ServiceError_Yielding                 | 254.04 μs | 16.981 μs | 10.105 μs | 2.9762 | 108.04 KB |
