```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.49 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean        | Error      | StdDev     | Gen0   | Allocated |
|---------------------------------- |------------:|-----------:|-----------:|-------:|----------:|
| Sign_JsonPost                     | 6,081.17 ns | 197.049 ns | 117.261 ns | 0.1431 |    4392 B |
| Sign_S3GetWithQuery               | 5,552.84 ns |  18.292 ns |  12.099 ns | 0.1554 |    4616 B |
| Presign_S3GetObject               | 6,464.98 ns |  95.606 ns |  63.238 ns | 0.2565 |    7328 B |
| Sign_RestJsonPathResources        | 6,740.64 ns | 136.277 ns |  90.139 ns | 0.1867 |    5528 B |
| Sign_S3GetObjectKey               | 5,398.69 ns |   5.041 ns |   2.636 ns | 0.1512 |    4544 B |
| CanonicalizeResourcePath_RestJson |   695.12 ns |   2.918 ns |   1.736 ns | 0.0443 |    1304 B |
| CanonicalizeResourcePath_S3Key    |   591.50 ns |   4.247 ns |   2.809 ns | 0.0427 |    1216 B |
| Sign_JsonPostPooledBody           | 6,721.73 ns |  34.975 ns |  23.134 ns | 0.2138 |    6320 B |
| ContentStreamHash_PooledJson      |   906.08 ns |   5.581 ns |   3.321 ns | 0.0436 |    1280 B |
| ComputeHash_CanonicalRequest      | 1,379.66 ns |   1.981 ns |   1.310 ns |      - |      56 B |
| ToHex_Sha256Lower                 |    17.72 ns |   0.112 ns |   0.074 ns | 0.0053 |     152 B |
