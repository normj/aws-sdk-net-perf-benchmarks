```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.63 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.993 μs | 0.0113 μs | 0.0067 μs | 0.1443 |   4.29 KB |
| Sign_S3GetWithQuery        | 5.558 μs | 0.0272 μs | 0.0180 μs | 0.1556 |   4.51 KB |
| Presign_S3GetObject        | 6.502 μs | 0.0457 μs | 0.0272 μs | 0.2347 |   7.16 KB |
| Sign_RestJsonPathResources | 6.647 μs | 0.0538 μs | 0.0356 μs | 0.1874 |    5.4 KB |
| Sign_S3GetObjectKey        | 5.359 μs | 0.0132 μs | 0.0069 μs | 0.1501 |   4.44 KB |
