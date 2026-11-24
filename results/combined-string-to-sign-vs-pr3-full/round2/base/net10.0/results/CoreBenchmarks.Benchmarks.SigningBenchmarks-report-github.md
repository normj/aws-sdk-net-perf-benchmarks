```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.74 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.973 μs | 0.0414 μs | 0.0246 μs | 0.1192 |   3.73 KB |
| Sign_S3GetWithQuery        | 5.619 μs | 0.0312 μs | 0.0207 μs | 0.1349 |   3.98 KB |
| Presign_S3GetObject        | 6.531 μs | 0.0204 μs | 0.0121 μs | 0.2332 |   6.63 KB |
| Sign_RestJsonPathResources | 6.704 μs | 0.0254 μs | 0.0151 μs | 0.1608 |   4.86 KB |
| Sign_S3GetObjectKey        | 5.410 μs | 0.0235 μs | 0.0156 μs | 0.1295 |   3.91 KB |
| Sign_JsonPostPooledBody    | 6.844 μs | 0.0374 μs | 0.0195 μs | 0.1925 |   5.62 KB |
| Sign_S3PutTrailingChecksum | 6.780 μs | 0.0599 μs | 0.0396 μs | 0.1901 |   5.31 KB |
