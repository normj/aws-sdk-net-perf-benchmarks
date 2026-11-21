```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.3 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                       | Mean       | Error     | StdDev   | Gen0   | Allocated |
|----------------------------- |-----------:|----------:|---------:|-------:|----------:|
| Sign_JsonPostPooledBody      | 6,578.0 ns | 197.71 ns | 51.34 ns | 0.2124 |   6.12 KB |
| ContentStreamHash_PooledJson |   696.5 ns |  11.22 ns |  4.00 ns | 0.0415 |    1.2 KB |
