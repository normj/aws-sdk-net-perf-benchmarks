```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.5 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|---------:|---------:|-------:|----------:|
| Sign_JsonPost                     | 6,524.3 ns | 37.16 ns | 24.58 ns | 0.1299 |    4392 B |
| Sign_S3GetWithQuery               | 5,909.2 ns | 24.16 ns | 15.98 ns | 0.1418 |    4616 B |
| Presign_S3GetObject               | 6,673.1 ns | 45.64 ns | 30.19 ns | 0.2126 |    6672 B |
| Sign_RestJsonPathResources        | 6,374.0 ns | 55.77 ns | 29.17 ns | 0.1532 |    4600 B |
| Sign_S3GetObjectKey               | 5,050.4 ns | 58.12 ns | 38.44 ns | 0.1212 |    3528 B |
| CanonicalizeResourcePath_RestJson |   342.5 ns |  1.22 ns |  0.81 ns | 0.0123 |     376 B |
| CanonicalizeResourcePath_S3Key    |   299.8 ns |  1.70 ns |  1.13 ns | 0.0060 |     200 B |
