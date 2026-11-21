```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.69 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.055 μs | 0.0615 μs | 0.0407 μs | 0.1205 |   3.91 KB |
| Sign_S3GetWithQuery        | 5.555 μs | 0.0402 μs | 0.0210 μs | 0.1334 |   4.28 KB |
| Presign_S3GetObject        | 6.630 μs | 0.0230 μs | 0.0121 μs | 0.2387 |    7.1 KB |
| Sign_RestJsonPathResources | 6.643 μs | 0.0541 μs | 0.0358 μs | 0.1602 |   5.07 KB |
| Sign_S3GetObjectKey        | 5.407 μs | 0.0435 μs | 0.0288 μs | 0.1507 |   4.21 KB |
