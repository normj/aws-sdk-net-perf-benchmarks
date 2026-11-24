```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.09 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.690 μs | 0.0175 μs | 0.0104 μs | 0.0687 |   2.43 KB |
| Sign_S3GetWithQuery        | 5.258 μs | 0.0602 μs | 0.0398 μs | 0.0847 |   2.88 KB |
| Presign_S3GetObject        | 6.152 μs | 0.0567 μs | 0.0375 μs | 0.1947 |   5.59 KB |
| Sign_RestJsonPathResources | 6.543 μs | 0.0284 μs | 0.0169 μs | 0.1044 |   3.58 KB |
| Sign_S3GetObjectKey        | 5.257 μs | 0.0378 μs | 0.0250 μs | 0.1054 |   2.98 KB |
| Sign_JsonPostPooledBody    | 6.588 μs | 0.0148 μs | 0.0077 μs | 0.1309 |   4.31 KB |
| Sign_S3PutTrailingChecksum | 6.573 μs | 0.0324 μs | 0.0193 μs | 0.1315 |   3.88 KB |
