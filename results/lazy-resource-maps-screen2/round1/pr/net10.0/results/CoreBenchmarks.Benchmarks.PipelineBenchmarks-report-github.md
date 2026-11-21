```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.02 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean      | Error     | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.87 μs |  0.130 μs | 0.046 μs | 0.3640 |  10.27 KB |
| InvokeAsync_JsonPost                              |  15.62 μs |  0.899 μs | 0.320 μs | 0.3702 |  11.54 KB |
| InvokeAsync_JsonPost_Yielding                     |  23.55 μs |  1.702 μs | 0.442 μs | 0.4145 |   12.8 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.70 μs |  0.116 μs | 0.030 μs | 0.4116 |  11.95 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  26.21 μs |  2.645 μs | 0.943 μs | 0.5174 |  14.48 KB |
| InvokeSync_ServiceError                           |  57.05 μs |  0.771 μs | 0.275 μs | 1.5909 |     44 KB |
| InvokeAsync_ServiceError_Yielding                 | 254.60 μs | 14.736 μs | 3.827 μs | 3.0242 |  108.2 KB |
