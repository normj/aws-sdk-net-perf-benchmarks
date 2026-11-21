```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.98 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.28 μs | 0.106 μs | 0.027 μs | 0.3739 |  10.51 KB |
| InvokeAsync_JsonPost                              |  15.34 μs | 0.219 μs | 0.078 μs | 0.3684 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  22.04 μs | 3.600 μs | 1.284 μs | 0.4529 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.93 μs | 0.115 μs | 0.030 μs | 0.4203 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  24.67 μs | 4.651 μs | 1.208 μs | 0.5106 |  14.72 KB |
| InvokeSync_ServiceError                           |  57.14 μs | 0.884 μs | 0.230 μs | 1.5967 |  44.32 KB |
| InvokeAsync_ServiceError_Yielding                 | 249.50 μs | 1.559 μs | 0.405 μs | 2.9762 | 108.58 KB |
