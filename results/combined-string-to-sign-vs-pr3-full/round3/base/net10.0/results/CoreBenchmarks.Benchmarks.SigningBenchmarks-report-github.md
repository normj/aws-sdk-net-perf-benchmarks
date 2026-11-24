```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.34 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.981 μs | 0.0353 μs | 0.0233 μs | 0.1196 |   3.73 KB |
| Sign_S3GetWithQuery        | 5.519 μs | 0.0456 μs | 0.0271 μs | 0.1321 |   3.98 KB |
| Presign_S3GetObject        | 6.449 μs | 0.0739 μs | 0.0489 μs | 0.2315 |   6.63 KB |
| Sign_RestJsonPathResources | 6.754 μs | 0.0314 μs | 0.0187 μs | 0.1617 |   4.86 KB |
| Sign_S3GetObjectKey        | 5.365 μs | 0.0278 μs | 0.0166 μs | 0.1277 |   3.91 KB |
| Sign_JsonPostPooledBody    | 6.663 μs | 0.0510 μs | 0.0337 μs | 0.1870 |   5.62 KB |
| Sign_S3PutTrailingChecksum | 6.514 μs | 0.0620 μs | 0.0369 μs | 0.1857 |   5.31 KB |
