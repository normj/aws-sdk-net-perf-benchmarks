```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.91 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean      | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |----------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              |  8.610 μs | 1.4575 μs | 0.9641 μs | 0.0723 |   2.43 KB |
| Sign_S3GetWithQuery        |  8.110 μs | 0.7879 μs | 0.5212 μs | 0.0967 |   2.88 KB |
| Presign_S3GetObject        | 11.292 μs | 4.6497 μs | 3.0755 μs | 0.1814 |   5.59 KB |
| Sign_RestJsonPathResources | 10.064 μs | 0.6040 μs | 0.3995 μs | 0.1289 |   3.58 KB |
| Sign_S3GetObjectKey        |  5.238 μs | 0.0577 μs | 0.0343 μs | 0.1066 |   2.98 KB |
| Sign_JsonPostPooledBody    |  6.557 μs | 0.0145 μs | 0.0076 μs | 0.1322 |   4.31 KB |
| Sign_S3PutTrailingChecksum |  6.486 μs | 0.0694 μs | 0.0459 μs | 0.1292 |   3.88 KB |
