```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.51 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.990 μs | 0.0316 μs | 0.0165 μs | 0.1459 |   4.29 KB |
| Sign_S3GetWithQuery        | 5.601 μs | 0.0373 μs | 0.0222 μs | 0.1583 |   4.51 KB |
| Presign_S3GetObject        | 6.468 μs | 0.0493 μs | 0.0293 μs | 0.2579 |   7.16 KB |
| Sign_RestJsonPathResources | 6.727 μs | 0.1066 μs | 0.0705 μs | 0.1869 |    5.4 KB |
| Sign_S3GetObjectKey        | 5.558 μs | 0.5908 μs | 0.3090 μs | 0.1525 |   4.44 KB |
