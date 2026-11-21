```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.44 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                          | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------- |---------:|---------:|---------:|-------:|----------:|
| RestUrl_ResolvePath_Label       | 303.8 ns | 16.50 ns |  5.88 ns | 0.0260 |     736 B |
| RestUrl_ResolvePath_S3GreedyKey | 412.0 ns | 13.28 ns |  3.45 ns | 0.0276 |     824 B |
| RestUrl_ComposeUrl_Label        | 556.1 ns | 46.19 ns | 16.47 ns | 0.0415 |    1208 B |
| RestUrl_ComposeUrl_S3GreedyKey  | 736.2 ns |  5.79 ns |  2.06 ns | 0.0415 |    1224 B |
