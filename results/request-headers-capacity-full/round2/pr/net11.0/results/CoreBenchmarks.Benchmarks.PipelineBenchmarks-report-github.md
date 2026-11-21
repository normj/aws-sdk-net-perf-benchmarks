```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.84 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.01 μs | 0.078 μs | 0.046 μs | 0.3399 |  10.13 KB |
| InvokeAsync_JsonPost                              |  14.10 μs | 0.063 μs | 0.037 μs | 0.3938 |  11.39 KB |
| InvokeAsync_JsonPost_Yielding                     |  21.97 μs | 2.933 μs | 1.940 μs | 0.3511 |   11.7 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  13.56 μs | 0.063 μs | 0.042 μs | 0.3814 |  11.81 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  21.91 μs | 0.075 μs | 0.044 μs | 0.4395 |  13.58 KB |
| InvokeSync_ServiceError                           |  50.69 μs | 0.684 μs | 0.358 μs | 1.3787 |  43.87 KB |
| InvokeAsync_ServiceError_Yielding                 | 220.62 μs | 2.957 μs | 1.546 μs | 3.5211 | 108.15 KB |
