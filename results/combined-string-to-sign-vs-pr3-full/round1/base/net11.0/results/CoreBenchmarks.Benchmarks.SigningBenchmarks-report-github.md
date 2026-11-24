```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.76 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.895 μs | 0.0327 μs | 0.0194 μs | 0.1180 |   3.73 KB |
| Sign_S3GetWithQuery        | 5.290 μs | 0.0365 μs | 0.0217 μs | 0.1269 |   3.98 KB |
| Presign_S3GetObject        | 6.067 μs | 0.0421 μs | 0.0279 μs | 0.2387 |   6.63 KB |
| Sign_RestJsonPathResources | 6.666 μs | 0.0506 μs | 0.0335 μs | 0.1574 |   4.86 KB |
| Sign_S3GetObjectKey        | 5.307 μs | 0.0354 μs | 0.0234 μs | 0.1261 |   3.91 KB |
| Sign_JsonPostPooledBody    | 6.635 μs | 0.0655 μs | 0.0433 μs | 0.1860 |   5.62 KB |
| Sign_S3PutTrailingChecksum | 6.631 μs | 0.0569 μs | 0.0377 μs | 0.1848 |   5.31 KB |
