```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.77 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.865 μs | 0.0379 μs | 0.0251 μs | 0.0707 |   2.43 KB |
| Sign_S3GetWithQuery        | 5.507 μs | 0.0117 μs | 0.0069 μs | 0.0881 |   2.88 KB |
| Presign_S3GetObject        | 6.331 μs | 0.0462 μs | 0.0275 μs | 0.2020 |   5.59 KB |
| Sign_RestJsonPathResources | 6.668 μs | 0.0313 μs | 0.0207 μs | 0.1067 |   3.58 KB |
| Sign_S3GetObjectKey        | 5.362 μs | 0.0273 μs | 0.0162 μs | 0.0872 |   2.98 KB |
| Sign_JsonPostPooledBody    | 6.773 μs | 0.0476 μs | 0.0283 μs | 0.1352 |   4.31 KB |
| Sign_S3PutTrailingChecksum | 6.695 μs | 0.0326 μs | 0.0216 μs | 0.1331 |   3.88 KB |
