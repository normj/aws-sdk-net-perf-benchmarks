```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.47 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.716 μs | 0.0211 μs | 0.0111 μs | 0.0689 |   2.43 KB |
| Sign_S3GetWithQuery        | 5.319 μs | 0.1225 μs | 0.0810 μs | 0.0839 |   2.88 KB |
| Presign_S3GetObject        | 6.094 μs | 0.0726 μs | 0.0481 μs | 0.1939 |   5.59 KB |
| Sign_RestJsonPathResources | 6.448 μs | 0.0599 μs | 0.0396 μs | 0.1277 |   3.58 KB |
| Sign_S3GetObjectKey        | 5.095 μs | 0.0196 μs | 0.0117 μs | 0.1016 |   2.98 KB |
| Sign_JsonPostPooledBody    | 6.411 μs | 0.0250 μs | 0.0149 μs | 0.1536 |   4.31 KB |
| Sign_S3PutTrailingChecksum | 6.320 μs | 0.0284 μs | 0.0188 μs | 0.1265 |   3.88 KB |
