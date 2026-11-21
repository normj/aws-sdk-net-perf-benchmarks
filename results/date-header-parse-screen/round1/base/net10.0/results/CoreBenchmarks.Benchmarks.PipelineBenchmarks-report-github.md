```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.4 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.09 μs | 0.187 μs | 0.049 μs | 0.3658 |  10.51 KB |
| InvokeAsync_JsonPost                              |  15.34 μs | 0.207 μs | 0.074 μs | 0.3706 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  22.13 μs | 4.312 μs | 1.538 μs | 0.4334 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.98 μs | 0.403 μs | 0.144 μs | 0.4268 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  26.24 μs | 5.985 μs | 2.134 μs | 0.4587 |  14.72 KB |
| InvokeSync_ServiceError                           |  57.40 μs | 0.733 μs | 0.190 μs | 1.3787 |  44.31 KB |
| InvokeAsync_ServiceError_Yielding                 | 252.09 μs | 1.681 μs | 0.436 μs | 2.9762 | 108.46 KB |
