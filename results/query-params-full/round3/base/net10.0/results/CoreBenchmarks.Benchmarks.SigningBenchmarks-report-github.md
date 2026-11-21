```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.96 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method              | Mean     | Error     | StdDev    | Gen0   | Allocated |
|-------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_S3GetWithQuery | 5.688 μs | 0.0438 μs | 0.0229 μs | 0.1582 |   4.51 KB |
| Presign_S3GetObject | 6.451 μs | 0.1133 μs | 0.0592 μs | 0.2554 |   7.16 KB |
| Sign_S3GetObjectKey | 5.569 μs | 0.0317 μs | 0.0189 μs | 0.1557 |   4.44 KB |
