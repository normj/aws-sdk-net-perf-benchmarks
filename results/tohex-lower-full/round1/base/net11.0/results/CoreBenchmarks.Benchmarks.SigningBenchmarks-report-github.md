```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.95 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean        | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |------------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost                     | 6,078.40 ns | 25.065 ns | 14.916 ns | 0.1450 |    4392 B |
| Sign_S3GetWithQuery               | 5,615.61 ns | 32.403 ns | 19.283 ns | 0.1566 |    4616 B |
| Presign_S3GetObject               | 6,528.04 ns | 43.636 ns | 28.863 ns | 0.2378 |    7328 B |
| Sign_RestJsonPathResources        | 6,812.50 ns | 45.431 ns | 30.050 ns | 0.1910 |    5528 B |
| Sign_S3GetObjectKey               | 5,524.95 ns | 53.345 ns | 31.745 ns | 0.1545 |    4544 B |
| CanonicalizeResourcePath_RestJson |   696.25 ns | 15.038 ns |  8.949 ns | 0.0442 |    1304 B |
| CanonicalizeResourcePath_S3Key    |   602.14 ns | 14.732 ns |  8.767 ns | 0.0411 |    1216 B |
| Sign_JsonPostPooledBody           | 6,793.57 ns | 58.464 ns | 34.791 ns | 0.2212 |    6320 B |
| ContentStreamHash_PooledJson      |   940.53 ns |  3.740 ns |  2.474 ns | 0.0450 |    1280 B |
| ComputeHash_CanonicalRequest      | 1,388.31 ns |  4.896 ns |  3.238 ns |      - |      56 B |
| ToHex_Sha256Lower                 |    42.11 ns |  0.212 ns |  0.140 ns | 0.0052 |     152 B |
