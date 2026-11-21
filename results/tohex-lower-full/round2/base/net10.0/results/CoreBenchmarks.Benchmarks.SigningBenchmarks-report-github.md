```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.5 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean        | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |------------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost                     | 6,265.65 ns | 74.520 ns | 49.290 ns | 0.1505 |    4392 B |
| Sign_S3GetWithQuery               | 5,562.60 ns | 49.667 ns | 32.852 ns | 0.1549 |    4616 B |
| Presign_S3GetObject               | 6,419.24 ns | 78.107 ns | 46.480 ns | 0.2545 |    7328 B |
| Sign_RestJsonPathResources        | 6,962.86 ns | 52.783 ns | 34.912 ns | 0.1950 |    5528 B |
| Sign_S3GetObjectKey               | 5,426.24 ns | 14.901 ns |  7.794 ns | 0.1515 |    4544 B |
| CanonicalizeResourcePath_RestJson |   750.12 ns |  5.444 ns |  3.240 ns | 0.0452 |    1304 B |
| CanonicalizeResourcePath_S3Key    |   692.01 ns |  7.040 ns |  4.657 ns | 0.0411 |    1216 B |
| Sign_JsonPostPooledBody           | 6,850.58 ns | 67.175 ns | 44.432 ns | 0.2172 |    6320 B |
| ContentStreamHash_PooledJson      |   860.08 ns |  2.058 ns |  1.224 ns | 0.0450 |    1280 B |
| ComputeHash_CanonicalRequest      | 1,294.55 ns |  2.201 ns |  1.310 ns |      - |      56 B |
| ToHex_Sha256Lower                 |    49.55 ns |  0.227 ns |  0.135 ns | 0.0053 |     152 B |
