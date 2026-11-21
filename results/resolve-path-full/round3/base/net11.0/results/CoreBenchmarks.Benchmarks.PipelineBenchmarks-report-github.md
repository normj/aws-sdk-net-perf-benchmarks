```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.12 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                          | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------- |---------:|---------:|---------:|-------:|----------:|
| RestUrl_ResolvePath_Label       | 270.4 ns |  1.47 ns |  0.77 ns | 0.0260 |     736 B |
| RestUrl_ResolvePath_S3GreedyKey | 385.4 ns |  6.17 ns |  3.67 ns | 0.0280 |     824 B |
| RestUrl_ComposeUrl_Label        | 460.1 ns | 16.74 ns | 11.07 ns | 0.0417 |    1208 B |
| RestUrl_ComposeUrl_S3GreedyKey  | 599.1 ns |  2.84 ns |  1.69 ns | 0.0432 |    1224 B |
