```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.22 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean        | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |------------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost                     | 5,898.47 ns | 49.663 ns | 29.554 ns | 0.1410 |    4392 B |
| Sign_S3GetWithQuery               | 5,516.56 ns | 50.387 ns | 33.328 ns | 0.1542 |    4616 B |
| Presign_S3GetObject               | 6,505.46 ns | 28.046 ns | 16.690 ns | 0.2346 |    7328 B |
| Sign_RestJsonPathResources        | 6,687.20 ns | 29.292 ns | 19.375 ns | 0.1868 |    5528 B |
| Sign_S3GetObjectKey               | 5,425.25 ns | 59.754 ns | 35.558 ns | 0.1516 |    4544 B |
| CanonicalizeResourcePath_RestJson |   781.04 ns |  9.192 ns |  6.080 ns | 0.0450 |    1304 B |
| CanonicalizeResourcePath_S3Key    |   622.48 ns | 19.462 ns | 12.873 ns | 0.0414 |    1216 B |
| Sign_JsonPostPooledBody           | 6,697.26 ns | 91.185 ns | 60.313 ns | 0.2123 |    6320 B |
| ContentStreamHash_PooledJson      |   837.74 ns |  3.725 ns |  2.217 ns | 0.0437 |    1280 B |
| ComputeHash_CanonicalRequest      | 1,303.35 ns |  0.869 ns |  0.517 ns |      - |      56 B |
| ToHex_Sha256Lower                 |    17.72 ns |  0.130 ns |  0.086 ns | 0.0053 |     152 B |
