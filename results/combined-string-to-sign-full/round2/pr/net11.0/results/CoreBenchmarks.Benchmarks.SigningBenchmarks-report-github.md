```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.74 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.627 μs | 0.0150 μs | 0.0089 μs | 0.0674 |   2.43 KB |
| Sign_S3GetWithQuery        | 5.243 μs | 0.0235 μs | 0.0123 μs | 0.0841 |   2.88 KB |
| Presign_S3GetObject        | 6.013 μs | 0.1336 μs | 0.0795 μs | 0.1916 |   5.59 KB |
| Sign_RestJsonPathResources | 6.375 μs | 0.0142 μs | 0.0084 μs | 0.1276 |   3.58 KB |
| Sign_S3GetObjectKey        | 5.074 μs | 0.0173 μs | 0.0103 μs | 0.1026 |   2.98 KB |
| Sign_JsonPostPooledBody    | 6.392 μs | 0.0465 μs | 0.0277 μs | 0.1531 |   4.31 KB |
| Sign_S3PutTrailingChecksum | 6.312 μs | 0.0230 μs | 0.0152 μs | 0.1257 |   3.88 KB |
