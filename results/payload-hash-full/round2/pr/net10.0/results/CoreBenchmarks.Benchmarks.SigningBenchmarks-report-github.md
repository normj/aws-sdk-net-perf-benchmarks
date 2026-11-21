```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.89 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |-----------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost                     | 6,000.6 ns |  43.21 ns |  28.58 ns | 0.1435 |   4.18 KB |
| Sign_RestJsonPathResources        | 6,753.2 ns | 177.54 ns | 117.43 ns | 0.1862 |   5.29 KB |
| CanonicalizeResourcePath_RestJson |   718.1 ns |  20.56 ns |  13.60 ns | 0.0448 |   1.27 KB |
| Sign_JsonPostPooledBody           | 6,916.5 ns |  33.05 ns |  21.86 ns | 0.2196 |   6.12 KB |
| ContentStreamHash_PooledJson      |   728.6 ns |   8.56 ns |   5.09 ns | 0.0408 |    1.2 KB |
