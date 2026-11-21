```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.77 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_S3GetWithQuery        | 5.570 μs | 0.0296 μs | 0.0176 μs | 0.1560 |   4.51 KB |
| Sign_S3GetObjectKey        | 5.312 μs | 0.0240 μs | 0.0159 μs | 0.1489 |   4.44 KB |
| Sign_S3PutTrailingChecksum | 6.552 μs | 0.0439 μs | 0.0261 μs | 0.1834 |   5.56 KB |
