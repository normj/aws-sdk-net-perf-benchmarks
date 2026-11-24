```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.78 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.304 μs | 0.0544 μs | 0.0360 μs | 0.1011 |   2.98 KB |
| Sign_S3GetWithQuery        | 5.949 μs | 0.0129 μs | 0.0067 μs | 0.1194 |   3.41 KB |
| Presign_S3GetObject        | 7.003 μs | 0.0520 μs | 0.0344 μs | 0.1945 |   6.12 KB |
| Sign_RestJsonPathResources | 7.107 μs | 0.0173 μs | 0.0103 μs | 0.1420 |   4.12 KB |
| Sign_S3GetObjectKey        | 5.792 μs | 0.0202 μs | 0.0106 μs | 0.1154 |    3.5 KB |
| Sign_JsonPostPooledBody    | 7.179 μs | 0.0537 μs | 0.0319 μs | 0.1720 |   4.87 KB |
| Sign_S3PutTrailingChecksum | 7.147 μs | 0.0379 μs | 0.0251 μs | 0.1426 |    4.4 KB |
