```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.34 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error       | StdDev      | Gen0   | Allocated |
|---------------------------------- |-----------:|------------:|------------:|-------:|----------:|
| Sign_JsonPost                     | 6,025.4 ns |    20.40 ns |    12.14 ns | 0.1446 |   4.29 KB |
| Sign_S3GetWithQuery               | 5,328.7 ns |    31.42 ns |    18.70 ns | 0.1328 |   3.99 KB |
| Presign_S3GetObject               | 6,371.4 ns |    37.56 ns |    24.85 ns | 0.2299 |   6.82 KB |
| Sign_RestJsonPathResources        | 7,176.6 ns | 1,787.14 ns | 1,063.50 ns | 0.1864 |    5.4 KB |
| Sign_S3GetObjectKey               | 5,465.8 ns |    34.00 ns |    22.49 ns | 0.1538 |   4.44 KB |
| CanonicalizeResourcePath_RestJson |   738.5 ns |     3.44 ns |     1.80 ns | 0.0442 |   1.27 KB |
| CanonicalizeResourcePath_S3Key    |   670.8 ns |    11.69 ns |     7.73 ns | 0.0425 |   1.19 KB |
