```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.19 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.926 μs | 0.0826 μs | 0.0215 μs | 0.1416 |   3.91 KB |
| Sign_S3GetWithQuery        | 5.538 μs | 0.0831 μs | 0.0296 μs | 0.1545 |   4.28 KB |
| Presign_S3GetObject        | 6.477 μs | 0.0774 μs | 0.0276 μs | 0.2336 |    7.1 KB |
| Sign_RestJsonPathResources | 7.854 μs | 2.9024 μs | 1.0350 μs | 0.1608 |   5.07 KB |
| Sign_S3GetObjectKey        | 5.396 μs | 0.0602 μs | 0.0215 μs | 0.1507 |   4.21 KB |
