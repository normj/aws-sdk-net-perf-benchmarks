```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.75 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |-----------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost                     | 6,286.4 ns | 426.95 ns | 282.40 ns | 0.1464 |   4.18 KB |
| Sign_RestJsonPathResources        | 6,772.4 ns | 107.14 ns |  70.87 ns | 0.1667 |   5.29 KB |
| CanonicalizeResourcePath_RestJson |   741.6 ns |  20.39 ns |  12.13 ns | 0.0435 |   1.27 KB |
| Sign_JsonPostPooledBody           | 7,067.3 ns | 303.26 ns | 180.46 ns | 0.1998 |   6.12 KB |
| ContentStreamHash_PooledJson      |   718.5 ns |   8.63 ns |   5.14 ns | 0.0410 |    1.2 KB |
