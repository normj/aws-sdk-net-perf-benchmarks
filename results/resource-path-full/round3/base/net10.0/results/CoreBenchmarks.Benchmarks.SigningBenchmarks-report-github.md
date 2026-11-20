```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.49 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|---------:|---------:|-------:|----------:|
| Sign_JsonPost                     | 6,170.6 ns | 31.87 ns | 21.08 ns | 0.1475 |   4.29 KB |
| Sign_S3GetWithQuery               | 5,719.4 ns | 35.78 ns | 23.67 ns | 0.1586 |   4.51 KB |
| Presign_S3GetObject               | 6,547.7 ns | 37.06 ns | 24.51 ns | 0.2345 |   7.16 KB |
| Sign_RestJsonPathResources        | 6,856.0 ns | 20.82 ns | 12.39 ns | 0.1926 |    5.4 KB |
| Sign_S3GetObjectKey               | 5,534.4 ns | 17.07 ns |  8.93 ns | 0.1558 |   4.44 KB |
| CanonicalizeResourcePath_RestJson |   729.7 ns |  2.04 ns |  1.21 ns | 0.0439 |   1.27 KB |
| CanonicalizeResourcePath_S3Key    |   679.0 ns |  8.38 ns |  5.54 ns | 0.0405 |   1.19 KB |
