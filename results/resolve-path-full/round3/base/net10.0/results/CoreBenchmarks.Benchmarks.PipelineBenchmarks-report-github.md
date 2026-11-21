```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.11 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                          | Mean     | Error   | StdDev  | Gen0   | Allocated |
|-------------------------------- |---------:|--------:|--------:|-------:|----------:|
| RestUrl_ResolvePath_Label       | 291.9 ns | 2.16 ns | 1.43 ns | 0.0256 |     736 B |
| RestUrl_ResolvePath_S3GreedyKey | 394.2 ns | 1.36 ns | 0.71 ns | 0.0286 |     824 B |
| RestUrl_ComposeUrl_Label        | 537.2 ns | 3.52 ns | 2.09 ns | 0.0427 |    1208 B |
| RestUrl_ComposeUrl_S3GreedyKey  | 719.4 ns | 3.24 ns | 1.69 ns | 0.0429 |    1224 B |
