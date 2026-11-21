```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.54 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|----------:|-------:|----------:|
| InvokeSync_JsonPost                               |  16.35 μs |  2.532 μs |  1.675 μs | 0.3453 |  10.51 KB |
| InvokeAsync_JsonPost                              |  20.75 μs |  3.460 μs |  2.288 μs | 0.3597 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  33.49 μs | 13.500 μs |  8.929 μs | 0.3726 |  12.74 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.74 μs |  0.163 μs |  0.108 μs | 0.4074 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  24.13 μs |  1.464 μs |  0.968 μs | 0.4830 |  13.73 KB |
| InvokeSync_ServiceError                           |  53.71 μs |  1.087 μs |  0.719 μs | 1.5191 |  44.31 KB |
| InvokeAsync_ServiceError_Yielding                 | 256.90 μs | 15.719 μs | 10.397 μs | 3.8462 | 108.58 KB |
