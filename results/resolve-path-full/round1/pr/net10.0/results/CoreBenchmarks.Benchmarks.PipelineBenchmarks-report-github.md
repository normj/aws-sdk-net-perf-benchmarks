```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.08 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                          | Mean     | Error   | StdDev  | Gen0   | Allocated |
|-------------------------------- |---------:|--------:|--------:|-------:|----------:|
| RestUrl_ResolvePath_Label       | 158.4 ns | 0.88 ns | 0.46 ns | 0.0038 |     112 B |
| RestUrl_ResolvePath_S3GreedyKey | 158.5 ns | 0.62 ns | 0.41 ns | 0.0032 |      96 B |
| RestUrl_ComposeUrl_Label        | 364.9 ns | 2.40 ns | 1.59 ns | 0.0204 |     584 B |
| RestUrl_ComposeUrl_S3GreedyKey  | 445.2 ns | 1.73 ns | 1.14 ns | 0.0160 |     496 B |
