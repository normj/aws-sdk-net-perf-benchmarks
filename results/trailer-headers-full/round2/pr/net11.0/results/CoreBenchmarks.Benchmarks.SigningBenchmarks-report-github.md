```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.78 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_S3GetWithQuery        | 5.650 μs | 0.0430 μs | 0.0285 μs | 0.1583 |   4.51 KB |
| Sign_S3GetObjectKey        | 5.508 μs | 0.0310 μs | 0.0205 μs | 0.1554 |   4.44 KB |
| Sign_S3PutTrailingChecksum | 6.747 μs | 0.0355 μs | 0.0211 μs | 0.1883 |   5.56 KB |
