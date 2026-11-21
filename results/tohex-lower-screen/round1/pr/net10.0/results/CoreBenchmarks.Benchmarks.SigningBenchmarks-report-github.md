```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.11 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                            | Mean        | Error        | StdDev     | Gen0   | Allocated |
|---------------------------------- |------------:|-------------:|-----------:|-------:|----------:|
| Sign_JsonPost                     | 8,307.73 ns | 2,161.161 ns | 770.691 ns | 0.1442 |    4392 B |
| Sign_S3GetWithQuery               | 8,131.72 ns |   793.477 ns | 282.961 ns | 0.1386 |    4616 B |
| Presign_S3GetObject               | 6,463.88 ns |   187.273 ns |  48.634 ns | 0.2345 |    7328 B |
| Sign_RestJsonPathResources        | 6,723.38 ns |   155.861 ns |  40.477 ns | 0.1905 |    5528 B |
| Sign_S3GetObjectKey               | 5,408.07 ns |   190.587 ns |  67.965 ns | 0.1504 |    4544 B |
| CanonicalizeResourcePath_RestJson |   715.76 ns |     3.448 ns |   0.896 ns | 0.0459 |    1304 B |
| CanonicalizeResourcePath_S3Key    |   654.84 ns |    35.242 ns |  12.568 ns | 0.0413 |    1216 B |
| ToHex_Sha256Lower                 |    22.43 ns |     0.260 ns |   0.093 ns | 0.0054 |     152 B |
