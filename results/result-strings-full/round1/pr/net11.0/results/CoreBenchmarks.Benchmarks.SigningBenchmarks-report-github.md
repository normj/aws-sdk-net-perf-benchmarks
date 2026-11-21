```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.13 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.040 μs | 0.0439 μs | 0.0290 μs | 0.1450 |   4.14 KB |
| Sign_S3GetWithQuery        | 5.672 μs | 0.0367 μs | 0.0218 μs | 0.1363 |   4.36 KB |
| Presign_S3GetObject        | 6.183 μs | 0.0559 μs | 0.0370 μs | 0.1973 |   6.01 KB |
| Sign_RestJsonPathResources | 6.708 μs | 0.0427 μs | 0.0254 μs | 0.1879 |   5.25 KB |
| Sign_S3GetObjectKey        | 5.429 μs | 0.0237 μs | 0.0156 μs | 0.1513 |   4.29 KB |
