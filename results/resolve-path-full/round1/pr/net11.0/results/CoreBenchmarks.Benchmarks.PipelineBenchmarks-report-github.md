```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.09 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                          | Mean     | Error   | StdDev  | Gen0   | Allocated |
|-------------------------------- |---------:|--------:|--------:|-------:|----------:|
| RestUrl_ResolvePath_Label       | 158.6 ns | 1.89 ns | 0.99 ns | 0.0038 |     112 B |
| RestUrl_ResolvePath_S3GreedyKey | 154.3 ns | 0.39 ns | 0.23 ns | 0.0031 |      96 B |
| RestUrl_ComposeUrl_Label        | 314.4 ns | 2.01 ns | 1.19 ns | 0.0200 |     584 B |
| RestUrl_ComposeUrl_S3GreedyKey  | 341.0 ns | 1.60 ns | 0.95 ns | 0.0164 |     496 B |
