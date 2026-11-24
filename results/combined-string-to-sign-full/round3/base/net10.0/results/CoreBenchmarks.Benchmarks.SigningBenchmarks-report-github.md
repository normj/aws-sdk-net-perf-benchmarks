```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.74 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.035 μs | 0.0185 μs | 0.0110 μs | 0.1454 |   4.29 KB |
| Sign_S3GetWithQuery        | 5.616 μs | 0.0118 μs | 0.0070 μs | 0.1572 |   4.51 KB |
| Presign_S3GetObject        | 6.482 μs | 0.0448 μs | 0.0266 μs | 0.2590 |   7.16 KB |
| Sign_RestJsonPathResources | 6.853 μs | 0.1104 μs | 0.0730 μs | 0.1901 |    5.4 KB |
| Sign_S3GetObjectKey        | 5.422 μs | 0.0211 μs | 0.0125 μs | 0.1524 |   4.44 KB |
| Sign_JsonPostPooledBody    | 6.786 μs | 0.0569 μs | 0.0376 μs | 0.2170 |   6.17 KB |
| Sign_S3PutTrailingChecksum | 6.686 μs | 0.0253 μs | 0.0151 μs | 0.1872 |   5.84 KB |
