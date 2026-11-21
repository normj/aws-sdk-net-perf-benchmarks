```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.43 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  11.96 μs | 0.030 μs | 0.016 μs | 0.3347 |  10.51 KB |
| InvokeAsync_JsonPost                              |  14.30 μs | 0.079 μs | 0.047 μs | 0.4040 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  21.55 μs | 1.893 μs | 1.252 μs | 0.3602 |  11.91 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  13.52 μs | 0.176 μs | 0.105 μs | 0.4314 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  21.00 μs | 0.121 μs | 0.072 μs | 0.4257 |  13.66 KB |
| InvokeSync_ServiceError                           |  51.31 μs | 0.436 μs | 0.289 μs | 1.4297 |   44.3 KB |
| InvokeAsync_ServiceError_Yielding                 | 224.06 μs | 2.312 μs | 1.529 μs | 3.5714 | 108.57 KB |
