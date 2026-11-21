```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.53 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean        | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |------------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost                     | 5,958.03 ns | 54.933 ns | 32.690 ns | 0.1442 |    4392 B |
| Sign_S3GetWithQuery               | 5,569.42 ns | 87.216 ns | 57.688 ns | 0.1548 |    4616 B |
| Presign_S3GetObject               | 6,364.27 ns | 36.528 ns | 24.161 ns | 0.2569 |    7328 B |
| Sign_RestJsonPathResources        | 6,669.62 ns | 26.429 ns | 15.728 ns | 0.1866 |    5528 B |
| Sign_S3GetObjectKey               | 5,359.27 ns | 45.235 ns | 26.919 ns | 0.1505 |    4544 B |
| CanonicalizeResourcePath_RestJson |   736.91 ns |  4.956 ns |  3.278 ns | 0.0442 |    1304 B |
| CanonicalizeResourcePath_S3Key    |   666.59 ns |  8.100 ns |  5.358 ns | 0.0422 |    1216 B |
| Sign_JsonPostPooledBody           | 6,690.64 ns | 18.462 ns | 10.986 ns | 0.2146 |    6320 B |
| ContentStreamHash_PooledJson      |   920.02 ns | 11.884 ns |  6.215 ns | 0.0442 |    1280 B |
| ComputeHash_CanonicalRequest      | 1,292.16 ns |  1.026 ns |  0.611 ns |      - |      56 B |
| ToHex_Sha256Lower                 |    22.21 ns |  0.088 ns |  0.046 ns | 0.0054 |     152 B |
