```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.77 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.835 μs | 0.0388 μs | 0.0257 μs | 0.0701 |   2.43 KB |
| Sign_S3GetWithQuery        | 5.336 μs | 0.0158 μs | 0.0094 μs | 0.0861 |   2.88 KB |
| Presign_S3GetObject        | 6.200 μs | 0.0405 μs | 0.0268 μs | 0.1969 |   5.59 KB |
| Sign_RestJsonPathResources | 6.568 μs | 0.0117 μs | 0.0070 μs | 0.1047 |   3.58 KB |
| Sign_S3GetObjectKey        | 5.187 μs | 0.0188 μs | 0.0124 μs | 0.1034 |   2.98 KB |
| Sign_JsonPostPooledBody    | 6.633 μs | 0.0395 μs | 0.0262 μs | 0.1321 |   4.31 KB |
| Sign_S3PutTrailingChecksum | 6.516 μs | 0.0490 μs | 0.0324 μs | 0.1299 |   3.88 KB |
