```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.07 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.76 μs | 0.173 μs | 0.114 μs | 0.3554 |  10.27 KB |
| InvokeAsync_JsonPost                              |  14.48 μs | 0.134 μs | 0.089 μs | 0.4070 |  11.53 KB |
| InvokeAsync_JsonPost_Yielding                     |  20.72 μs | 0.451 μs | 0.298 μs | 0.4167 |  11.88 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.37 μs | 0.161 μs | 0.106 μs | 0.3995 |  11.95 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  22.01 μs | 0.243 μs | 0.145 μs | 0.4439 |   13.6 KB |
| InvokeSync_ServiceError                           |  55.98 μs | 0.853 μs | 0.564 μs | 1.5737 |  48.04 KB |
| InvokeAsync_ServiceError_Yielding                 | 232.48 μs | 4.934 μs | 2.581 μs | 3.6765 | 108.33 KB |
