```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.13 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                          | Mean     | Error   | StdDev  | Gen0   | Allocated |
|-------------------------------- |---------:|--------:|--------:|-------:|----------:|
| RestUrl_ResolvePath_Label       | 269.9 ns | 5.25 ns | 3.13 ns | 0.0255 |     736 B |
| RestUrl_ResolvePath_S3GreedyKey | 388.8 ns | 7.75 ns | 5.13 ns | 0.0280 |     824 B |
| RestUrl_ComposeUrl_Label        | 439.9 ns | 2.46 ns | 1.46 ns | 0.0414 |    1208 B |
| RestUrl_ComposeUrl_S3GreedyKey  | 603.2 ns | 3.92 ns | 2.59 ns | 0.0434 |    1224 B |
