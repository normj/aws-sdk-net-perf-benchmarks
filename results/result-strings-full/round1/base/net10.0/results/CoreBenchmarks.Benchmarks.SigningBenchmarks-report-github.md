```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.52 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.046 μs | 0.0816 μs | 0.0485 μs | 0.1451 |   4.29 KB |
| Sign_S3GetWithQuery        | 5.713 μs | 0.1133 μs | 0.0674 μs | 0.1570 |   4.51 KB |
| Presign_S3GetObject        | 6.412 μs | 0.0355 μs | 0.0235 μs | 0.2556 |   7.16 KB |
| Sign_RestJsonPathResources | 6.713 μs | 0.0334 μs | 0.0221 μs | 0.1876 |    5.4 KB |
| Sign_S3GetObjectKey        | 5.449 μs | 0.0046 μs | 0.0024 μs | 0.1526 |   4.44 KB |
