```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.44 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |-----------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost                     | 6,302.8 ns | 125.56 ns |  83.05 ns | 0.1482 |   4.29 KB |
| Sign_RestJsonPathResources        | 7,040.3 ns | 144.34 ns |  85.89 ns | 0.1915 |    5.4 KB |
| CanonicalizeResourcePath_RestJson |   706.8 ns |  25.36 ns |  16.77 ns | 0.0443 |   1.27 KB |
| Sign_JsonPostPooledBody           | 6,911.7 ns |  40.08 ns |  26.51 ns | 0.2227 |   6.17 KB |
| ContentStreamHash_PooledJson      | 1,437.2 ns | 172.10 ns | 113.83 ns | 0.0451 |   1.25 KB |
