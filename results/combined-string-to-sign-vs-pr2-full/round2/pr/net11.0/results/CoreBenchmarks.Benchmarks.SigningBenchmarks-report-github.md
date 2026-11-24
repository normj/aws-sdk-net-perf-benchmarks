```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.73 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.008 μs | 0.0558 μs | 0.0332 μs | 0.0716 |   2.43 KB |
| Sign_S3GetWithQuery        | 5.519 μs | 0.0258 μs | 0.0171 μs | 0.0885 |   2.88 KB |
| Presign_S3GetObject        | 6.525 μs | 0.0319 μs | 0.0190 μs | 0.1824 |   5.59 KB |
| Sign_RestJsonPathResources | 6.694 μs | 0.0473 μs | 0.0313 μs | 0.1073 |   3.58 KB |
| Sign_S3GetObjectKey        | 5.303 μs | 0.0307 μs | 0.0203 μs | 0.1067 |   2.98 KB |
| Sign_JsonPostPooledBody    | 6.757 μs | 0.0402 μs | 0.0239 μs | 0.1358 |   4.31 KB |
| Sign_S3PutTrailingChecksum | 6.653 μs | 0.0268 μs | 0.0140 μs | 0.1331 |   3.88 KB |
