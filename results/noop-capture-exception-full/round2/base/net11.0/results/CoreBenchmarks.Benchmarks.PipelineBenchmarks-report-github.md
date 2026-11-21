```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.83 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error     | StdDev   | Gen0   | Allocated |
|---------------------------------- |----------:|----------:|---------:|-------:|----------:|
| InvokeSync_JsonPost               |  12.23 μs |  0.072 μs | 0.047 μs | 0.3439 |  10.51 KB |
| InvokeAsync_JsonPost              |  13.96 μs |  0.063 μs | 0.042 μs | 0.3899 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding     |  18.83 μs |  0.182 μs | 0.108 μs | 0.3792 |   11.9 KB |
| InvokeSync_ServiceError           |  50.31 μs |  0.185 μs | 0.110 μs | 1.6077 |  44.53 KB |
| InvokeAsync_ServiceError_Yielding | 253.12 μs | 17.115 μs | 8.951 μs | 3.0242 |  108.8 KB |
