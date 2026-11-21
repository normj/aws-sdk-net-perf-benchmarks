```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.66 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.987 μs | 0.0352 μs | 0.0209 μs | 0.1442 |   4.29 KB |
| Sign_S3GetWithQuery        | 5.596 μs | 0.0228 μs | 0.0151 μs | 0.1563 |   4.51 KB |
| Presign_S3GetObject        | 6.408 μs | 0.0218 μs | 0.0130 μs | 0.2569 |   7.16 KB |
| Sign_RestJsonPathResources | 6.688 μs | 0.0455 μs | 0.0301 μs | 0.1888 |    5.4 KB |
| Sign_S3GetObjectKey        | 5.423 μs | 0.0182 μs | 0.0095 μs | 0.1524 |   4.44 KB |
