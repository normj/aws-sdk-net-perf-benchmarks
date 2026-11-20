```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.25 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                        | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------ |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost           | 14.82 μs | 3.206 μs | 2.121 μs | 0.3739 |  10.51 KB |
| InvokeAsync_JsonPost          | 15.80 μs | 0.773 μs | 0.460 μs | 0.3724 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding | 24.26 μs | 2.426 μs | 1.444 μs | 0.4484 |  13.04 KB |
