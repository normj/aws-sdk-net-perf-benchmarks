```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.36 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error     | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|----------:|---------:|-------:|----------:|
| Sign_JsonPost                     | 6,267.4 ns |  95.31 ns | 63.04 ns | 0.1519 |   4.29 KB |
| Sign_S3GetWithQuery               | 5,656.2 ns |  98.61 ns | 65.22 ns | 0.1624 |   4.51 KB |
| Presign_S3GetObject               | 6,964.4 ns | 101.17 ns | 60.21 ns | 0.2503 |   7.16 KB |
| Sign_RestJsonPathResources        | 6,620.7 ns |  22.15 ns | 14.65 ns | 0.1859 |    5.4 KB |
| Sign_S3GetObjectKey               | 5,369.5 ns |  40.99 ns | 27.11 ns | 0.1502 |   4.44 KB |
| CanonicalizeResourcePath_RestJson |   682.2 ns |   8.57 ns |  5.10 ns | 0.0445 |   1.27 KB |
| CanonicalizeResourcePath_S3Key    |   663.6 ns |   6.71 ns |  4.00 ns | 0.0422 |   1.19 KB |
