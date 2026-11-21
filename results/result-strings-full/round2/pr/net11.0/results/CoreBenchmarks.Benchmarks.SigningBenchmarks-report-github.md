```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.03 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.944 μs | 0.0470 μs | 0.0280 μs | 0.1422 |   4.14 KB |
| Sign_S3GetWithQuery        | 5.853 μs | 0.1520 μs | 0.1006 μs | 0.1556 |   4.36 KB |
| Presign_S3GetObject        | 6.151 μs | 0.1675 μs | 0.0996 μs | 0.1947 |   6.01 KB |
| Sign_RestJsonPathResources | 6.661 μs | 0.1391 μs | 0.0920 μs | 0.1851 |   5.25 KB |
| Sign_S3GetObjectKey        | 5.382 μs | 0.0749 μs | 0.0496 μs | 0.1499 |   4.29 KB |
