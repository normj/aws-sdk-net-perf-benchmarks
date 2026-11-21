```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.11 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.031 μs | 0.0492 μs | 0.0326 μs | 0.1420 |   3.91 KB |
| Sign_S3GetWithQuery        | 5.692 μs | 0.0759 μs | 0.0451 μs | 0.1541 |   4.28 KB |
| Presign_S3GetObject        | 6.686 μs | 0.0800 μs | 0.0529 μs | 0.2419 |    7.1 KB |
| Sign_RestJsonPathResources | 6.676 μs | 0.0734 μs | 0.0486 μs | 0.1618 |   5.07 KB |
| Sign_S3GetObjectKey        | 5.374 μs | 0.0349 μs | 0.0208 μs | 0.1506 |   4.21 KB |
