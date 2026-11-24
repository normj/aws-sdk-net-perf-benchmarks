```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.76 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.101 μs | 0.0310 μs | 0.0184 μs | 0.1465 |   4.29 KB |
| Sign_S3GetWithQuery        | 5.662 μs | 0.0274 μs | 0.0163 μs | 0.1587 |   4.51 KB |
| Presign_S3GetObject        | 6.517 μs | 0.0441 μs | 0.0292 μs | 0.2346 |   7.16 KB |
| Sign_RestJsonPathResources | 6.720 μs | 0.0306 μs | 0.0182 μs | 0.1908 |    5.4 KB |
| Sign_S3GetObjectKey        | 5.420 μs | 0.0257 μs | 0.0153 μs | 0.1513 |   4.44 KB |
| Sign_JsonPostPooledBody    | 6.743 μs | 0.0463 μs | 0.0306 μs | 0.2168 |   6.17 KB |
| Sign_S3PutTrailingChecksum | 6.779 μs | 0.0521 μs | 0.0345 μs | 0.1891 |   5.84 KB |
