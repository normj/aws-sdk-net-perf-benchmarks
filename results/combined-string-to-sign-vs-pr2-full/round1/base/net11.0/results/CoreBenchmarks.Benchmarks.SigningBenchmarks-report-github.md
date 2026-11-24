```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.8 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.270 μs | 0.0179 μs | 0.0118 μs | 0.1002 |   2.98 KB |
| Sign_S3GetWithQuery        | 5.889 μs | 0.0236 μs | 0.0156 μs | 0.1183 |   3.41 KB |
| Presign_S3GetObject        | 6.416 μs | 0.0237 μs | 0.0157 μs | 0.2172 |   6.12 KB |
| Sign_RestJsonPathResources | 6.647 μs | 0.0358 μs | 0.0213 μs | 0.1328 |   4.12 KB |
| Sign_S3GetObjectKey        | 5.322 μs | 0.0249 μs | 0.0130 μs | 0.1067 |    3.5 KB |
| Sign_JsonPostPooledBody    | 6.890 μs | 0.0577 μs | 0.0343 μs | 0.1608 |   4.87 KB |
| Sign_S3PutTrailingChecksum | 6.853 μs | 0.0144 μs | 0.0075 μs | 0.1356 |    4.4 KB |
