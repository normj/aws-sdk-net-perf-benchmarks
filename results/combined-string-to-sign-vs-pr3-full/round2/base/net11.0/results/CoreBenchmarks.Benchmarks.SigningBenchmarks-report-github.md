```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.61 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.983 μs | 0.0494 μs | 0.0327 μs | 0.1195 |   3.73 KB |
| Sign_S3GetWithQuery        | 5.569 μs | 0.0168 μs | 0.0100 μs | 0.1349 |   3.98 KB |
| Presign_S3GetObject        | 6.461 μs | 0.0269 μs | 0.0141 μs | 0.2308 |   6.63 KB |
| Sign_RestJsonPathResources | 6.747 μs | 0.0521 μs | 0.0310 μs | 0.1600 |   4.86 KB |
| Sign_S3GetObjectKey        | 5.327 μs | 0.0604 μs | 0.0359 μs | 0.1302 |   3.91 KB |
| Sign_JsonPostPooledBody    | 6.761 μs | 0.0470 μs | 0.0311 μs | 0.1901 |   5.62 KB |
| Sign_S3PutTrailingChecksum | 6.638 μs | 0.0299 μs | 0.0198 μs | 0.1851 |   5.31 KB |
