```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.39 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_S3GetWithQuery        | 5.397 μs | 0.0268 μs | 0.0140 μs | 0.1517 |   4.51 KB |
| Sign_S3GetObjectKey        | 5.257 μs | 0.0123 μs | 0.0064 μs | 0.1475 |   4.44 KB |
| Sign_S3PutTrailingChecksum | 6.712 μs | 0.0328 μs | 0.0195 μs | 0.1878 |   5.84 KB |
