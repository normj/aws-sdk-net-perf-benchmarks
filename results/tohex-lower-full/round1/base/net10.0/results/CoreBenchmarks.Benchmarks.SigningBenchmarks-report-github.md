```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.54 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean        | Error      | StdDev     | Gen0   | Allocated |
|---------------------------------- |------------:|-----------:|-----------:|-------:|----------:|
| Sign_JsonPost                     | 6,051.12 ns | 159.263 ns |  94.775 ns | 0.1452 |    4392 B |
| Sign_S3GetWithQuery               | 5,672.28 ns |  68.534 ns |  40.783 ns | 0.1578 |    4616 B |
| Presign_S3GetObject               | 6,665.61 ns | 317.676 ns | 189.044 ns | 0.2422 |    7328 B |
| Sign_RestJsonPathResources        | 6,778.63 ns |  52.164 ns |  34.503 ns | 0.1919 |    5528 B |
| Sign_S3GetObjectKey               | 5,444.90 ns |  15.713 ns |   9.350 ns | 0.1521 |    4544 B |
| CanonicalizeResourcePath_RestJson |   718.05 ns |   6.554 ns |   3.428 ns | 0.0459 |    1304 B |
| CanonicalizeResourcePath_S3Key    |   753.24 ns |   5.171 ns |   3.077 ns | 0.0421 |    1216 B |
| Sign_JsonPostPooledBody           | 6,748.13 ns |  49.045 ns |  32.440 ns | 0.2174 |    6320 B |
| ContentStreamHash_PooledJson      |   871.17 ns |   4.498 ns |   2.975 ns | 0.0452 |    1280 B |
| ComputeHash_CanonicalRequest      | 1,294.86 ns |   7.340 ns |   3.839 ns |      - |      56 B |
| ToHex_Sha256Lower                 |    49.06 ns |   0.328 ns |   0.217 ns | 0.0053 |     152 B |
