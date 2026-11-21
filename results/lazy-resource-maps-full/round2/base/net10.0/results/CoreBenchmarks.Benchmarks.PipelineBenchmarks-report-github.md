```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.75 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|----------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.96 μs |  0.177 μs |  0.117 μs | 0.3369 |  10.51 KB |
| InvokeAsync_JsonPost                              |  17.06 μs |  1.205 μs |  0.717 μs | 0.3792 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  26.77 μs |  2.237 μs |  1.480 μs | 0.4522 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  15.63 μs |  0.378 μs |  0.225 μs | 0.4315 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  30.01 μs |  2.204 μs |  1.311 μs | 0.4488 |  14.72 KB |
| InvokeSync_ServiceError                           |  62.47 μs |  0.891 μs |  0.589 μs | 1.7430 |  48.34 KB |
| InvokeAsync_ServiceError_Yielding                 | 280.89 μs | 32.227 μs | 21.316 μs | 3.1250 | 108.47 KB |
