```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.87 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|---------:|---------:|-------:|----------:|
| Sign_JsonPost                     | 6,047.5 ns | 25.57 ns | 15.22 ns | 0.1459 |   4.29 KB |
| Sign_RestJsonPathResources        | 6,684.5 ns | 19.80 ns | 11.79 ns | 0.1867 |    5.4 KB |
| CanonicalizeResourcePath_RestJson |   665.3 ns |  2.70 ns |  1.61 ns | 0.0451 |   1.27 KB |
| Sign_JsonPostPooledBody           | 6,781.1 ns | 43.61 ns | 28.85 ns | 0.2170 |   6.17 KB |
| ContentStreamHash_PooledJson      |   866.8 ns |  4.52 ns |  2.69 ns | 0.0450 |   1.25 KB |
