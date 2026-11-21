```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.01 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.64 μs | 0.131 μs | 0.087 μs | 0.3574 |  10.27 KB |
| InvokeAsync_JsonPost                              |  14.69 μs | 0.102 μs | 0.067 μs | 0.4120 |  11.53 KB |
| InvokeAsync_JsonPost_Yielding                     |  20.90 μs | 1.271 μs | 0.841 μs | 0.4080 |   11.8 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.37 μs | 0.161 μs | 0.107 μs | 0.3992 |  11.95 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  22.74 μs | 0.590 μs | 0.351 μs | 0.4616 |  13.67 KB |
| InvokeSync_ServiceError                           |  53.68 μs | 0.523 μs | 0.311 μs | 1.5086 |     44 KB |
| InvokeAsync_ServiceError_Yielding                 | 237.16 μs | 1.899 μs | 1.256 μs | 3.9063 | 108.34 KB |
