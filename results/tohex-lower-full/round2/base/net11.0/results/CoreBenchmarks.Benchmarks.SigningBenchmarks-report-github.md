```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.44 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean        | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |------------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost                     | 6,040.64 ns | 63.950 ns | 42.299 ns | 0.1445 |    4392 B |
| Sign_S3GetWithQuery               | 5,630.16 ns | 23.747 ns | 15.707 ns | 0.1588 |    4616 B |
| Presign_S3GetObject               | 6,638.50 ns | 42.368 ns | 28.024 ns | 0.2380 |    7328 B |
| Sign_RestJsonPathResources        | 6,740.51 ns | 39.978 ns | 26.443 ns | 0.1892 |    5528 B |
| Sign_S3GetObjectKey               | 5,396.31 ns | 12.054 ns |  6.305 ns | 0.1514 |    4544 B |
| CanonicalizeResourcePath_RestJson |   806.98 ns |  7.367 ns |  4.873 ns | 0.0450 |    1304 B |
| CanonicalizeResourcePath_S3Key    |   592.42 ns |  8.789 ns |  5.813 ns | 0.0423 |    1216 B |
| Sign_JsonPostPooledBody           | 6,750.65 ns | 32.359 ns | 21.404 ns | 0.2151 |    6320 B |
| ContentStreamHash_PooledJson      |   937.33 ns |  3.265 ns |  1.943 ns | 0.0449 |    1280 B |
| ComputeHash_CanonicalRequest      | 1,402.70 ns | 36.023 ns | 23.827 ns |      - |      56 B |
| ToHex_Sha256Lower                 |    41.79 ns |  0.160 ns |  0.084 ns | 0.0053 |     152 B |
