```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.8 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|----------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.16 μs |  0.257 μs |  0.153 μs | 0.3680 |  10.51 KB |
| InvokeAsync_JsonPost                              |  15.43 μs |  0.214 μs |  0.127 μs | 0.4268 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  23.65 μs |  3.302 μs |  2.184 μs | 0.4032 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  15.16 μs |  0.366 μs |  0.242 μs | 0.4199 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  26.42 μs |  1.608 μs |  1.064 μs | 0.5040 |  14.72 KB |
| InvokeSync_ServiceError                           |  58.75 μs |  0.625 μs |  0.372 μs | 1.3993 |  44.31 KB |
| InvokeAsync_ServiceError_Yielding                 | 287.50 μs | 23.700 μs | 15.676 μs | 3.2328 | 108.47 KB |
