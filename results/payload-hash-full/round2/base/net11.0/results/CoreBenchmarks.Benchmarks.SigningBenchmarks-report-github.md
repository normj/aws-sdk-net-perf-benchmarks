```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.49GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.42 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |-----------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost                     | 6,191.0 ns | 185.16 ns | 122.47 ns | 0.1478 |   4.29 KB |
| Sign_RestJsonPathResources        | 6,787.8 ns |  70.68 ns |  42.06 ns | 0.1932 |    5.4 KB |
| CanonicalizeResourcePath_RestJson |   685.9 ns |  34.87 ns |  23.07 ns | 0.0459 |   1.27 KB |
| Sign_JsonPostPooledBody           | 7,205.2 ns |  93.29 ns |  55.52 ns | 0.2111 |   6.17 KB |
| ContentStreamHash_PooledJson      | 1,015.1 ns |  25.18 ns |  14.98 ns | 0.0433 |   1.25 KB |
