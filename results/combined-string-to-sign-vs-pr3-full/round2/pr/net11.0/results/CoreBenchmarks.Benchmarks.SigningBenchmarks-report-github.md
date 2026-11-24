```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.36 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.970 μs | 0.0479 μs | 0.0285 μs | 0.0697 |   2.43 KB |
| Sign_S3GetWithQuery        | 5.334 μs | 0.0260 μs | 0.0155 μs | 0.0863 |   2.88 KB |
| Presign_S3GetObject        | 6.149 μs | 0.0524 μs | 0.0312 μs | 0.1962 |   5.59 KB |
| Sign_RestJsonPathResources | 6.549 μs | 0.0269 μs | 0.0178 μs | 0.1045 |   3.58 KB |
| Sign_S3GetObjectKey        | 5.251 μs | 0.0093 μs | 0.0056 μs | 0.1042 |   2.98 KB |
| Sign_JsonPostPooledBody    | 6.684 μs | 0.0294 μs | 0.0194 μs | 0.1341 |   4.31 KB |
| Sign_S3PutTrailingChecksum | 6.505 μs | 0.0253 μs | 0.0151 μs | 0.1300 |   3.88 KB |
