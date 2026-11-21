```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.91 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.55 μs | 0.110 μs | 0.072 μs | 0.3520 |  10.51 KB |
| InvokeAsync_JsonPost                              |  14.79 μs | 0.241 μs | 0.159 μs | 0.4183 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  20.39 μs | 0.332 μs | 0.219 μs | 0.4085 |  12.01 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.30 μs | 0.080 μs | 0.048 μs | 0.3988 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  23.06 μs | 1.351 μs | 0.893 μs | 0.4562 |  13.77 KB |
| InvokeSync_ServiceError                           |  52.21 μs | 0.486 μs | 0.289 μs | 1.4632 |   44.3 KB |
| InvokeAsync_ServiceError_Yielding                 | 231.03 μs | 1.635 μs | 0.973 μs | 3.6765 | 108.57 KB |
