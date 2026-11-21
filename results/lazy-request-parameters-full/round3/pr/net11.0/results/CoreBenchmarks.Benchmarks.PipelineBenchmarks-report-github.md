```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.74 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost               |  12.15 μs | 0.091 μs | 0.060 μs | 0.3410 |  10.29 KB |
| InvokeAsync_JsonPost              |  13.95 μs | 0.095 μs | 0.056 μs | 0.3934 |  11.55 KB |
| InvokeAsync_JsonPost_Yielding     |  19.70 μs | 0.528 μs | 0.349 μs | 0.4269 |  11.76 KB |
| InvokeSync_ServiceError           |  50.82 μs | 0.305 μs | 0.182 μs | 1.4159 |  44.02 KB |
| InvokeAsync_ServiceError_Yielding | 222.39 μs | 2.439 μs | 1.451 μs | 3.5714 | 108.34 KB |
