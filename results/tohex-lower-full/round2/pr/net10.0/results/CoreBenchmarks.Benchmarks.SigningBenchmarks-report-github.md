```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.41 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean        | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |------------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost                     | 5,918.84 ns | 36.105 ns | 23.881 ns | 0.1421 |    4392 B |
| Sign_S3GetWithQuery               | 5,488.83 ns | 26.199 ns | 17.329 ns | 0.1528 |    4616 B |
| Presign_S3GetObject               | 6,294.32 ns | 26.828 ns | 15.965 ns | 0.2521 |    7328 B |
| Sign_RestJsonPathResources        | 6,625.07 ns | 50.619 ns | 26.475 ns | 0.1848 |    5528 B |
| Sign_S3GetObjectKey               | 5,251.78 ns | 11.932 ns |  7.101 ns | 0.1479 |    4544 B |
| CanonicalizeResourcePath_RestJson |   713.42 ns |  4.632 ns |  2.422 ns | 0.0456 |    1304 B |
| CanonicalizeResourcePath_S3Key    |   637.90 ns |  7.505 ns |  3.925 ns | 0.0406 |    1216 B |
| Sign_JsonPostPooledBody           | 6,668.23 ns | 43.626 ns | 28.856 ns | 0.2124 |    6320 B |
| ContentStreamHash_PooledJson      |   874.83 ns |  5.436 ns |  3.235 ns | 0.0419 |    1280 B |
| ComputeHash_CanonicalRequest      | 1,289.17 ns |  1.066 ns |  0.557 ns |      - |      56 B |
| ToHex_Sha256Lower                 |    22.64 ns |  0.258 ns |  0.170 ns | 0.0054 |     152 B |
