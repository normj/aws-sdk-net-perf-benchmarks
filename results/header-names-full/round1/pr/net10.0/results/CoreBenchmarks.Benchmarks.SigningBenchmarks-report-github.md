```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.38 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.013 μs | 0.0663 μs | 0.0438 μs | 0.1204 |   3.91 KB |
| Sign_S3GetWithQuery        | 5.551 μs | 0.0852 μs | 0.0563 μs | 0.1337 |   4.28 KB |
| Presign_S3GetObject        | 6.370 μs | 0.0228 μs | 0.0135 μs | 0.2542 |    7.1 KB |
| Sign_RestJsonPathResources | 6.556 μs | 0.0490 μs | 0.0291 μs | 0.1584 |   5.07 KB |
| Sign_S3GetObjectKey        | 5.382 μs | 0.0489 μs | 0.0323 μs | 0.1499 |   4.21 KB |
