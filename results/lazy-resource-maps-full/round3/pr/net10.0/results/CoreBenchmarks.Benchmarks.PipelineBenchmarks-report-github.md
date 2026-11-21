```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.54 μs | 0.135 μs | 0.089 μs | 0.3250 |  10.27 KB |
| InvokeAsync_JsonPost                              |  15.95 μs | 0.112 μs | 0.066 μs | 0.3811 |  11.54 KB |
| InvokeAsync_JsonPost_Yielding                     |  23.73 μs | 2.599 μs | 1.719 μs | 0.4562 |   12.8 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  15.33 μs | 0.076 μs | 0.050 μs | 0.4310 |  11.95 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  28.28 μs | 1.101 μs | 0.655 μs | 0.4699 |  14.48 KB |
| InvokeSync_ServiceError                           |  59.05 μs | 0.373 μs | 0.222 μs | 1.4098 |     44 KB |
| InvokeAsync_ServiceError_Yielding                 | 258.79 μs | 2.569 μs | 1.529 μs | 3.0738 |  108.2 KB |
