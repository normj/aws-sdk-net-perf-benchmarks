```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.74 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.999 μs | 0.0909 μs | 0.0476 μs | 0.1207 |   3.73 KB |
| Sign_S3GetWithQuery        | 5.611 μs | 0.0586 μs | 0.0387 μs | 0.1345 |   3.98 KB |
| Presign_S3GetObject        | 6.299 μs | 0.0789 μs | 0.0522 μs | 0.2272 |   6.63 KB |
| Sign_RestJsonPathResources | 6.640 μs | 0.0596 μs | 0.0354 μs | 0.1576 |   4.86 KB |
| Sign_S3GetObjectKey        | 5.365 μs | 0.0258 μs | 0.0171 μs | 0.1289 |   3.91 KB |
| Sign_JsonPostPooledBody    | 6.807 μs | 0.0810 μs | 0.0536 μs | 0.1915 |   5.62 KB |
| Sign_S3PutTrailingChecksum | 6.620 μs | 0.0215 μs | 0.0128 μs | 0.1807 |   5.31 KB |
