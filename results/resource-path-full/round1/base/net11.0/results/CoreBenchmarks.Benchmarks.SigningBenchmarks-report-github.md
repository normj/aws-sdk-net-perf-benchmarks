```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.28 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|---------:|---------:|-------:|----------:|
| Sign_JsonPost                     | 5,960.9 ns | 26.79 ns | 14.01 ns | 0.1431 |   4.29 KB |
| Sign_S3GetWithQuery               | 5,517.1 ns | 17.08 ns |  8.94 ns | 0.1544 |   4.51 KB |
| Presign_S3GetObject               | 6,459.7 ns | 78.38 ns | 46.65 ns | 0.2337 |   7.16 KB |
| Sign_RestJsonPathResources        | 6,628.3 ns | 22.05 ns | 13.12 ns | 0.1856 |    5.4 KB |
| Sign_S3GetObjectKey               | 5,348.4 ns | 77.52 ns | 51.28 ns | 0.1491 |   4.44 KB |
| CanonicalizeResourcePath_RestJson |   682.1 ns |  3.63 ns |  2.16 ns | 0.0437 |   1.27 KB |
| CanonicalizeResourcePath_S3Key    |   606.5 ns |  1.94 ns |  1.15 ns | 0.0411 |   1.19 KB |
