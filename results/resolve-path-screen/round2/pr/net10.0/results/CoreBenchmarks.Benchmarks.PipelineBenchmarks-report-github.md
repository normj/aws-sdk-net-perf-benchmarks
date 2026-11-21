```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.2 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                          | Mean     | Error   | StdDev  | Gen0   | Allocated |
|-------------------------------- |---------:|--------:|--------:|-------:|----------:|
| RestUrl_ResolvePath_Label       | 165.5 ns | 1.22 ns | 0.32 ns | 0.0033 |     112 B |
| RestUrl_ResolvePath_S3GreedyKey | 162.7 ns | 2.99 ns | 0.78 ns | 0.0032 |      96 B |
| RestUrl_ComposeUrl_Label        | 392.8 ns | 5.39 ns | 1.40 ns | 0.0204 |     584 B |
| RestUrl_ComposeUrl_S3GreedyKey  | 470.2 ns | 6.52 ns | 2.32 ns | 0.0168 |     496 B |
