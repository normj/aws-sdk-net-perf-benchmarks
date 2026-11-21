```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.2 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost               |  12.86 μs | 0.099 μs | 0.066 μs | 0.3613 |  10.51 KB |
| InvokeAsync_JsonPost              |  15.41 μs | 0.107 μs | 0.071 μs | 0.3676 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding     |  22.47 μs | 1.866 μs | 1.235 μs | 0.3834 |  13.04 KB |
| InvokeSync_ServiceError           |  39.35 μs | 0.155 μs | 0.092 μs | 0.4711 |  15.14 KB |
| InvokeAsync_ServiceError_Yielding | 122.86 μs | 2.023 μs | 1.058 μs | 1.4648 |   44.6 KB |
