```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.72 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.118 μs | 0.0589 μs | 0.0389 μs | 0.1463 |   4.29 KB |
| Sign_S3GetWithQuery        | 5.567 μs | 0.0285 μs | 0.0170 μs | 0.1561 |   4.51 KB |
| Presign_S3GetObject        | 6.471 μs | 0.0258 μs | 0.0171 μs | 0.2589 |   7.16 KB |
| Sign_RestJsonPathResources | 6.783 μs | 0.0294 μs | 0.0154 μs | 0.1886 |    5.4 KB |
| Sign_S3GetObjectKey        | 5.444 μs | 0.0181 μs | 0.0108 μs | 0.1531 |   4.44 KB |
| Sign_JsonPostPooledBody    | 6.813 μs | 0.0494 μs | 0.0327 μs | 0.2196 |   6.17 KB |
| Sign_S3PutTrailingChecksum | 6.678 μs | 0.0164 μs | 0.0086 μs | 0.1872 |   5.84 KB |
