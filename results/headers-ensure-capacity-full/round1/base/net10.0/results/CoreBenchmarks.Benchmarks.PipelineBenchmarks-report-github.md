```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.55 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.01 μs | 0.128 μs | 0.085 μs | 0.3649 |  10.51 KB |
| InvokeAsync_JsonPost                              |  15.25 μs | 0.224 μs | 0.117 μs | 0.3698 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  21.06 μs | 1.610 μs | 0.958 μs | 0.4433 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.95 μs | 0.124 μs | 0.074 μs | 0.4167 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  24.65 μs | 1.820 μs | 1.204 μs | 0.4984 |  14.72 KB |
| InvokeSync_ServiceError                           |  57.54 μs | 0.895 μs | 0.592 μs | 1.6026 |  44.31 KB |
| InvokeAsync_ServiceError_Yielding                 | 306.34 μs | 1.333 μs | 0.793 μs | 3.5377 | 108.49 KB |
