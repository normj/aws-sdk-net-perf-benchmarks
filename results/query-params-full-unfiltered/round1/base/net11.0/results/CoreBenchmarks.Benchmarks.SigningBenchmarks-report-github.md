```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error       | StdDev      | Gen0   | Allocated |
|---------------------------------- |-----------:|------------:|------------:|-------:|----------:|
| Sign_JsonPost                     | 6,021.1 ns |    25.65 ns |    15.26 ns | 0.1447 |   4.29 KB |
| Sign_S3GetWithQuery               | 5,585.7 ns |    18.84 ns |    11.21 ns | 0.1561 |   4.51 KB |
| Presign_S3GetObject               | 6,550.9 ns |    43.34 ns |    25.79 ns | 0.2349 |   7.16 KB |
| Sign_RestJsonPathResources        | 7,487.7 ns | 1,747.98 ns | 1,156.18 ns | 0.1915 |    5.4 KB |
| Sign_S3GetObjectKey               | 5,406.6 ns |    19.07 ns |    11.35 ns | 0.1514 |   4.44 KB |
| CanonicalizeResourcePath_RestJson |   669.7 ns |     1.79 ns |     0.93 ns | 0.0453 |   1.27 KB |
| CanonicalizeResourcePath_S3Key    |   578.7 ns |     4.95 ns |     3.27 ns | 0.0410 |   1.19 KB |
