```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.14 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                          | Mean     | Error   | StdDev  | Gen0   | Allocated |
|-------------------------------- |---------:|--------:|--------:|-------:|----------:|
| RestUrl_ResolvePath_Label       | 162.1 ns | 2.13 ns | 1.41 ns | 0.0039 |     112 B |
| RestUrl_ResolvePath_S3GreedyKey | 155.9 ns | 0.58 ns | 0.34 ns | 0.0031 |      96 B |
| RestUrl_ComposeUrl_Label        | 365.9 ns | 3.39 ns | 2.24 ns | 0.0204 |     584 B |
| RestUrl_ComposeUrl_S3GreedyKey  | 443.0 ns | 7.19 ns | 4.76 ns | 0.0175 |     496 B |
