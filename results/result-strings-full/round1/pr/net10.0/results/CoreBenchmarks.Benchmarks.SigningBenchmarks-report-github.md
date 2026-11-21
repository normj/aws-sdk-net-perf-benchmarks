```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.39GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.12 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.954 μs | 0.0280 μs | 0.0166 μs | 0.1426 |   4.14 KB |
| Sign_S3GetWithQuery        | 5.519 μs | 0.0300 μs | 0.0199 μs | 0.1550 |   4.36 KB |
| Presign_S3GetObject        | 5.860 μs | 0.0311 μs | 0.0206 μs | 0.2115 |   6.01 KB |
| Sign_RestJsonPathResources | 6.720 μs | 0.0561 μs | 0.0371 μs | 0.1881 |   5.25 KB |
| Sign_S3GetObjectKey        | 5.452 μs | 0.0149 μs | 0.0089 μs | 0.1529 |   4.29 KB |
