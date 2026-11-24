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
| Sign_JsonPost              | 5.969 μs | 0.0148 μs | 0.0077 μs | 0.0715 |   2.43 KB |
| Sign_S3GetWithQuery        | 5.643 μs | 0.0203 μs | 0.0121 μs | 0.0899 |   2.88 KB |
| Presign_S3GetObject        | 6.539 μs | 0.0191 μs | 0.0114 μs | 0.1824 |   5.59 KB |
| Sign_RestJsonPathResources | 6.787 μs | 0.0370 μs | 0.0220 μs | 0.1088 |   3.58 KB |
| Sign_S3GetObjectKey        | 5.469 μs | 0.0350 μs | 0.0208 μs | 0.0872 |   2.98 KB |
| Sign_JsonPostPooledBody    | 6.934 μs | 0.0291 μs | 0.0173 μs | 0.1390 |   4.31 KB |
| Sign_S3PutTrailingChecksum | 6.759 μs | 0.0221 μs | 0.0131 μs | 0.1353 |   3.88 KB |
