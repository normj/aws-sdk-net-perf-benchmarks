```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.96 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error     | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|----------:|---------:|-------:|----------:|
| Sign_JsonPost                     | 6,183.4 ns | 110.17 ns | 72.87 ns | 0.1446 |   4.29 KB |
| Sign_S3GetWithQuery               | 5,956.0 ns |  21.20 ns | 12.61 ns | 0.1634 |   4.51 KB |
| Presign_S3GetObject               | 6,782.6 ns |  80.18 ns | 53.03 ns | 0.2462 |   7.16 KB |
| Sign_RestJsonPathResources        | 7,234.9 ns |  46.46 ns | 27.65 ns | 0.1735 |    5.4 KB |
| Sign_S3GetObjectKey               | 5,771.1 ns |  35.84 ns | 23.71 ns | 0.1388 |   4.44 KB |
| CanonicalizeResourcePath_RestJson |   930.4 ns |   7.54 ns |  4.99 ns | 0.0441 |   1.27 KB |
| CanonicalizeResourcePath_S3Key    |   881.8 ns |  11.57 ns |  7.65 ns | 0.0425 |   1.19 KB |
