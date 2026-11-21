```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.76 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.254 μs | 0.1236 μs | 0.0735 μs | 0.1526 |   4.29 KB |
| Sign_S3GetWithQuery        | 5.700 μs | 0.0647 μs | 0.0428 μs | 0.1596 |   4.51 KB |
| Presign_S3GetObject        | 6.758 μs | 0.1013 μs | 0.0530 μs | 0.2402 |   7.16 KB |
| Sign_RestJsonPathResources | 6.815 μs | 0.1070 μs | 0.0637 μs | 0.1902 |    5.4 KB |
| Sign_S3GetObjectKey        | 5.534 μs | 0.1048 μs | 0.0693 μs | 0.1542 |   4.44 KB |
