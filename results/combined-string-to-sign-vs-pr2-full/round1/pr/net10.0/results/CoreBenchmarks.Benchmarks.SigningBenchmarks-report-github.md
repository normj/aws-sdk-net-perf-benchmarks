```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.76 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.933 μs | 0.0763 μs | 0.0454 μs | 0.0699 |   2.43 KB |
| Sign_S3GetWithQuery        | 5.491 μs | 0.0190 μs | 0.0126 μs | 0.0875 |   2.88 KB |
| Presign_S3GetObject        | 6.044 μs | 0.0309 μs | 0.0205 μs | 0.1976 |   5.59 KB |
| Sign_RestJsonPathResources | 6.574 μs | 0.1113 μs | 0.0662 μs | 0.1039 |   3.58 KB |
| Sign_S3GetObjectKey        | 5.277 μs | 0.0624 μs | 0.0371 μs | 0.1049 |   2.98 KB |
| Sign_JsonPostPooledBody    | 6.548 μs | 0.0260 μs | 0.0155 μs | 0.1321 |   4.31 KB |
| Sign_S3PutTrailingChecksum | 6.521 μs | 0.0210 μs | 0.0125 μs | 0.1314 |   3.88 KB |
