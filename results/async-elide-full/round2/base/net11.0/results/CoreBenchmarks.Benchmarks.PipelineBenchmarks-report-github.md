```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.45 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                        | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------ |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost           | 12.47 μs | 0.091 μs | 0.054 μs | 0.3503 |  10.51 KB |
| InvokeAsync_JsonPost          | 14.52 μs | 0.083 μs | 0.043 μs | 0.4036 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding | 19.84 μs | 1.157 μs | 0.765 μs | 0.3844 |  11.91 KB |
