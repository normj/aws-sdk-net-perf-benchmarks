```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.06 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.91 μs | 0.077 μs | 0.051 μs | 0.3324 |  10.51 KB |
| InvokeAsync_JsonPost                              |  16.15 μs | 0.111 μs | 0.058 μs | 0.3878 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  24.86 μs | 2.634 μs | 1.742 μs | 0.4355 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  15.72 μs | 0.095 μs | 0.056 μs | 0.4406 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  28.67 μs | 1.380 μs | 0.913 μs | 0.4554 |  14.72 KB |
| InvokeSync_ServiceError                           |  62.92 μs | 0.611 μs | 0.404 μs | 1.5060 |  48.34 KB |
| InvokeAsync_ServiceError_Yielding                 | 263.00 μs | 2.492 μs | 1.649 μs | 3.1250 | 108.47 KB |
