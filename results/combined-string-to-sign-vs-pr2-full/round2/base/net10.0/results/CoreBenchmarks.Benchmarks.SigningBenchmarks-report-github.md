```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.77 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.952 μs | 0.0351 μs | 0.0232 μs | 0.0953 |   2.98 KB |
| Sign_S3GetWithQuery        | 5.548 μs | 0.0193 μs | 0.0115 μs | 0.1111 |   3.41 KB |
| Presign_S3GetObject        | 6.401 μs | 0.0618 μs | 0.0409 μs | 0.2042 |   6.12 KB |
| Sign_RestJsonPathResources | 6.620 μs | 0.0639 μs | 0.0423 μs | 0.1317 |   4.12 KB |
| Sign_S3GetObjectKey        | 5.390 μs | 0.0169 μs | 0.0101 μs | 0.1079 |    3.5 KB |
| Sign_JsonPostPooledBody    | 6.887 μs | 0.0713 μs | 0.0472 μs | 0.1607 |   4.87 KB |
| Sign_S3PutTrailingChecksum | 6.919 μs | 0.0178 μs | 0.0106 μs | 0.1379 |    4.4 KB |
