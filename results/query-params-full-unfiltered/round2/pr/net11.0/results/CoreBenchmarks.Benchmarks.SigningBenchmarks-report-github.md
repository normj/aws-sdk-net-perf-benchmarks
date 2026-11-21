```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.4 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|---------:|---------:|-------:|----------:|
| Sign_JsonPost                     | 6,054.2 ns | 44.53 ns | 26.50 ns | 0.1448 |   4.29 KB |
| Sign_S3GetWithQuery               | 5,353.8 ns | 24.29 ns | 16.06 ns | 0.1279 |   3.99 KB |
| Presign_S3GetObject               | 6,543.7 ns | 33.66 ns | 20.03 ns | 0.2346 |   6.82 KB |
| Sign_RestJsonPathResources        | 6,729.1 ns | 22.22 ns | 14.70 ns | 0.1883 |    5.4 KB |
| Sign_S3GetObjectKey               | 5,390.0 ns | 29.36 ns | 19.42 ns | 0.1502 |   4.44 KB |
| CanonicalizeResourcePath_RestJson |   709.5 ns |  4.95 ns |  3.28 ns | 0.0453 |   1.27 KB |
| CanonicalizeResourcePath_S3Key    |   619.9 ns | 13.78 ns |  8.20 ns | 0.0422 |   1.19 KB |
