```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.18 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.07 μs | 0.028 μs | 0.017 μs | 0.3405 |  10.13 KB |
| InvokeAsync_JsonPost                              |  13.77 μs | 0.059 μs | 0.039 μs | 0.3848 |  11.39 KB |
| InvokeAsync_JsonPost_Yielding                     |  20.62 μs | 2.577 μs | 1.704 μs | 0.3806 |  11.59 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  13.44 μs | 0.057 μs | 0.038 μs | 0.3765 |  11.81 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  21.36 μs | 1.351 μs | 0.894 μs | 0.4112 |  13.43 KB |
| InvokeSync_ServiceError                           |  50.25 μs | 0.242 μs | 0.160 μs | 1.4159 |  43.87 KB |
| InvokeAsync_ServiceError_Yielding                 | 225.59 μs | 5.861 μs | 3.065 μs | 3.5714 | 108.15 KB |
