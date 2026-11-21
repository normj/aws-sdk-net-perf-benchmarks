```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.68 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.130 μs | 0.0366 μs | 0.0218 μs | 0.1507 |   4.29 KB |
| Sign_S3GetWithQuery        | 5.767 μs | 0.1052 μs | 0.0696 μs | 0.1618 |   4.51 KB |
| Presign_S3GetObject        | 6.948 μs | 0.1193 μs | 0.0789 μs | 0.2457 |   7.16 KB |
| Sign_RestJsonPathResources | 7.249 μs | 0.6349 μs | 0.3778 μs | 0.1747 |    5.4 KB |
| Sign_S3GetObjectKey        | 5.694 μs | 0.1656 μs | 0.0866 μs | 0.1600 |   4.44 KB |
