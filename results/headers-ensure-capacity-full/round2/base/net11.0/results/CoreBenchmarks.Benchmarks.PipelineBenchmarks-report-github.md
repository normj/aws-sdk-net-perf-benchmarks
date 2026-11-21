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
| InvokeSync_JsonPost                               |  11.93 μs | 0.089 μs | 0.053 μs | 0.3368 |  10.51 KB |
| InvokeAsync_JsonPost                              |  14.05 μs | 0.064 μs | 0.038 μs | 0.3927 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  19.42 μs | 0.722 μs | 0.478 μs | 0.3839 |  11.92 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  13.37 μs | 0.177 μs | 0.105 μs | 0.4241 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  21.30 μs | 0.517 μs | 0.308 μs | 0.4212 |   13.7 KB |
| InvokeSync_ServiceError                           |  50.96 μs | 0.244 μs | 0.161 μs | 1.4251 |   44.3 KB |
| InvokeAsync_ServiceError_Yielding                 | 227.50 μs | 4.069 μs | 2.128 μs | 3.5714 | 108.57 KB |
