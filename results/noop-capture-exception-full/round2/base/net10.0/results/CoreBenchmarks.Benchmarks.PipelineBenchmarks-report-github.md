```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.84 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost               |  13.44 μs | 0.130 μs | 0.086 μs | 0.3755 |  10.51 KB |
| InvokeAsync_JsonPost              |  15.40 μs | 0.171 μs | 0.113 μs | 0.3684 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding     |  22.41 μs | 2.107 μs | 1.394 μs | 0.4037 |  13.04 KB |
| InvokeSync_ServiceError           |  57.81 μs | 0.697 μs | 0.461 μs | 1.3889 |  44.53 KB |
| InvokeAsync_ServiceError_Yielding | 250.24 μs | 1.584 μs | 0.943 μs | 3.9063 | 108.74 KB |
