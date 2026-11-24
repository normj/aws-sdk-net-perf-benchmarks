```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.32 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.923 μs | 0.0506 μs | 0.0265 μs | 0.0708 |   2.43 KB |
| Sign_S3GetWithQuery        | 5.536 μs | 0.0202 μs | 0.0120 μs | 0.0887 |   2.88 KB |
| Presign_S3GetObject        | 6.445 μs | 0.0368 μs | 0.0244 μs | 0.1798 |   5.59 KB |
| Sign_RestJsonPathResources | 6.750 μs | 0.0171 μs | 0.0102 μs | 0.1078 |   3.58 KB |
| Sign_S3GetObjectKey        | 5.389 μs | 0.0492 μs | 0.0293 μs | 0.0864 |   2.98 KB |
| Sign_JsonPostPooledBody    | 6.816 μs | 0.0757 μs | 0.0450 μs | 0.1369 |   4.31 KB |
| Sign_S3PutTrailingChecksum | 6.650 μs | 0.0379 μs | 0.0198 μs | 0.1323 |   3.88 KB |
