```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.77 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.053 μs | 0.0397 μs | 0.0262 μs | 0.1453 |   4.14 KB |
| Sign_S3GetWithQuery        | 5.631 μs | 0.0340 μs | 0.0225 μs | 0.1569 |   4.36 KB |
| Presign_S3GetObject        | 5.987 μs | 0.0523 μs | 0.0273 μs | 0.2143 |   6.01 KB |
| Sign_RestJsonPathResources | 6.732 μs | 0.0267 μs | 0.0176 μs | 0.1901 |   5.25 KB |
| Sign_S3GetObjectKey        | 5.474 μs | 0.0337 μs | 0.0223 μs | 0.1524 |   4.29 KB |
