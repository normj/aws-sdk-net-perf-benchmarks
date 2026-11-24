```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.7 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.070 μs | 0.0680 μs | 0.0450 μs | 0.1459 |   4.29 KB |
| Sign_S3GetWithQuery        | 5.602 μs | 0.0342 μs | 0.0203 μs | 0.1572 |   4.51 KB |
| Presign_S3GetObject        | 6.455 μs | 0.0304 μs | 0.0181 μs | 0.2572 |   7.16 KB |
| Sign_RestJsonPathResources | 6.665 μs | 0.0393 μs | 0.0260 μs | 0.1865 |    5.4 KB |
| Sign_S3GetObjectKey        | 5.988 μs | 0.0546 μs | 0.0361 μs | 0.1573 |   4.44 KB |
| Sign_JsonPostPooledBody    | 6.922 μs | 0.0409 μs | 0.0271 μs | 0.2184 |   6.17 KB |
| Sign_S3PutTrailingChecksum | 7.528 μs | 0.1132 μs | 0.0749 μs | 0.2087 |   5.84 KB |
