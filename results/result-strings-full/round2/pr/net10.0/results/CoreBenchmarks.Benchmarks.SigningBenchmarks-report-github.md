```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.18 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.942 μs | 0.0486 μs | 0.0289 μs | 0.1419 |   4.14 KB |
| Sign_S3GetWithQuery        | 5.567 μs | 0.0392 μs | 0.0233 μs | 0.1549 |   4.36 KB |
| Presign_S3GetObject        | 5.710 μs | 0.0150 μs | 0.0078 μs | 0.2066 |   6.01 KB |
| Sign_RestJsonPathResources | 6.656 μs | 0.0266 μs | 0.0139 μs | 0.1859 |   5.25 KB |
| Sign_S3GetObjectKey        | 5.420 μs | 0.0278 μs | 0.0166 μs | 0.1525 |   4.29 KB |
