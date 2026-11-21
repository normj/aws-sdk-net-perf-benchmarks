```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.25 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.38 μs | 0.159 μs | 0.095 μs | 0.3765 |  10.51 KB |
| InvokeAsync_JsonPost                              |  15.39 μs | 0.235 μs | 0.156 μs | 0.3669 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  21.29 μs | 1.023 μs | 0.609 μs | 0.4723 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  15.22 μs | 0.131 μs | 0.087 μs | 0.4298 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  26.46 μs | 1.843 μs | 1.097 μs | 0.4992 |  14.72 KB |
| InvokeSync_ServiceError                           |  57.57 μs | 0.351 μs | 0.232 μs | 1.3889 |  44.31 KB |
| InvokeAsync_ServiceError_Yielding                 | 250.24 μs | 0.636 μs | 0.379 μs | 2.9762 | 108.46 KB |
