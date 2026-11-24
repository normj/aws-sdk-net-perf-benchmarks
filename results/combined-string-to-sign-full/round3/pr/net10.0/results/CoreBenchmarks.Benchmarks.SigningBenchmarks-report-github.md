```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.07 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.770 μs | 0.0448 μs | 0.0296 μs | 0.0706 |   2.43 KB |
| Sign_S3GetWithQuery        | 5.286 μs | 0.0157 μs | 0.0093 μs | 0.0846 |   2.88 KB |
| Presign_S3GetObject        | 6.059 μs | 0.0402 μs | 0.0266 μs | 0.1927 |   5.59 KB |
| Sign_RestJsonPathResources | 6.528 μs | 0.0794 μs | 0.0525 μs | 0.1043 |   3.58 KB |
| Sign_S3GetObjectKey        | 5.087 μs | 0.0118 μs | 0.0061 μs | 0.1021 |   2.98 KB |
| Sign_JsonPostPooledBody    | 6.553 μs | 0.0329 μs | 0.0196 μs | 0.1316 |   4.31 KB |
| Sign_S3PutTrailingChecksum | 6.388 μs | 0.0342 μs | 0.0204 μs | 0.1296 |   3.88 KB |
