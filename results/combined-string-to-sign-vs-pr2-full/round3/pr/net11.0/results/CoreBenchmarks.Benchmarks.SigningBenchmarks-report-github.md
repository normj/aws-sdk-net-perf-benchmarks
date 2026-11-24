```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.65 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.778 μs | 0.0323 μs | 0.0213 μs | 0.0695 |   2.43 KB |
| Sign_S3GetWithQuery        | 5.345 μs | 0.0423 μs | 0.0252 μs | 0.0857 |   2.88 KB |
| Presign_S3GetObject        | 6.279 μs | 0.0436 μs | 0.0289 μs | 0.2007 |   5.59 KB |
| Sign_RestJsonPathResources | 6.548 μs | 0.0201 μs | 0.0133 μs | 0.1297 |   3.58 KB |
| Sign_S3GetObjectKey        | 5.161 μs | 0.0403 μs | 0.0267 μs | 0.1037 |   2.98 KB |
| Sign_JsonPostPooledBody    | 6.639 μs | 0.0394 μs | 0.0261 μs | 0.1324 |   4.31 KB |
| Sign_S3PutTrailingChecksum | 6.508 μs | 0.0281 μs | 0.0167 μs | 0.1300 |   3.88 KB |
