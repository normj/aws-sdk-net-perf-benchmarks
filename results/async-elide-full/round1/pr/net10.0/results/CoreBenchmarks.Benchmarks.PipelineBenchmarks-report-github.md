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
| Method                        | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------ |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost           | 13.28 μs | 0.083 μs | 0.049 μs | 0.3765 |  10.51 KB |
| InvokeAsync_JsonPost          | 15.46 μs | 0.272 μs | 0.142 μs | 0.3676 |  11.49 KB |
| InvokeAsync_JsonPost_Yielding | 23.17 μs | 2.499 μs | 1.653 μs | 0.4281 |  12.54 KB |
