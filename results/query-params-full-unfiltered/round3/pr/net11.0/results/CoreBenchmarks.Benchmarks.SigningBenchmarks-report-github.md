```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.51 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|---------:|---------:|-------:|----------:|
| Sign_JsonPost                     | 6,062.3 ns | 48.32 ns | 28.75 ns | 0.1451 |   4.29 KB |
| Sign_S3GetWithQuery               | 5,380.4 ns | 12.42 ns |  7.39 ns | 0.1301 |   3.99 KB |
| Presign_S3GetObject               | 6,595.5 ns | 27.21 ns | 16.19 ns | 0.2365 |   6.82 KB |
| Sign_RestJsonPathResources        | 6,704.6 ns | 22.01 ns | 13.10 ns | 0.1878 |    5.4 KB |
| Sign_S3GetObjectKey               | 5,407.6 ns | 20.41 ns | 13.50 ns | 0.1510 |   4.44 KB |
| CanonicalizeResourcePath_RestJson |   714.0 ns |  5.64 ns |  3.73 ns | 0.0433 |   1.27 KB |
| CanonicalizeResourcePath_S3Key    |   604.0 ns |  2.93 ns |  1.74 ns | 0.0415 |   1.19 KB |
