```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.36 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                          | Mean     | Error   | StdDev  | Gen0   | Allocated |
|-------------------------------- |---------:|--------:|--------:|-------:|----------:|
| RestUrl_ResolvePath_Label       | 161.9 ns | 2.88 ns | 0.75 ns | 0.0039 |     112 B |
| RestUrl_ResolvePath_S3GreedyKey | 159.1 ns | 1.24 ns | 0.32 ns | 0.0032 |      96 B |
| RestUrl_ComposeUrl_Label        | 384.3 ns | 2.16 ns | 0.56 ns | 0.0197 |     584 B |
| RestUrl_ComposeUrl_S3GreedyKey  | 479.2 ns | 1.62 ns | 0.42 ns | 0.0172 |     496 B |
