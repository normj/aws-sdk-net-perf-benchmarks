```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.39 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean      | Error     | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.28 μs |  0.115 μs | 0.041 μs | 0.3453 |  10.51 KB |
| InvokeAsync_JsonPost                              |  14.38 μs |  0.098 μs | 0.026 μs | 0.4010 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  20.93 μs |  3.369 μs | 0.875 μs | 0.4596 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.36 μs |  0.653 μs | 0.233 μs | 0.3927 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  24.29 μs |  6.185 μs | 2.205 μs | 0.5073 |  14.72 KB |
| InvokeSync_ServiceError                           |  57.98 μs |  2.305 μs | 0.822 μs | 1.6509 |  46.32 KB |
| InvokeAsync_ServiceError_Yielding                 | 248.90 μs | 11.342 μs | 4.045 μs | 2.9762 | 108.41 KB |
