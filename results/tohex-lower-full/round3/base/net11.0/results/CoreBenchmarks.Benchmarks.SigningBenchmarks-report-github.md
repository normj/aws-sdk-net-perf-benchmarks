```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.2 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean        | Error      | StdDev    | Gen0   | Allocated |
|---------------------------------- |------------:|-----------:|----------:|-------:|----------:|
| Sign_JsonPost                     | 6,079.95 ns | 124.410 ns | 74.034 ns | 0.1452 |    4392 B |
| Sign_S3GetWithQuery               | 5,586.14 ns |  44.908 ns | 29.704 ns | 0.1571 |    4616 B |
| Presign_S3GetObject               | 6,502.50 ns | 148.409 ns | 98.163 ns | 0.2571 |    7328 B |
| Sign_RestJsonPathResources        | 6,690.85 ns |  17.546 ns | 10.442 ns | 0.1874 |    5528 B |
| Sign_S3GetObjectKey               | 5,373.61 ns |  46.536 ns | 27.693 ns | 0.1499 |    4544 B |
| CanonicalizeResourcePath_RestJson |   687.37 ns |   5.458 ns |  3.610 ns | 0.0440 |    1304 B |
| CanonicalizeResourcePath_S3Key    |   593.58 ns |   3.920 ns |  2.593 ns | 0.0426 |    1216 B |
| Sign_JsonPostPooledBody           | 6,726.20 ns |  57.267 ns | 34.079 ns | 0.2140 |    6320 B |
| ContentStreamHash_PooledJson      |   936.43 ns |   2.972 ns |  1.769 ns | 0.0450 |    1280 B |
| ComputeHash_CanonicalRequest      | 1,388.47 ns |   0.951 ns |  0.566 ns |      - |      56 B |
| ToHex_Sha256Lower                 |    41.85 ns |   0.526 ns |  0.313 ns | 0.0054 |     152 B |
