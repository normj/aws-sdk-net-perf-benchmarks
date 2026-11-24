```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.72 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.976 μs | 0.0453 μs | 0.0300 μs | 0.1206 |   3.73 KB |
| Sign_S3GetWithQuery        | 5.457 μs | 0.0474 μs | 0.0282 μs | 0.1294 |   3.98 KB |
| Presign_S3GetObject        | 6.205 μs | 0.0404 μs | 0.0241 μs | 0.2238 |   6.63 KB |
| Sign_RestJsonPathResources | 7.504 μs | 0.2269 μs | 0.1501 μs | 0.1718 |   4.86 KB |
| Sign_S3GetObjectKey        | 5.333 μs | 0.0530 μs | 0.0350 μs | 0.1278 |   3.91 KB |
| Sign_JsonPostPooledBody    | 6.804 μs | 0.1693 μs | 0.1120 μs | 0.1870 |   5.62 KB |
| Sign_S3PutTrailingChecksum | 6.677 μs | 0.0660 μs | 0.0436 μs | 0.1865 |   5.31 KB |
