```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.27 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean        | Error      | StdDev     | Gen0   | Allocated |
|---------------------------------- |------------:|-----------:|-----------:|-------:|----------:|
| Sign_JsonPost                     | 5,956.04 ns | 151.752 ns | 100.375 ns | 0.1550 |    4392 B |
| Sign_S3GetWithQuery               | 5,512.62 ns |  37.423 ns |  22.270 ns | 0.1536 |    4616 B |
| Presign_S3GetObject               | 6,384.77 ns |  43.583 ns |  28.827 ns | 0.2564 |    7328 B |
| Sign_RestJsonPathResources        | 6,633.20 ns |  18.333 ns |   9.588 ns | 0.1849 |    5528 B |
| Sign_S3GetObjectKey               | 5,295.74 ns |  25.884 ns |  17.121 ns | 0.1486 |    4544 B |
| CanonicalizeResourcePath_RestJson |   713.34 ns |   4.042 ns |   2.405 ns | 0.0454 |    1304 B |
| CanonicalizeResourcePath_S3Key    |   655.97 ns |   6.374 ns |   4.216 ns | 0.0419 |    1216 B |
| Sign_JsonPostPooledBody           | 6,711.55 ns |  38.691 ns |  25.591 ns | 0.2124 |    6320 B |
| ContentStreamHash_PooledJson      |   907.35 ns |   5.312 ns |   3.513 ns | 0.0438 |    1280 B |
| ComputeHash_CanonicalRequest      | 1,294.71 ns |   0.911 ns |   0.602 ns |      - |      56 B |
| ToHex_Sha256Lower                 |    22.46 ns |   0.180 ns |   0.107 ns | 0.0053 |     152 B |
