```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.5 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|---------:|---------:|-------:|----------:|
| Sign_JsonPost                     | 6,025.6 ns | 82.56 ns | 49.13 ns | 0.1445 |    4392 B |
| Sign_S3GetWithQuery               | 5,562.3 ns | 26.78 ns | 17.72 ns | 0.1555 |    4616 B |
| Presign_S3GetObject               | 6,300.7 ns | 50.18 ns | 33.19 ns | 0.2307 |    6672 B |
| Sign_RestJsonPathResources        | 6,178.0 ns | 13.58 ns |  7.10 ns | 0.1488 |    4600 B |
| Sign_S3GetObjectKey               | 4,947.5 ns | 31.60 ns | 16.53 ns | 0.1193 |    3528 B |
| CanonicalizeResourcePath_RestJson |   310.5 ns |  2.31 ns |  1.38 ns | 0.0123 |     376 B |
| CanonicalizeResourcePath_S3Key    |   286.9 ns |  0.81 ns |  0.53 ns | 0.0069 |     200 B |
