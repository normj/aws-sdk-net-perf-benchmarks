```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.94 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error     | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.84 μs |  0.208 μs | 0.109 μs | 0.3566 |  10.51 KB |
| InvokeAsync_JsonPost                              |  14.90 μs |  0.153 μs | 0.091 μs | 0.4171 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  20.64 μs |  1.128 μs | 0.671 μs | 0.4027 |  11.95 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.54 μs |  0.204 μs | 0.135 μs | 0.4085 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  22.38 μs |  0.623 μs | 0.412 μs | 0.4509 |  13.76 KB |
| InvokeSync_ServiceError                           |  53.59 μs |  0.838 μs | 0.438 μs | 1.4881 |   44.3 KB |
| InvokeAsync_ServiceError_Yielding                 | 239.31 μs | 11.617 μs | 6.913 μs | 3.8462 | 108.58 KB |
