```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.69 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                          | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------- |---------:|---------:|---------:|-------:|----------:|
| RestUrl_ResolvePath_Label       | 293.7 ns |  2.25 ns |  1.49 ns | 0.0258 |     736 B |
| RestUrl_ResolvePath_S3GreedyKey | 405.4 ns |  3.37 ns |  1.76 ns | 0.0290 |     824 B |
| RestUrl_ComposeUrl_Label        | 564.2 ns | 29.23 ns | 17.39 ns | 0.0415 |    1208 B |
| RestUrl_ComposeUrl_S3GreedyKey  | 744.3 ns | 12.95 ns |  7.71 ns | 0.0428 |    1224 B |
