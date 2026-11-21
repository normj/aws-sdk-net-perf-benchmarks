```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.26 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.088 μs | 0.1559 μs | 0.0405 μs | 0.1456 |   4.29 KB |
| Sign_S3GetWithQuery        | 5.684 μs | 0.0808 μs | 0.0210 μs | 0.1594 |   4.51 KB |
| Presign_S3GetObject        | 6.582 μs | 0.0739 μs | 0.0192 μs | 0.2358 |   7.16 KB |
| Sign_RestJsonPathResources | 6.776 μs | 0.1027 μs | 0.0267 μs | 0.1891 |    5.4 KB |
| Sign_S3GetObjectKey        | 5.462 μs | 0.0377 μs | 0.0135 μs | 0.1524 |   4.44 KB |
