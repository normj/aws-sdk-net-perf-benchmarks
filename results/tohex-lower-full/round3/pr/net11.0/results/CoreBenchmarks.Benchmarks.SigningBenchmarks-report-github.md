```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.61 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean        | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |------------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost                     | 5,907.50 ns | 46.120 ns | 27.445 ns | 0.1427 |    4392 B |
| Sign_S3GetWithQuery               | 5,522.09 ns | 32.335 ns | 19.242 ns | 0.1539 |    4616 B |
| Presign_S3GetObject               | 6,354.03 ns | 35.983 ns | 23.801 ns | 0.2540 |    7328 B |
| Sign_RestJsonPathResources        | 6,611.20 ns | 29.677 ns | 17.660 ns | 0.1850 |    5528 B |
| Sign_S3GetObjectKey               | 5,397.43 ns | 20.335 ns | 13.450 ns | 0.1516 |    4544 B |
| CanonicalizeResourcePath_RestJson |   688.33 ns |  3.226 ns |  1.920 ns | 0.0441 |    1304 B |
| CanonicalizeResourcePath_S3Key    |   590.76 ns |  6.111 ns |  3.196 ns | 0.0423 |    1216 B |
| Sign_JsonPostPooledBody           | 6,633.33 ns | 72.328 ns | 47.840 ns | 0.2122 |    6320 B |
| ContentStreamHash_PooledJson      |   839.90 ns |  0.962 ns |  0.503 ns | 0.0437 |    1280 B |
| ComputeHash_CanonicalRequest      | 1,298.18 ns |  1.133 ns |  0.674 ns |      - |      56 B |
| ToHex_Sha256Lower                 |    17.67 ns |  0.094 ns |  0.062 ns | 0.0053 |     152 B |
