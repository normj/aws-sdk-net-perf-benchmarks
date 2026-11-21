```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.44 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |----------:|----------:|----------:|-------:|----------:|
| InvokeSync_JsonPost               |  12.32 μs |  0.157 μs |  0.104 μs | 0.3431 |  10.29 KB |
| InvokeAsync_JsonPost              |  14.21 μs |  0.072 μs |  0.048 μs | 0.3974 |  11.55 KB |
| InvokeAsync_JsonPost_Yielding     |  18.99 μs |  0.138 μs |  0.091 μs | 0.3788 |   11.7 KB |
| InvokeSync_ServiceError           |  65.31 μs | 10.335 μs |  6.836 μs | 1.5560 |  48.05 KB |
| InvokeAsync_ServiceError_Yielding | 283.84 μs | 24.023 μs | 15.890 μs | 3.2328 | 108.29 KB |
