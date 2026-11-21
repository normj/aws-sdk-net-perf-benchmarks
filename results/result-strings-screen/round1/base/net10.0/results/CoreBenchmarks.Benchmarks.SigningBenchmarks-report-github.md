```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.17 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.292 μs | 0.1795 μs | 0.0640 μs | 0.1512 |   4.29 KB |
| Sign_S3GetWithQuery        | 5.769 μs | 0.1421 μs | 0.0507 μs | 0.1619 |   4.51 KB |
| Presign_S3GetObject        | 6.551 μs | 0.2106 μs | 0.0751 μs | 0.2337 |   7.16 KB |
| Sign_RestJsonPathResources | 6.862 μs | 0.1904 μs | 0.0679 μs | 0.1932 |    5.4 KB |
| Sign_S3GetObjectKey        | 5.566 μs | 0.0880 μs | 0.0314 μs | 0.1553 |   4.44 KB |
