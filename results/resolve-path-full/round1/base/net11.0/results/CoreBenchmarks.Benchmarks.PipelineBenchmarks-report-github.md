```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.01 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                          | Mean     | Error   | StdDev  | Gen0   | Allocated |
|-------------------------------- |---------:|--------:|--------:|-------:|----------:|
| RestUrl_ResolvePath_Label       | 269.4 ns | 2.70 ns | 1.61 ns | 0.0259 |     736 B |
| RestUrl_ResolvePath_S3GreedyKey | 372.2 ns | 2.85 ns | 1.88 ns | 0.0281 |     824 B |
| RestUrl_ComposeUrl_Label        | 438.5 ns | 2.03 ns | 1.34 ns | 0.0420 |    1208 B |
| RestUrl_ComposeUrl_S3GreedyKey  | 608.2 ns | 1.41 ns | 0.74 ns | 0.0416 |    1224 B |
