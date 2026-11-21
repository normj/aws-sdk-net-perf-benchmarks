```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.13 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                          | Mean     | Error    | StdDev  | Gen0   | Allocated |
|-------------------------------- |---------:|---------:|--------:|-------:|----------:|
| RestUrl_ResolvePath_Label       | 326.3 ns | 13.89 ns | 4.95 ns | 0.0249 |     736 B |
| RestUrl_ResolvePath_S3GreedyKey | 440.3 ns |  6.83 ns | 2.44 ns | 0.0279 |     824 B |
| RestUrl_ComposeUrl_Label        | 584.9 ns | 10.61 ns | 3.78 ns | 0.0424 |    1208 B |
| RestUrl_ComposeUrl_S3GreedyKey  | 798.1 ns | 12.04 ns | 4.29 ns | 0.0407 |    1224 B |
