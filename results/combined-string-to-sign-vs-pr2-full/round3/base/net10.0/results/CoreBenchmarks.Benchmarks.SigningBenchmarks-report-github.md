```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.7 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.173 μs | 0.0464 μs | 0.0307 μs | 0.1007 |   2.98 KB |
| Sign_S3GetWithQuery        | 5.845 μs | 0.0286 μs | 0.0150 μs | 0.1174 |   3.41 KB |
| Presign_S3GetObject        | 6.884 μs | 0.0389 μs | 0.0257 μs | 0.2207 |   6.12 KB |
| Sign_RestJsonPathResources | 7.142 μs | 0.0298 μs | 0.0177 μs | 0.1419 |   4.12 KB |
| Sign_S3GetObjectKey        | 5.691 μs | 0.0275 μs | 0.0182 μs | 0.1137 |    3.5 KB |
| Sign_JsonPostPooledBody    | 7.122 μs | 0.0310 μs | 0.0205 μs | 0.1700 |   4.87 KB |
| Sign_S3PutTrailingChecksum | 7.071 μs | 0.0113 μs | 0.0059 μs | 0.1408 |    4.4 KB |
