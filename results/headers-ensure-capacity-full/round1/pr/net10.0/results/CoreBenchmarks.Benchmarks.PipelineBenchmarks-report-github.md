```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.49 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|----------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.18 μs |  0.077 μs |  0.046 μs | 0.3275 |   10.1 KB |
| InvokeAsync_JsonPost                              |  15.54 μs |  0.157 μs |  0.093 μs | 0.3739 |  11.37 KB |
| InvokeAsync_JsonPost_Yielding                     |  24.72 μs |  3.383 μs |  2.237 μs | 0.4013 |  12.63 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  15.32 μs |  0.627 μs |  0.415 μs | 0.4195 |  11.78 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  31.73 μs |  4.305 μs |  2.847 μs | 0.4094 |  14.31 KB |
| InvokeSync_ServiceError                           |  59.03 μs |  1.977 μs |  1.307 μs | 1.4098 |  43.83 KB |
| InvokeAsync_ServiceError_Yielding                 | 288.22 μs | 21.935 μs | 13.053 μs | 3.5377 | 108.08 KB |
