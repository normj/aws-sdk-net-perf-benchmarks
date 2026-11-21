```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.33 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|---------:|---------:|-------:|----------:|
| Sign_JsonPost                     | 6,151.5 ns | 47.65 ns | 31.52 ns | 0.1479 |   4.29 KB |
| Sign_S3GetWithQuery               | 5,712.8 ns | 98.69 ns | 65.28 ns | 0.1583 |   4.51 KB |
| Presign_S3GetObject               | 6,344.4 ns | 26.93 ns | 16.03 ns | 0.2535 |   7.16 KB |
| Sign_RestJsonPathResources        | 6,840.0 ns | 38.20 ns | 25.27 ns | 0.1919 |    5.4 KB |
| Sign_S3GetObjectKey               | 5,526.5 ns | 27.82 ns | 18.40 ns | 0.1540 |   4.44 KB |
| CanonicalizeResourcePath_RestJson |   713.8 ns |  2.03 ns |  1.21 ns | 0.0457 |   1.27 KB |
| CanonicalizeResourcePath_S3Key    |   677.1 ns |  6.25 ns |  3.72 ns | 0.0406 |   1.19 KB |
