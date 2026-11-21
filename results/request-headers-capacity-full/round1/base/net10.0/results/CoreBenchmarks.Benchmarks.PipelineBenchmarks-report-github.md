```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.22 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.10 μs | 0.074 μs | 0.049 μs | 0.3717 |  10.51 KB |
| InvokeAsync_JsonPost                              |  15.13 μs | 0.105 μs | 0.063 μs | 0.4219 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  22.97 μs | 3.077 μs | 2.035 μs | 0.4134 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.87 μs | 0.055 μs | 0.029 μs | 0.4171 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  25.75 μs | 1.855 μs | 1.227 μs | 0.4906 |  14.72 KB |
| InvokeSync_ServiceError                           |  56.69 μs | 0.275 μs | 0.182 μs | 1.5794 |  44.32 KB |
| InvokeAsync_ServiceError_Yielding                 | 253.77 μs | 3.640 μs | 2.166 μs | 3.6058 | 108.49 KB |
