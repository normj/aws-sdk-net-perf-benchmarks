```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.16 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.026 μs | 0.0223 μs | 0.0148 μs | 0.1444 |   4.29 KB |
| Sign_S3GetWithQuery        | 5.568 μs | 0.0376 μs | 0.0223 μs | 0.1564 |   4.51 KB |
| Presign_S3GetObject        | 6.398 μs | 0.0662 μs | 0.0394 μs | 0.2535 |   7.16 KB |
| Sign_RestJsonPathResources | 6.707 μs | 0.0599 μs | 0.0396 μs | 0.1865 |    5.4 KB |
| Sign_S3GetObjectKey        | 5.392 μs | 0.0112 μs | 0.0067 μs | 0.1505 |   4.44 KB |
