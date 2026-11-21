```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.42GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.87 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.23 μs | 0.080 μs | 0.048 μs | 0.3461 |   10.1 KB |
| InvokeAsync_JsonPost                              |  14.49 μs | 0.117 μs | 0.070 μs | 0.3981 |  11.36 KB |
| InvokeAsync_JsonPost_Yielding                     |  19.44 μs | 0.527 μs | 0.314 μs | 0.4145 |  11.51 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  13.92 μs | 0.087 μs | 0.052 μs | 0.3906 |  11.78 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  22.40 μs | 1.243 μs | 0.822 μs | 0.4293 |  13.26 KB |
| InvokeSync_ServiceError                           |  52.29 μs | 0.384 μs | 0.254 μs | 1.4583 |  43.83 KB |
| InvokeAsync_ServiceError_Yielding                 | 225.90 μs | 1.263 μs | 0.836 μs | 3.7313 | 108.09 KB |
