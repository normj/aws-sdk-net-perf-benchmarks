```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.84 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|---------:|---------:|-------:|----------:|
| Sign_JsonPost                     | 5,906.7 ns | 19.74 ns | 10.33 ns | 0.1422 |   4.18 KB |
| Sign_RestJsonPathResources        | 6,579.2 ns | 44.81 ns | 26.67 ns | 0.1818 |   5.29 KB |
| CanonicalizeResourcePath_RestJson |   690.4 ns | 15.81 ns | 10.46 ns | 0.0454 |   1.27 KB |
| Sign_JsonPostPooledBody           | 6,586.6 ns | 33.52 ns | 19.95 ns | 0.2111 |   6.12 KB |
| ContentStreamHash_PooledJson      |   674.1 ns |  7.49 ns |  4.95 ns | 0.0430 |    1.2 KB |
