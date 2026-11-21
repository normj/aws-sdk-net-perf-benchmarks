```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.65 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.026 μs | 0.0474 μs | 0.0314 μs | 0.1209 |   3.91 KB |
| Sign_S3GetWithQuery        | 5.553 μs | 0.0761 μs | 0.0503 μs | 0.1542 |   4.28 KB |
| Presign_S3GetObject        | 6.683 μs | 0.1782 μs | 0.1179 μs | 0.2430 |    7.1 KB |
| Sign_RestJsonPathResources | 6.578 μs | 0.0348 μs | 0.0207 μs | 0.1589 |   5.07 KB |
| Sign_S3GetObjectKey        | 5.356 μs | 0.0329 μs | 0.0217 μs | 0.1490 |   4.21 KB |
