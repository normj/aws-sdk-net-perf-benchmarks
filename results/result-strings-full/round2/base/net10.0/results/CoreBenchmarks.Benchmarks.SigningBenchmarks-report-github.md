```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.14 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.991 μs | 0.0463 μs | 0.0276 μs | 0.1435 |   4.29 KB |
| Sign_S3GetWithQuery        | 5.599 μs | 0.0159 μs | 0.0095 μs | 0.1571 |   4.51 KB |
| Presign_S3GetObject        | 6.449 μs | 0.0359 μs | 0.0188 μs | 0.2567 |   7.16 KB |
| Sign_RestJsonPathResources | 6.690 μs | 0.0536 μs | 0.0355 μs | 0.1865 |    5.4 KB |
| Sign_S3GetObjectKey        | 5.401 μs | 0.0466 μs | 0.0308 μs | 0.1506 |   4.44 KB |
