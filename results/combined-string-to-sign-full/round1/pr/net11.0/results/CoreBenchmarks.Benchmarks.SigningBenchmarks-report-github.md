```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.42GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.72 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.632 μs | 0.0318 μs | 0.0210 μs | 0.0674 |   2.43 KB |
| Sign_S3GetWithQuery        | 5.425 μs | 0.0537 μs | 0.0355 μs | 0.0856 |   2.88 KB |
| Presign_S3GetObject        | 6.318 μs | 0.0488 μs | 0.0323 μs | 0.2013 |   5.59 KB |
| Sign_RestJsonPathResources | 6.694 μs | 0.1023 μs | 0.0676 μs | 0.1072 |   3.58 KB |
| Sign_S3GetObjectKey        | 5.214 μs | 0.0398 μs | 0.0263 μs | 0.1058 |   2.98 KB |
| Sign_JsonPostPooledBody    | 6.342 μs | 0.0407 μs | 0.0242 μs | 0.1306 |   4.31 KB |
| Sign_S3PutTrailingChecksum | 6.312 μs | 0.0270 μs | 0.0161 μs | 0.1260 |   3.88 KB |
