```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.74 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.807 μs | 0.0370 μs | 0.0220 μs | 0.0699 |   2.43 KB |
| Sign_S3GetWithQuery        | 5.374 μs | 0.0641 μs | 0.0424 μs | 0.0852 |   2.88 KB |
| Presign_S3GetObject        | 6.024 μs | 0.0443 μs | 0.0232 μs | 0.1931 |   5.59 KB |
| Sign_RestJsonPathResources | 6.600 μs | 0.0542 μs | 0.0359 μs | 0.1049 |   3.58 KB |
| Sign_S3GetObjectKey        | 5.269 μs | 0.0435 μs | 0.0288 μs | 0.1057 |   2.98 KB |
| Sign_JsonPostPooledBody    | 6.719 μs | 0.0561 μs | 0.0371 μs | 0.1344 |   4.31 KB |
| Sign_S3PutTrailingChecksum | 6.590 μs | 0.0481 μs | 0.0318 μs | 0.1311 |   3.88 KB |
