```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.03 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method              | Mean     | Error     | StdDev    | Gen0   | Allocated |
|-------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_S3GetWithQuery | 5.383 μs | 0.0504 μs | 0.0334 μs | 0.1288 |   3.99 KB |
| Presign_S3GetObject | 6.501 μs | 0.1045 μs | 0.0691 μs | 0.2320 |   6.82 KB |
| Sign_S3GetObjectKey | 5.750 μs | 0.9498 μs | 0.4968 μs | 0.1492 |   4.44 KB |
