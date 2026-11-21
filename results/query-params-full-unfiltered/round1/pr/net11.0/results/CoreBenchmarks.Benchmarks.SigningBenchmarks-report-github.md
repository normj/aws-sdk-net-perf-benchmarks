```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.8 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error     | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|----------:|---------:|-------:|----------:|
| Sign_JsonPost                     | 6,147.4 ns | 147.79 ns | 97.76 ns | 0.1467 |   4.29 KB |
| Sign_S3GetWithQuery               | 5,373.5 ns |  77.71 ns | 51.40 ns | 0.1278 |   3.99 KB |
| Presign_S3GetObject               | 6,518.9 ns |  17.52 ns | 10.43 ns | 0.2348 |   6.82 KB |
| Sign_RestJsonPathResources        | 6,800.3 ns |  74.17 ns | 49.06 ns | 0.1889 |    5.4 KB |
| Sign_S3GetObjectKey               | 5,411.6 ns |  75.53 ns | 49.96 ns | 0.1501 |   4.44 KB |
| CanonicalizeResourcePath_RestJson |   705.2 ns |   3.19 ns |  1.90 ns | 0.0449 |   1.27 KB |
| CanonicalizeResourcePath_S3Key    |   636.7 ns | 102.60 ns | 61.06 ns | 0.0428 |   1.19 KB |
