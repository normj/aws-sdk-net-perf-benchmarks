```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.97 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method              | Mean     | Error     | StdDev    | Gen0   | Allocated |
|-------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_S3GetWithQuery | 5.417 μs | 0.4979 μs | 0.2604 μs | 0.1268 |   3.99 KB |
| Presign_S3GetObject | 6.326 μs | 0.0285 μs | 0.0169 μs | 0.2277 |   6.82 KB |
| Sign_S3GetObjectKey | 5.431 μs | 0.0760 μs | 0.0452 μs | 0.1504 |   4.44 KB |
