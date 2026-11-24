```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.77 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.709 μs | 0.0229 μs | 0.0120 μs | 0.0691 |   2.43 KB |
| Sign_S3GetWithQuery        | 5.264 μs | 0.0192 μs | 0.0114 μs | 0.0844 |   2.88 KB |
| Presign_S3GetObject        | 6.012 μs | 0.0483 μs | 0.0320 μs | 0.1924 |   5.59 KB |
| Sign_RestJsonPathResources | 6.378 μs | 0.0154 μs | 0.0102 μs | 0.1274 |   3.58 KB |
| Sign_S3GetObjectKey        | 5.142 μs | 0.0284 μs | 0.0169 μs | 0.1025 |   2.98 KB |
| Sign_JsonPostPooledBody    | 6.581 μs | 0.0500 μs | 0.0298 μs | 0.1320 |   4.31 KB |
| Sign_S3PutTrailingChecksum | 6.375 μs | 0.0174 μs | 0.0104 μs | 0.1279 |   3.88 KB |
