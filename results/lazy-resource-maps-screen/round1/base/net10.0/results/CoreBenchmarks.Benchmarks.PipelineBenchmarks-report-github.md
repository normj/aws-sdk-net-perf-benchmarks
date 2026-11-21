```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.94 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean      | Error     | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.34 μs |  0.568 μs | 0.203 μs | 0.3733 |  10.51 KB |
| InvokeAsync_JsonPost                              |  15.77 μs |  0.879 μs | 0.313 μs | 0.3698 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  25.55 μs |  1.930 μs | 0.688 μs | 0.4202 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  15.72 μs |  2.297 μs | 0.819 μs | 0.4306 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  29.93 μs |  1.832 μs | 0.653 μs | 0.4505 |  14.72 KB |
| InvokeSync_ServiceError                           |  57.79 μs |  0.806 μs | 0.287 μs | 1.3889 |  44.31 KB |
| InvokeAsync_ServiceError_Yielding                 | 273.77 μs | 13.067 μs | 3.393 μs | 3.2895 | 108.48 KB |
