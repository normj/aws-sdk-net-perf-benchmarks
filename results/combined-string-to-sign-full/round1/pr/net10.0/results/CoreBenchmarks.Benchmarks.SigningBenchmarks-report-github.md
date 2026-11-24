```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.66 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.783 μs | 0.0236 μs | 0.0141 μs | 0.0700 |   2.43 KB |
| Sign_S3GetWithQuery        | 5.384 μs | 0.0881 μs | 0.0583 μs | 0.0851 |   2.88 KB |
| Presign_S3GetObject        | 6.505 μs | 0.0448 μs | 0.0266 μs | 0.1955 |   5.59 KB |
| Sign_RestJsonPathResources | 6.754 μs | 0.0717 μs | 0.0427 μs | 0.1079 |   3.58 KB |
| Sign_S3GetObjectKey        | 5.171 μs | 0.0227 μs | 0.0119 μs | 0.1056 |   2.98 KB |
| Sign_JsonPostPooledBody    | 6.663 μs | 0.0806 μs | 0.0480 μs | 0.1307 |   4.31 KB |
| Sign_S3PutTrailingChecksum | 6.698 μs | 0.0351 μs | 0.0232 μs | 0.1322 |   3.88 KB |
