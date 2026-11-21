```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.92 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|---------:|---------:|-------:|----------:|
| Sign_JsonPost                     | 5,999.9 ns | 58.10 ns | 34.58 ns | 0.1433 |   4.29 KB |
| Sign_RestJsonPathResources        | 6,629.0 ns | 43.34 ns | 25.79 ns | 0.1850 |    5.4 KB |
| CanonicalizeResourcePath_RestJson |   690.9 ns |  4.48 ns |  2.96 ns | 0.0446 |   1.27 KB |
| Sign_JsonPostPooledBody           | 6,894.1 ns | 51.30 ns | 33.93 ns | 0.2194 |   6.17 KB |
| ContentStreamHash_PooledJson      |   892.0 ns | 14.69 ns |  9.72 ns | 0.0425 |   1.25 KB |
