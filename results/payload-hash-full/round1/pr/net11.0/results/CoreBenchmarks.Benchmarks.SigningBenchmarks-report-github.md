```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.32 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error       | StdDev    | Gen0   | Allocated |
|---------------------------------- |-----------:|------------:|----------:|-------:|----------:|
| Sign_JsonPost                     | 7,947.1 ns | 1,372.25 ns | 907.66 ns | 0.1353 |   4.18 KB |
| Sign_RestJsonPathResources        | 6,700.2 ns |   315.21 ns | 187.58 ns | 0.1629 |   5.29 KB |
| CanonicalizeResourcePath_RestJson |   672.1 ns |     8.89 ns |   4.65 ns | 0.0445 |   1.27 KB |
| Sign_JsonPostPooledBody           | 6,620.0 ns |    84.83 ns |  44.37 ns | 0.2128 |   6.12 KB |
| ContentStreamHash_PooledJson      |   700.6 ns |    13.31 ns |   7.92 ns | 0.0408 |    1.2 KB |
