```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.5 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|---------:|---------:|-------:|----------:|
| Sign_JsonPost                     | 6,027.5 ns | 37.64 ns | 22.40 ns | 0.1451 |   4.29 KB |
| Sign_S3GetWithQuery               | 5,570.2 ns | 21.34 ns | 12.70 ns | 0.1550 |   4.51 KB |
| Presign_S3GetObject               | 6,499.8 ns | 62.04 ns | 41.04 ns | 0.2352 |   7.16 KB |
| Sign_RestJsonPathResources        | 6,707.9 ns | 26.98 ns | 17.85 ns | 0.1887 |    5.4 KB |
| Sign_S3GetObjectKey               | 5,386.5 ns | 23.15 ns | 13.78 ns | 0.1514 |   4.44 KB |
| CanonicalizeResourcePath_RestJson |   687.6 ns |  3.74 ns |  2.47 ns | 0.0440 |   1.27 KB |
| CanonicalizeResourcePath_S3Key    |   585.6 ns |  2.88 ns |  1.90 ns | 0.0420 |   1.19 KB |
