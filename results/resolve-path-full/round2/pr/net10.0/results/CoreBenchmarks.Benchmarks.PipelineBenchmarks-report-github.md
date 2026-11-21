```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.26 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                          | Mean     | Error   | StdDev  | Gen0   | Allocated |
|-------------------------------- |---------:|--------:|--------:|-------:|----------:|
| RestUrl_ResolvePath_Label       | 159.5 ns | 1.18 ns | 0.70 ns | 0.0038 |     112 B |
| RestUrl_ResolvePath_S3GreedyKey | 157.8 ns | 0.54 ns | 0.36 ns | 0.0032 |      96 B |
| RestUrl_ComposeUrl_Label        | 375.4 ns | 2.99 ns | 1.78 ns | 0.0197 |     584 B |
| RestUrl_ComposeUrl_S3GreedyKey  | 447.1 ns | 7.10 ns | 4.69 ns | 0.0164 |     496 B |
