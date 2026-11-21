```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.56 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.22 μs | 0.137 μs | 0.090 μs | 0.3413 |  10.51 KB |
| InvokeAsync_JsonPost                              |  14.01 μs | 0.092 μs | 0.055 μs | 0.3913 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  18.77 μs | 0.422 μs | 0.251 μs | 0.3738 |  11.91 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  13.75 μs | 0.071 μs | 0.047 μs | 0.3889 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  20.61 μs | 0.229 μs | 0.120 μs | 0.4569 |  13.66 KB |
| InvokeSync_ServiceError                           |  50.81 μs | 0.311 μs | 0.206 μs | 1.4297 |   44.3 KB |
| InvokeAsync_ServiceError_Yielding                 | 225.98 μs | 1.618 μs | 1.070 μs | 3.6232 | 108.57 KB |
