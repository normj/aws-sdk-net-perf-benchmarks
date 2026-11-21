```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.22 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost               |  12.38 μs | 0.182 μs | 0.120 μs | 0.3461 |  10.51 KB |
| InvokeAsync_JsonPost              |  14.13 μs | 0.059 μs | 0.035 μs | 0.3945 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding     |  20.76 μs | 2.085 μs | 1.379 μs | 0.4128 |  11.95 KB |
| InvokeSync_ServiceError           |  51.15 μs | 0.492 μs | 0.257 μs | 1.4251 |  44.53 KB |
| InvokeAsync_ServiceError_Yielding | 224.68 μs | 2.392 μs | 1.423 μs | 3.5714 | 108.81 KB |
