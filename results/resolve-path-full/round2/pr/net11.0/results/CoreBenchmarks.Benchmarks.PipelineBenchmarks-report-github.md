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
| Method                          | Mean     | Error    | StdDev  | Gen0   | Allocated |
|-------------------------------- |---------:|---------:|--------:|-------:|----------:|
| RestUrl_ResolvePath_Label       | 162.1 ns |  2.48 ns | 1.64 ns | 0.0039 |     112 B |
| RestUrl_ResolvePath_S3GreedyKey | 154.7 ns |  0.33 ns | 0.17 ns | 0.0031 |      96 B |
| RestUrl_ComposeUrl_Label        | 315.0 ns |  1.71 ns | 0.89 ns | 0.0202 |     584 B |
| RestUrl_ComposeUrl_S3GreedyKey  | 362.1 ns | 12.32 ns | 8.15 ns | 0.0170 |     496 B |
