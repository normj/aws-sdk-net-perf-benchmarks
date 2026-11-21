```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.48 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|---------:|---------:|-------:|----------:|
| Sign_JsonPost                     | 6,050.9 ns | 47.73 ns | 31.57 ns | 0.1452 |   4.29 KB |
| Sign_S3GetWithQuery               | 5,373.2 ns | 33.08 ns | 21.88 ns | 0.1287 |   3.99 KB |
| Presign_S3GetObject               | 6,356.0 ns | 23.15 ns | 13.78 ns | 0.2299 |   6.82 KB |
| Sign_RestJsonPathResources        | 6,739.2 ns | 82.83 ns | 54.79 ns | 0.1890 |    5.4 KB |
| Sign_S3GetObjectKey               | 5,457.4 ns | 93.60 ns | 55.70 ns | 0.1521 |   4.44 KB |
| CanonicalizeResourcePath_RestJson |   751.1 ns |  4.00 ns |  2.65 ns | 0.0450 |   1.27 KB |
| CanonicalizeResourcePath_S3Key    |   677.5 ns |  6.18 ns |  4.09 ns | 0.0407 |   1.19 KB |
