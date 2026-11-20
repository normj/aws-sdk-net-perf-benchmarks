```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.39GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.36 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                            | Mean       | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|---------:|---------:|-------:|----------:|
| Presign_S3GetObject               | 6,045.8 ns | 66.64 ns | 17.31 ns | 0.2175 |    6672 B |
| Sign_RestJsonPathResources        | 6,320.8 ns | 77.97 ns | 20.25 ns | 0.1516 |    4600 B |
| CanonicalizeResourcePath_RestJson |   316.4 ns | 20.54 ns |  5.33 ns | 0.0123 |     376 B |
| CanonicalizeResourcePath_S3Key    |   292.0 ns |  2.35 ns |  0.61 ns | 0.0070 |     200 B |
