```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.47 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.992 μs | 0.1289 μs | 0.0460 μs | 0.1193 |   3.91 KB |
| Sign_S3GetWithQuery        | 5.668 μs | 0.3714 μs | 0.0964 μs | 0.1377 |   4.28 KB |
| Sign_RestJsonPathResources | 6.675 μs | 0.3436 μs | 0.1225 μs | 0.1577 |   5.07 KB |
| Sign_S3GetObjectKey        | 5.335 μs | 0.1250 μs | 0.0325 μs | 0.1481 |   4.21 KB |
