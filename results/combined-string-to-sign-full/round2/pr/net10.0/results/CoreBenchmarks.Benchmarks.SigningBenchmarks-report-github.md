```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.73 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.915 μs | 0.1440 μs | 0.0953 μs | 0.0719 |   2.43 KB |
| Sign_S3GetWithQuery        | 5.803 μs | 0.2218 μs | 0.1467 μs | 0.0887 |   2.88 KB |
| Presign_S3GetObject        | 6.594 μs | 0.1753 μs | 0.1159 μs | 0.1828 |   5.59 KB |
| Sign_RestJsonPathResources | 6.545 μs | 0.0593 μs | 0.0392 μs | 0.1044 |   3.58 KB |
| Sign_S3GetObjectKey        | 5.140 μs | 0.0190 μs | 0.0113 μs | 0.1025 |   2.98 KB |
| Sign_JsonPostPooledBody    | 6.489 μs | 0.0509 μs | 0.0303 μs | 0.1551 |   4.31 KB |
| Sign_S3PutTrailingChecksum | 6.503 μs | 0.0478 μs | 0.0316 μs | 0.1317 |   3.88 KB |
