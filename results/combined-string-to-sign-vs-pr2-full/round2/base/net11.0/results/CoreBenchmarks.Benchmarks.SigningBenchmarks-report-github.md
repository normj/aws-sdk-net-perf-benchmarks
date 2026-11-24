```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.73 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.180 μs | 0.0232 μs | 0.0122 μs | 0.0987 |   2.98 KB |
| Sign_S3GetWithQuery        | 5.781 μs | 0.0106 μs | 0.0063 μs | 0.1147 |   3.41 KB |
| Presign_S3GetObject        | 6.720 μs | 0.0632 μs | 0.0418 μs | 0.2153 |   6.12 KB |
| Sign_RestJsonPathResources | 6.898 μs | 0.0809 μs | 0.0535 μs | 0.1380 |   4.12 KB |
| Sign_S3GetObjectKey        | 5.689 μs | 0.0170 μs | 0.0101 μs | 0.1135 |    3.5 KB |
| Sign_JsonPostPooledBody    | 7.120 μs | 0.0192 μs | 0.0127 μs | 0.1693 |   4.87 KB |
| Sign_S3PutTrailingChecksum | 7.009 μs | 0.0171 μs | 0.0102 μs | 0.1409 |    4.4 KB |
