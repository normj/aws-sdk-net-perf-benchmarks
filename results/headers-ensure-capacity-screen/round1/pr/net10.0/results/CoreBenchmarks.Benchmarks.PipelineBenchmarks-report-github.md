```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.79 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.25 μs | 0.127 μs | 0.033 μs | 0.3197 |   10.1 KB |
| InvokeAsync_JsonPost                              |  15.61 μs | 0.332 μs | 0.118 μs | 0.3706 |  11.37 KB |
| InvokeAsync_JsonPost_Yielding                     |  20.92 μs | 2.417 μs | 0.628 μs | 0.4542 |  12.63 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  15.19 μs | 0.099 μs | 0.026 μs | 0.4248 |  11.78 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  25.14 μs | 4.188 μs | 1.494 μs | 0.4650 |  14.31 KB |
| InvokeSync_ServiceError                           |  57.61 μs | 0.756 μs | 0.270 μs | 1.3787 |  43.83 KB |
| InvokeAsync_ServiceError_Yielding                 | 254.03 μs | 2.218 μs | 0.576 μs | 3.0242 | 108.05 KB |
