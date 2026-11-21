```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.78 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error     | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|----------:|---------:|-------:|----------:|
| Sign_JsonPost                     | 6,024.1 ns |  49.76 ns | 26.02 ns | 0.1446 |   4.29 KB |
| Sign_S3GetWithQuery               | 5,391.8 ns | 106.10 ns | 70.18 ns | 0.1280 |   3.99 KB |
| Presign_S3GetObject               | 6,414.2 ns |  97.04 ns | 57.75 ns | 0.2288 |   6.82 KB |
| Sign_RestJsonPathResources        | 6,768.4 ns | 140.90 ns | 83.85 ns | 0.1870 |    5.4 KB |
| Sign_S3GetObjectKey               | 5,467.9 ns |  17.52 ns | 10.43 ns | 0.1529 |   4.44 KB |
| CanonicalizeResourcePath_RestJson |   741.4 ns |   5.69 ns |  3.77 ns | 0.0444 |   1.27 KB |
| CanonicalizeResourcePath_S3Key    |   660.4 ns |   3.20 ns |  1.67 ns | 0.0425 |   1.19 KB |
