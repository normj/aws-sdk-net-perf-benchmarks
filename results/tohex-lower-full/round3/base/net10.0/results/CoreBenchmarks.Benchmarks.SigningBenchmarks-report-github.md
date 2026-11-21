```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.21 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean        | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |------------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost                     | 6,062.54 ns | 44.760 ns | 29.606 ns | 0.1457 |    4392 B |
| Sign_S3GetWithQuery               | 5,626.69 ns | 26.624 ns | 17.610 ns | 0.1569 |    4616 B |
| Presign_S3GetObject               | 6,616.08 ns | 47.505 ns | 31.422 ns | 0.2361 |    7328 B |
| Sign_RestJsonPathResources        | 6,781.45 ns | 48.824 ns | 32.294 ns | 0.1909 |    5528 B |
| Sign_S3GetObjectKey               | 5,478.33 ns | 46.171 ns | 27.476 ns | 0.1525 |    4544 B |
| CanonicalizeResourcePath_RestJson |   713.75 ns |  2.353 ns |  1.400 ns | 0.0457 |    1304 B |
| CanonicalizeResourcePath_S3Key    |   684.82 ns |  4.254 ns |  2.813 ns | 0.0413 |    1216 B |
| Sign_JsonPostPooledBody           | 6,833.97 ns | 25.875 ns | 17.115 ns | 0.2188 |    6320 B |
| ContentStreamHash_PooledJson      |   868.06 ns |  5.059 ns |  3.011 ns | 0.0421 |    1280 B |
| ComputeHash_CanonicalRequest      | 1,292.70 ns |  2.901 ns |  1.517 ns |      - |      56 B |
| ToHex_Sha256Lower                 |    49.22 ns |  0.113 ns |  0.067 ns | 0.0053 |     152 B |
