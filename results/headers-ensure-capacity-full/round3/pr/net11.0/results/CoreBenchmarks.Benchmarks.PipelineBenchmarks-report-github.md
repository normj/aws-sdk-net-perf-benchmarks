```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.92 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.40 μs | 0.058 μs | 0.034 μs | 0.3467 |   10.1 KB |
| InvokeAsync_JsonPost                              |  14.44 μs | 0.153 μs | 0.101 μs | 0.4021 |  11.36 KB |
| InvokeAsync_JsonPost_Yielding                     |  19.49 μs | 0.107 μs | 0.056 μs | 0.3844 |  11.52 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.00 μs | 0.113 μs | 0.067 μs | 0.3906 |  11.78 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  22.13 μs | 1.028 μs | 0.680 μs | 0.4310 |  13.29 KB |
| InvokeSync_ServiceError                           |  51.95 μs | 0.514 μs | 0.340 μs | 1.4632 |  43.83 KB |
| InvokeAsync_ServiceError_Yielding                 | 233.07 μs | 7.261 μs | 4.321 μs | 3.0242 | 108.08 KB |
