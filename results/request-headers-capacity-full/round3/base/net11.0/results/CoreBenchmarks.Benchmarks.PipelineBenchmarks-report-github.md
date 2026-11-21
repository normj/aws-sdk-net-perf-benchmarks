```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.73 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.12 μs | 0.030 μs | 0.016 μs | 0.3413 |  10.51 KB |
| InvokeAsync_JsonPost                              |  14.18 μs | 0.038 μs | 0.020 μs | 0.4014 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  19.00 μs | 0.181 μs | 0.108 μs | 0.3844 |  11.91 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  13.64 μs | 0.046 μs | 0.028 μs | 0.4352 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  21.02 μs | 0.209 μs | 0.109 μs | 0.4195 |   13.7 KB |
| InvokeSync_ServiceError                           |  51.28 μs | 1.049 μs | 0.624 μs | 1.4205 |   44.3 KB |
| InvokeAsync_ServiceError_Yielding                 | 230.08 μs | 9.427 μs | 5.610 μs | 3.6232 | 108.57 KB |
