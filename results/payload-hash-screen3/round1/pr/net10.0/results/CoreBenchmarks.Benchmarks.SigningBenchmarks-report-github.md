```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.4 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                            | Mean       | Error     | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|----------:|---------:|-------:|----------:|
| Sign_JsonPost                     | 6,299.6 ns | 126.90 ns | 32.96 ns | 0.1494 |   4.18 KB |
| Sign_RestJsonPathResources        | 6,880.5 ns | 259.32 ns | 67.34 ns | 0.1895 |   5.29 KB |
| CanonicalizeResourcePath_RestJson |   820.6 ns |  24.31 ns |  8.67 ns | 0.0429 |   1.27 KB |
| Sign_JsonPostPooledBody           | 7,088.9 ns | 153.01 ns | 54.56 ns | 0.1966 |   6.12 KB |
| ContentStreamHash_PooledJson      |   740.3 ns |  21.39 ns |  5.55 ns | 0.0412 |    1.2 KB |
