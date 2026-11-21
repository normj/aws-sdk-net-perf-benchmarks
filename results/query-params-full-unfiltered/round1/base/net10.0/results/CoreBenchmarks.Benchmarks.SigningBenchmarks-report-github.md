```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.88 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |-----------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost                     | 6,307.4 ns | 199.21 ns | 118.54 ns | 0.1297 |   4.29 KB |
| Sign_S3GetWithQuery               | 5,718.5 ns |  52.07 ns |  30.98 ns | 0.1597 |   4.51 KB |
| Presign_S3GetObject               | 6,539.2 ns |  58.68 ns |  38.81 ns | 0.2353 |   7.16 KB |
| Sign_RestJsonPathResources        | 6,935.7 ns | 179.34 ns | 106.72 ns | 0.1910 |    5.4 KB |
| Sign_S3GetObjectKey               | 5,465.7 ns |  58.38 ns |  34.74 ns | 0.1568 |   4.44 KB |
| CanonicalizeResourcePath_RestJson | 1,071.5 ns | 357.45 ns | 236.43 ns | 0.0424 |   1.27 KB |
| CanonicalizeResourcePath_S3Key    |   671.1 ns |  49.55 ns |  25.91 ns | 0.0427 |   1.19 KB |
