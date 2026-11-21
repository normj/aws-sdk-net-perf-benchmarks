```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.13 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |-----------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost                     | 6,216.1 ns |  67.17 ns |  39.97 ns | 0.1479 |   4.29 KB |
| Sign_RestJsonPathResources        | 6,820.0 ns |  72.96 ns |  38.16 ns | 0.1895 |    5.4 KB |
| CanonicalizeResourcePath_RestJson |   743.7 ns |  17.71 ns |  11.71 ns | 0.0443 |   1.27 KB |
| Sign_JsonPostPooledBody           | 7,146.9 ns | 118.40 ns |  78.32 ns | 0.1965 |   6.17 KB |
| ContentStreamHash_PooledJson      | 1,348.9 ns | 292.67 ns | 193.58 ns | 0.0438 |   1.25 KB |
