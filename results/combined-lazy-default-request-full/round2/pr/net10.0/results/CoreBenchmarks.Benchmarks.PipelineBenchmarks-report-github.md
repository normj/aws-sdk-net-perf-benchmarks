```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.6 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|----------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.85 μs |  0.058 μs |  0.035 μs | 0.3607 |  10.05 KB |
| InvokeAsync_JsonPost                              |  15.01 μs |  0.137 μs |  0.090 μs | 0.3585 |  11.32 KB |
| InvokeAsync_JsonPost_Yielding                     |  21.40 μs |  2.584 μs |  1.709 μs | 0.4134 |  12.59 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.61 μs |  0.070 μs |  0.036 μs | 0.4123 |  11.73 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  26.34 μs |  1.709 μs |  1.131 μs | 0.4984 |  14.27 KB |
| InvokeSync_ServiceError                           |  57.49 μs |  0.176 μs |  0.104 μs | 1.5909 |   43.9 KB |
| InvokeAsync_ServiceError_Yielding                 | 267.91 μs | 36.380 μs | 24.063 μs | 2.9762 | 108.03 KB |
| EndpointRules_InvokeSync_JsonPost                 |  13.43 μs |  0.098 μs |  0.058 μs | 0.3743 |  10.55 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  23.62 μs |  2.460 μs |  1.627 μs | 0.4358 |  13.08 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  13.75 μs |  0.080 μs |  0.047 μs | 0.3872 |  10.72 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  23.81 μs |  1.152 μs |  0.685 μs | 0.4800 |  13.25 KB |
