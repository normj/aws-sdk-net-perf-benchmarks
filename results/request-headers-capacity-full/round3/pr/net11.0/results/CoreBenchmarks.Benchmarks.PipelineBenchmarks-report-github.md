```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.71 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|----------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.02 μs |  0.062 μs |  0.041 μs | 0.3378 |  10.13 KB |
| InvokeAsync_JsonPost                              |  13.87 μs |  0.033 μs |  0.020 μs | 0.3910 |  11.39 KB |
| InvokeAsync_JsonPost_Yielding                     |  19.32 μs |  1.610 μs |  1.065 μs | 0.3981 |  11.55 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  13.64 μs |  0.045 μs |  0.024 μs | 0.3828 |  11.81 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  20.91 μs |  0.709 μs |  0.469 μs | 0.4401 |  13.31 KB |
| InvokeSync_ServiceError                           |  50.86 μs |  0.297 μs |  0.177 μs | 1.4159 |  43.87 KB |
| InvokeAsync_ServiceError_Yielding                 | 232.61 μs | 20.435 μs | 12.161 μs | 3.7879 | 108.17 KB |
