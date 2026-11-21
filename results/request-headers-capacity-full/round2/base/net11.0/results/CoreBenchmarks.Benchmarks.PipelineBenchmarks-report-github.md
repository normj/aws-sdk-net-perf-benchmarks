```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.24 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.13 μs | 0.082 μs | 0.054 μs | 0.3405 |  10.51 KB |
| InvokeAsync_JsonPost                              |  14.09 μs | 0.082 μs | 0.049 μs | 0.3963 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  18.83 μs | 0.106 μs | 0.063 μs | 0.3747 |  11.92 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  13.85 μs | 0.037 μs | 0.019 μs | 0.3896 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  21.47 μs | 1.029 μs | 0.681 μs | 0.4246 |  13.69 KB |
| InvokeSync_ServiceError                           |  52.51 μs | 0.405 μs | 0.268 μs | 1.4881 |  44.31 KB |
| InvokeAsync_ServiceError_Yielding                 | 226.80 μs | 1.860 μs | 0.973 μs | 3.6232 | 108.57 KB |
