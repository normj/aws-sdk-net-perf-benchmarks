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
| InvokeSync_JsonPost                               |  12.90 μs | 0.162 μs | 0.042 μs | 0.3640 |   10.1 KB |
| InvokeAsync_JsonPost                              |  15.14 μs | 0.162 μs | 0.042 μs | 0.3659 |  11.37 KB |
| InvokeAsync_JsonPost_Yielding                     |  21.55 μs | 1.483 μs | 0.529 μs | 0.4006 |  12.63 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.82 μs | 0.162 μs | 0.058 μs | 0.4155 |  11.78 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  24.50 μs | 4.559 μs | 1.626 μs | 0.4244 |  14.31 KB |
| InvokeSync_ServiceError                           |  56.93 μs | 1.605 μs | 0.572 μs | 1.5851 |  43.83 KB |
| InvokeAsync_ServiceError_Yielding                 | 247.77 μs | 5.663 μs | 2.019 μs | 2.9762 | 108.04 KB |
