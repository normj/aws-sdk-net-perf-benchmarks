```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.34 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.144 μs | 0.0488 μs | 0.0255 μs | 0.1489 |   4.29 KB |
| Sign_S3GetWithQuery        | 5.677 μs | 0.1162 μs | 0.0691 μs | 0.1587 |   4.51 KB |
| Presign_S3GetObject        | 6.367 μs | 0.0444 μs | 0.0232 μs | 0.2584 |   7.16 KB |
| Sign_RestJsonPathResources | 6.711 μs | 0.0359 μs | 0.0237 μs | 0.1894 |    5.4 KB |
| Sign_S3GetObjectKey        | 5.390 μs | 0.0400 μs | 0.0238 μs | 0.1502 |   4.44 KB |
