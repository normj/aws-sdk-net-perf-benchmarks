```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.79 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost               |  12.24 μs | 0.080 μs | 0.048 μs | 0.3426 |  10.29 KB |
| InvokeAsync_JsonPost              |  13.80 μs | 0.117 μs | 0.078 μs | 0.3851 |  11.55 KB |
| InvokeAsync_JsonPost_Yielding     |  18.95 μs | 0.607 μs | 0.401 μs | 0.3747 |   11.7 KB |
| InvokeSync_ServiceError           |  53.50 μs | 0.308 μs | 0.183 μs | 1.7007 |  48.05 KB |
| InvokeAsync_ServiceError_Yielding | 221.96 μs | 1.483 μs | 0.883 μs | 3.5714 | 108.34 KB |
