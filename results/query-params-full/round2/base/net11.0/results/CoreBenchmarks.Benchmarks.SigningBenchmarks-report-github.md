```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.58 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method              | Mean     | Error     | StdDev    | Gen0   | Allocated |
|-------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_S3GetWithQuery | 5.426 μs | 0.0478 μs | 0.0316 μs | 0.1531 |   4.51 KB |
| Presign_S3GetObject | 7.233 μs | 2.1851 μs | 1.4453 μs | 0.2558 |   7.16 KB |
| Sign_S3GetObjectKey | 5.333 μs | 0.0147 μs | 0.0097 μs | 0.1515 |   4.44 KB |
