```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.88 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method              | Mean     | Error     | StdDev    | Gen0   | Allocated |
|-------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_S3GetWithQuery | 5.376 μs | 0.0954 μs | 0.0248 μs | 0.1288 |   3.99 KB |
| Presign_S3GetObject | 6.627 μs | 0.2936 μs | 0.0763 μs | 0.2343 |   6.82 KB |
| Sign_S3GetObjectKey | 5.401 μs | 0.0389 μs | 0.0101 μs | 0.1508 |   4.44 KB |
