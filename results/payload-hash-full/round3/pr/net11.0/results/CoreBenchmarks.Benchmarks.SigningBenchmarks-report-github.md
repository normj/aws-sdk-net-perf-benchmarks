```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.65 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |-----------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost                     | 6,194.2 ns | 218.59 ns | 144.58 ns | 0.1459 |   4.18 KB |
| Sign_RestJsonPathResources        | 6,782.2 ns |  71.89 ns |  47.55 ns | 0.1883 |   5.29 KB |
| CanonicalizeResourcePath_RestJson |   936.5 ns | 305.27 ns | 201.92 ns | 0.0438 |   1.27 KB |
| Sign_JsonPostPooledBody           | 6,667.0 ns | 150.55 ns |  78.74 ns | 0.1911 |   6.12 KB |
| ContentStreamHash_PooledJson      |   675.8 ns |   2.84 ns |   1.69 ns | 0.0432 |    1.2 KB |
