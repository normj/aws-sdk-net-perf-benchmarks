```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.08 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.113 μs | 0.0385 μs | 0.0229 μs | 0.1290 |   3.91 KB |
| Sign_S3GetWithQuery        | 5.687 μs | 0.0673 μs | 0.0400 μs | 0.1382 |   4.28 KB |
| Presign_S3GetObject        | 6.801 μs | 0.1108 μs | 0.0733 μs | 0.2528 |    7.1 KB |
| Sign_RestJsonPathResources | 6.816 μs | 0.0643 μs | 0.0382 μs | 0.1653 |   5.07 KB |
| Sign_S3GetObjectKey        | 6.385 μs | 2.1347 μs | 1.4120 μs | 0.1330 |   4.21 KB |
