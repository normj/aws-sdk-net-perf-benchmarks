```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.6 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.256 μs | 0.3105 μs | 0.1848 μs | 0.1464 |   4.29 KB |
| Sign_S3GetWithQuery        | 5.630 μs | 0.0577 μs | 0.0343 μs | 0.1606 |   4.51 KB |
| Presign_S3GetObject        | 6.725 μs | 0.1991 μs | 0.1317 μs | 0.2583 |   7.16 KB |
| Sign_RestJsonPathResources | 6.746 μs | 0.0735 μs | 0.0384 μs | 0.1719 |    5.4 KB |
| Sign_S3GetObjectKey        | 5.431 μs | 0.0286 μs | 0.0189 μs | 0.1516 |   4.44 KB |
| Sign_JsonPostPooledBody    | 6.777 μs | 0.0434 μs | 0.0287 μs | 0.2176 |   6.17 KB |
| Sign_S3PutTrailingChecksum | 6.724 μs | 0.0472 μs | 0.0312 μs | 0.1909 |   5.84 KB |
