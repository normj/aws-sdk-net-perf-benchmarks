```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.64 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|----------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.20 μs |  0.813 μs |  0.211 μs | 0.3717 |  10.27 KB |
| InvokeAsync_JsonPost                              |  15.40 μs |  0.389 μs |  0.139 μs | 0.3655 |  11.54 KB |
| InvokeAsync_JsonPost_Yielding                     |  25.06 μs |  1.890 μs |  0.491 μs | 0.3823 |   12.8 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  22.29 μs |  4.580 μs |  1.189 μs | 0.4153 |  11.95 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  30.48 μs |  3.689 μs |  0.958 μs | 0.4744 |  14.48 KB |
| InvokeSync_ServiceError                           |  77.73 μs | 29.885 μs | 10.657 μs | 1.4269 |     44 KB |
| InvokeAsync_ServiceError_Yielding                 | 297.05 μs | 19.810 μs |  7.065 μs | 3.4722 | 108.23 KB |
