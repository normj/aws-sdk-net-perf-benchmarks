```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.59 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.172 μs | 0.0408 μs | 0.0270 μs | 0.1476 |   4.29 KB |
| Sign_S3GetWithQuery        | 5.668 μs | 0.0507 μs | 0.0335 μs | 0.1580 |   4.51 KB |
| Presign_S3GetObject        | 6.545 μs | 0.0347 μs | 0.0206 μs | 0.2354 |   7.16 KB |
| Sign_RestJsonPathResources | 6.807 μs | 0.0151 μs | 0.0090 μs | 0.1900 |    5.4 KB |
| Sign_S3GetObjectKey        | 5.549 μs | 0.0388 μs | 0.0203 μs | 0.1549 |   4.44 KB |
| Sign_JsonPostPooledBody    | 6.862 μs | 0.0554 μs | 0.0366 μs | 0.2192 |   6.17 KB |
| Sign_S3PutTrailingChecksum | 6.830 μs | 0.0365 μs | 0.0242 μs | 0.1921 |   5.84 KB |
