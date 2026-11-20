```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.39 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                            | Mean       | Error       | StdDev    | Gen0   | Allocated |
|---------------------------------- |-----------:|------------:|----------:|-------:|----------:|
| Presign_S3GetObject               | 6,572.0 ns |   390.10 ns | 139.11 ns | 0.2564 |   7.16 KB |
| Sign_RestJsonPathResources        | 7,362.9 ns | 1,495.54 ns | 533.32 ns | 0.1707 |    5.4 KB |
| CanonicalizeResourcePath_RestJson |   678.0 ns |     9.36 ns |   3.34 ns | 0.0443 |   1.27 KB |
| CanonicalizeResourcePath_S3Key    |   611.5 ns |     7.49 ns |   2.67 ns | 0.0414 |   1.19 KB |
