```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.94 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |-----------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost                     | 6,202.7 ns |  71.21 ns |  37.24 ns | 0.1499 |    4392 B |
| Sign_S3GetWithQuery               | 5,708.2 ns |  55.88 ns |  36.96 ns | 0.1555 |    4616 B |
| Presign_S3GetObject               | 6,556.5 ns | 166.18 ns | 109.92 ns | 0.2330 |    6672 B |
| Sign_RestJsonPathResources        | 6,304.5 ns |  40.67 ns |  26.90 ns | 0.1513 |    4600 B |
| Sign_S3GetObjectKey               | 5,017.4 ns |  36.61 ns |  24.22 ns | 0.1205 |    3528 B |
| CanonicalizeResourcePath_RestJson |   329.4 ns |   2.58 ns |   1.70 ns | 0.0132 |     376 B |
| CanonicalizeResourcePath_S3Key    |   296.3 ns |   2.40 ns |   1.59 ns | 0.0071 |     200 B |
