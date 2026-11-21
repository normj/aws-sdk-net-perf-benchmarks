```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.42GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.77 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error     | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|----------:|---------:|-------:|----------:|
| Sign_JsonPost                     | 6,162.9 ns |  83.98 ns | 43.92 ns | 0.1486 |   4.29 KB |
| Sign_RestJsonPathResources        | 6,871.9 ns |  67.40 ns | 40.11 ns | 0.1929 |    5.4 KB |
| CanonicalizeResourcePath_RestJson |   713.6 ns |   6.10 ns |  3.63 ns | 0.0458 |   1.27 KB |
| Sign_JsonPostPooledBody           | 7,050.6 ns | 116.31 ns | 69.22 ns | 0.2231 |   6.17 KB |
| ContentStreamHash_PooledJson      |   967.5 ns |  69.30 ns | 41.24 ns | 0.0437 |   1.25 KB |
