```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.76 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error     | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|----------:|---------:|-------:|----------:|
| Sign_JsonPost                     | 5,979.3 ns |  15.13 ns |  9.00 ns | 0.1435 |   4.29 KB |
| Sign_S3GetWithQuery               | 5,530.9 ns |  14.95 ns |  7.82 ns | 0.1550 |   4.51 KB |
| Presign_S3GetObject               | 6,484.0 ns | 109.49 ns | 72.42 ns | 0.2573 |   7.16 KB |
| Sign_RestJsonPathResources        | 6,614.7 ns |  48.26 ns | 28.72 ns | 0.1838 |    5.4 KB |
| Sign_S3GetObjectKey               | 5,361.9 ns |  13.62 ns |  8.10 ns | 0.1495 |   4.44 KB |
| CanonicalizeResourcePath_RestJson |   697.3 ns |  15.35 ns |  9.13 ns | 0.0435 |   1.27 KB |
| CanonicalizeResourcePath_S3Key    |   580.4 ns |   5.98 ns |  3.96 ns | 0.0418 |   1.19 KB |
