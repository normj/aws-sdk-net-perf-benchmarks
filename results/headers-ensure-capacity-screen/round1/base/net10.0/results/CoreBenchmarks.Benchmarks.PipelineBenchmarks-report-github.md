```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.75 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  14.35 μs | 4.227 μs | 1.507 μs | 0.3765 |  10.51 KB |
| InvokeAsync_JsonPost                              |  15.35 μs | 0.287 μs | 0.102 μs | 0.4256 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  22.83 μs | 5.705 μs | 2.035 μs | 0.4713 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.98 μs | 0.146 μs | 0.038 μs | 0.4195 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  25.92 μs | 2.597 μs | 0.926 μs | 0.4945 |  14.72 KB |
| InvokeSync_ServiceError                           |  57.40 μs | 1.267 μs | 0.452 μs | 1.3889 |  44.31 KB |
| InvokeAsync_ServiceError_Yielding                 | 256.83 μs | 4.613 μs | 1.645 μs | 3.0242 | 108.46 KB |
