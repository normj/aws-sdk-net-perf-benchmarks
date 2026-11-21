```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.47 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.43 μs | 0.169 μs | 0.060 μs | 0.3478 |  10.51 KB |
| InvokeAsync_JsonPost                              |  14.73 μs | 0.220 μs | 0.078 μs | 0.4100 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  22.52 μs | 3.172 μs | 1.131 μs | 0.4134 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.38 μs | 0.102 μs | 0.036 μs | 0.4014 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  25.99 μs | 3.049 μs | 1.087 μs | 0.5073 |  14.72 KB |
| InvokeSync_ServiceError                           |  57.57 μs | 0.342 μs | 0.089 μs | 1.6144 |  46.32 KB |
| InvokeAsync_ServiceError_Yielding                 | 248.62 μs | 2.971 μs | 0.771 μs | 2.9762 | 108.45 KB |
