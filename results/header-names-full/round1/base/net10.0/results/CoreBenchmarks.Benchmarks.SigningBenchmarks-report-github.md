```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.42 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.104 μs | 0.1026 μs | 0.0679 μs | 0.1447 |   4.29 KB |
| Sign_S3GetWithQuery        | 5.862 μs | 0.2774 μs | 0.1835 μs | 0.1601 |   4.51 KB |
| Presign_S3GetObject        | 6.465 μs | 0.0418 μs | 0.0219 μs | 0.2352 |   7.16 KB |
| Sign_RestJsonPathResources | 6.833 μs | 0.0594 μs | 0.0311 μs | 0.1932 |    5.4 KB |
| Sign_S3GetObjectKey        | 6.592 μs | 0.9020 μs | 0.5966 μs | 0.1544 |   4.44 KB |
