```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.92 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|---------:|---------:|-------:|----------:|
| Sign_JsonPost                     | 6,010.4 ns | 23.47 ns | 13.96 ns | 0.1445 |   4.29 KB |
| Sign_S3GetWithQuery               | 5,696.4 ns | 63.70 ns | 33.31 ns | 0.1583 |   4.51 KB |
| Presign_S3GetObject               | 6,522.6 ns | 24.00 ns | 14.28 ns | 0.2338 |   7.16 KB |
| Sign_RestJsonPathResources        | 6,723.5 ns | 34.44 ns | 22.78 ns | 0.1874 |    5.4 KB |
| Sign_S3GetObjectKey               | 5,410.9 ns | 14.08 ns |  8.38 ns | 0.1522 |   4.44 KB |
| CanonicalizeResourcePath_RestJson |   711.9 ns |  3.93 ns |  2.34 ns | 0.0454 |   1.27 KB |
| CanonicalizeResourcePath_S3Key    |   671.5 ns |  4.40 ns |  2.62 ns | 0.0404 |   1.19 KB |
