```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.82 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.98 μs | 0.155 μs | 0.040 μs | 0.3634 |  10.51 KB |
| InvokeAsync_JsonPost                              |  15.40 μs | 0.291 μs | 0.076 μs | 0.3680 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  21.26 μs | 3.129 μs | 1.116 μs | 0.4275 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.94 μs | 0.197 μs | 0.070 μs | 0.4167 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  24.76 μs | 3.295 μs | 1.175 μs | 0.4984 |  14.72 KB |
| InvokeSync_ServiceError                           |  56.41 μs | 0.259 μs | 0.067 μs | 1.5794 |  44.32 KB |
| InvokeAsync_ServiceError_Yielding                 | 251.45 μs | 4.069 μs | 1.451 μs | 3.6058 | 108.49 KB |
