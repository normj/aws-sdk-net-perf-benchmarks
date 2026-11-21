```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.39 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                          | Mean     | Error   | StdDev  | Gen0   | Allocated |
|-------------------------------- |---------:|--------:|--------:|-------:|----------:|
| RestUrl_ResolvePath_Label       | 304.2 ns | 6.05 ns | 4.00 ns | 0.0255 |     736 B |
| RestUrl_ResolvePath_S3GreedyKey | 399.6 ns | 3.43 ns | 2.27 ns | 0.0288 |     824 B |
| RestUrl_ComposeUrl_Label        | 541.5 ns | 3.45 ns | 2.05 ns | 0.0410 |    1208 B |
| RestUrl_ComposeUrl_S3GreedyKey  | 721.6 ns | 5.82 ns | 3.04 ns | 0.0411 |    1224 B |
