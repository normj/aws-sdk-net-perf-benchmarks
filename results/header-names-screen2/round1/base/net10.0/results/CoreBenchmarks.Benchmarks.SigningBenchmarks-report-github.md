```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.53 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 7.427 μs | 2.2914 μs | 0.8171 μs | 0.1447 |   4.29 KB |
| Sign_S3GetWithQuery        | 6.114 μs | 0.3671 μs | 0.1309 μs | 0.1603 |   4.51 KB |
| Sign_RestJsonPathResources | 7.071 μs | 0.2186 μs | 0.0780 μs | 0.1811 |    5.4 KB |
| Sign_S3GetObjectKey        | 5.824 μs | 0.2239 μs | 0.0582 μs | 0.1577 |   4.44 KB |
