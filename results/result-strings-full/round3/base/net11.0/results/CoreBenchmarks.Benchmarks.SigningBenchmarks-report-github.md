```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.77 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.076 μs | 0.0422 μs | 0.0251 μs | 0.1461 |   4.29 KB |
| Sign_S3GetWithQuery        | 5.620 μs | 0.0255 μs | 0.0152 μs | 0.1578 |   4.51 KB |
| Presign_S3GetObject        | 6.527 μs | 0.0471 μs | 0.0312 μs | 0.2349 |   7.16 KB |
| Sign_RestJsonPathResources | 6.787 μs | 0.0279 μs | 0.0166 μs | 0.1894 |    5.4 KB |
| Sign_S3GetObjectKey        | 5.413 μs | 0.0302 μs | 0.0180 μs | 0.1508 |   4.44 KB |
