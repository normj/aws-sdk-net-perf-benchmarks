```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.91 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|---------:|---------:|-------:|----------:|
| Sign_JsonPost                     | 6,041.8 ns | 13.70 ns |  7.17 ns | 0.1450 |    4392 B |
| Sign_S3GetWithQuery               | 5,679.6 ns | 27.00 ns | 16.06 ns | 0.1583 |    4616 B |
| Presign_S3GetObject               | 6,393.8 ns | 49.94 ns | 29.72 ns | 0.2291 |    6672 B |
| Sign_RestJsonPathResources        | 6,215.4 ns | 39.79 ns | 23.68 ns | 0.1495 |    4600 B |
| Sign_S3GetObjectKey               | 4,927.3 ns | 46.90 ns | 31.02 ns | 0.1181 |    3528 B |
| CanonicalizeResourcePath_RestJson |   340.6 ns |  8.32 ns |  5.50 ns | 0.0127 |     376 B |
| CanonicalizeResourcePath_S3Key    |   311.4 ns |  3.00 ns |  1.98 ns | 0.0062 |     200 B |
