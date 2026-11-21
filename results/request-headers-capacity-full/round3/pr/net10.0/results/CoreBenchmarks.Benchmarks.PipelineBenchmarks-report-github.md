```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.71 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.68 μs | 0.059 μs | 0.039 μs | 0.3560 |  10.13 KB |
| InvokeAsync_JsonPost                              |  14.77 μs | 0.069 μs | 0.041 μs | 0.4123 |   11.4 KB |
| InvokeAsync_JsonPost_Yielding                     |  20.42 μs | 1.584 μs | 0.829 μs | 0.4562 |  12.66 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.38 μs | 0.093 μs | 0.061 μs | 0.4003 |  11.81 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  24.89 μs | 2.002 μs | 1.324 μs | 0.4823 |  14.34 KB |
| InvokeSync_ServiceError                           |  55.99 μs | 0.250 μs | 0.149 μs | 1.5681 |  43.87 KB |
| InvokeAsync_ServiceError_Yielding                 | 253.53 μs | 5.519 μs | 3.650 μs | 2.9762 | 108.04 KB |
