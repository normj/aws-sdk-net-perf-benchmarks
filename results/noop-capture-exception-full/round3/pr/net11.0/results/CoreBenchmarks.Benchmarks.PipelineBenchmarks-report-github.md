```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.16 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost               |  12.25 μs | 0.083 μs | 0.055 μs | 0.3418 |  10.51 KB |
| InvokeAsync_JsonPost              |  14.24 μs | 0.046 μs | 0.027 μs | 0.4006 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding     |  19.57 μs | 0.263 μs | 0.157 μs | 0.3887 |  11.96 KB |
| InvokeSync_ServiceError           |  34.21 μs | 0.097 μs | 0.057 μs | 0.4121 |  15.14 KB |
| InvokeAsync_ServiceError_Yielding | 100.35 μs | 0.604 μs | 0.360 μs | 1.6129 |  44.67 KB |
