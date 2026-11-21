```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.13 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                          | Mean     | Error   | StdDev  | Gen0   | Allocated |
|-------------------------------- |---------:|--------:|--------:|-------:|----------:|
| RestUrl_ResolvePath_Label       | 161.0 ns | 0.48 ns | 0.25 ns | 0.0039 |     112 B |
| RestUrl_ResolvePath_S3GreedyKey | 157.4 ns | 4.02 ns | 2.66 ns | 0.0031 |      96 B |
| RestUrl_ComposeUrl_Label        | 315.4 ns | 2.04 ns | 1.22 ns | 0.0201 |     584 B |
| RestUrl_ComposeUrl_S3GreedyKey  | 340.9 ns | 2.42 ns | 1.44 ns | 0.0163 |     496 B |
