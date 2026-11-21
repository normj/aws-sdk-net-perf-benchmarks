```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.24 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.02 μs | 0.037 μs | 0.019 μs | 0.3649 |  10.51 KB |
| InvokeAsync_JsonPost                              |  15.38 μs | 0.073 μs | 0.043 μs | 0.3691 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  21.57 μs | 1.545 μs | 0.808 μs | 0.4496 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.79 μs | 0.083 μs | 0.055 μs | 0.4108 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  24.44 μs | 1.243 μs | 0.650 μs | 0.4945 |  14.72 KB |
| InvokeSync_ServiceError                           |  57.29 μs | 0.894 μs | 0.592 μs | 1.5851 |  44.32 KB |
| InvokeAsync_ServiceError_Yielding                 | 249.39 μs | 2.293 μs | 1.517 μs | 2.9762 | 108.46 KB |
