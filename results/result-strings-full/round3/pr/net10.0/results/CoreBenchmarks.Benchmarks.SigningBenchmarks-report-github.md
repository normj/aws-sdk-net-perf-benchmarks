```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.76 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.893 μs | 0.0510 μs | 0.0304 μs | 0.1411 |   4.14 KB |
| Sign_S3GetWithQuery        | 5.537 μs | 0.0440 μs | 0.0291 μs | 0.1541 |   4.36 KB |
| Presign_S3GetObject        | 5.804 μs | 0.0244 μs | 0.0145 μs | 0.2088 |   6.01 KB |
| Sign_RestJsonPathResources | 6.622 μs | 0.0285 μs | 0.0149 μs | 0.1850 |   5.25 KB |
| Sign_S3GetObjectKey        | 5.437 μs | 0.0305 μs | 0.0182 μs | 0.1527 |   4.29 KB |
