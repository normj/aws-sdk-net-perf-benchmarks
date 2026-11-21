```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.62 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.946 μs | 0.0266 μs | 0.0159 μs | 0.1193 |   3.91 KB |
| Sign_S3GetWithQuery        | 5.521 μs | 0.0909 μs | 0.0541 μs | 0.1538 |   4.28 KB |
| Presign_S3GetObject        | 6.390 μs | 0.0385 μs | 0.0255 μs | 0.2526 |    7.1 KB |
| Sign_RestJsonPathResources | 6.715 μs | 0.0508 μs | 0.0336 μs | 0.1607 |   5.07 KB |
| Sign_S3GetObjectKey        | 5.311 μs | 0.0151 μs | 0.0100 μs | 0.1490 |   4.21 KB |
