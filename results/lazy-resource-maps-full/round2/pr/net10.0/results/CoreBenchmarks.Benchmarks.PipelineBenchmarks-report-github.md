```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.97 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.41 μs | 0.084 μs | 0.050 μs | 0.3208 |  10.27 KB |
| InvokeAsync_JsonPost                              |  15.60 μs | 0.256 μs | 0.170 μs | 0.3724 |  11.54 KB |
| InvokeAsync_JsonPost_Yielding                     |  25.25 μs | 1.184 μs | 0.783 μs | 0.4477 |   12.8 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  15.25 μs | 0.193 μs | 0.127 μs | 0.4277 |  11.95 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  28.27 μs | 2.116 μs | 1.399 μs | 0.4325 |  14.48 KB |
| InvokeSync_ServiceError                           |  58.92 μs | 0.532 μs | 0.316 μs | 1.4045 |     44 KB |
| InvokeAsync_ServiceError_Yielding                 | 260.75 μs | 3.892 μs | 2.316 μs | 3.1250 | 108.21 KB |
