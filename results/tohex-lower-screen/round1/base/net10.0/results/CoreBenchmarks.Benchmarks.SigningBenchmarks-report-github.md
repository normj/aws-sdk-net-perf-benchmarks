```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.5 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                            | Mean        | Error      | StdDev     | Gen0   | Allocated |
|---------------------------------- |------------:|-----------:|-----------:|-------:|----------:|
| Sign_JsonPost                     | 6,224.86 ns | 131.292 ns |  34.096 ns | 0.1319 |    4392 B |
| Sign_S3GetWithQuery               | 5,758.86 ns | 126.823 ns |  32.936 ns | 0.1409 |    4616 B |
| Presign_S3GetObject               | 6,797.39 ns | 299.261 ns | 106.719 ns | 0.2442 |    7328 B |
| Sign_RestJsonPathResources        | 6,750.14 ns |  73.528 ns |  26.221 ns | 0.1909 |    5528 B |
| Sign_S3GetObjectKey               | 5,534.42 ns | 169.647 ns |  60.498 ns | 0.1533 |    4544 B |
| CanonicalizeResourcePath_RestJson |   759.53 ns |  20.189 ns |   5.243 ns | 0.0449 |    1304 B |
| CanonicalizeResourcePath_S3Key    |   730.86 ns |  28.657 ns |  10.219 ns | 0.0414 |    1216 B |
| ToHex_Sha256Lower                 |    49.83 ns |   1.314 ns |   0.341 ns | 0.0053 |     152 B |
