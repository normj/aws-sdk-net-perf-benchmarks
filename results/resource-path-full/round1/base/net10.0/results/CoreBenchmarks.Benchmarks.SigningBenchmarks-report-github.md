```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.48 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean     | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost                     | 6.380 μs | 0.1989 μs | 0.1315 μs | 0.1323 |   4.29 KB |
| Sign_S3GetWithQuery               | 5.854 μs | 0.0797 μs | 0.0527 μs | 0.1456 |   4.51 KB |
| Presign_S3GetObject               | 6.807 μs | 0.0905 μs | 0.0599 μs | 0.2430 |   7.16 KB |
| Sign_RestJsonPathResources        | 8.928 μs | 1.6515 μs | 1.0924 μs | 0.1682 |    5.4 KB |
| Sign_S3GetObjectKey               | 9.034 μs | 0.7426 μs | 0.4419 μs | 0.1304 |   4.44 KB |
| CanonicalizeResourcePath_RestJson | 1.084 μs | 0.4987 μs | 0.3298 μs | 0.0418 |   1.27 KB |
| CanonicalizeResourcePath_S3Key    | 1.486 μs | 0.4723 μs | 0.2810 μs | 0.0423 |   1.19 KB |
