```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.73 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 6.310 μs | 0.0288 μs | 0.0191 μs | 0.1011 |   2.98 KB |
| Sign_S3GetWithQuery        | 5.840 μs | 0.0099 μs | 0.0052 μs | 0.1172 |   3.41 KB |
| Presign_S3GetObject        | 6.866 μs | 0.0893 μs | 0.0591 μs | 0.2195 |   6.12 KB |
| Sign_RestJsonPathResources | 6.805 μs | 0.0837 μs | 0.0498 μs | 0.1361 |   4.12 KB |
| Sign_S3GetObjectKey        | 5.441 μs | 0.0245 μs | 0.0162 μs | 0.1084 |    3.5 KB |
| Sign_JsonPostPooledBody    | 6.898 μs | 0.0604 μs | 0.0400 μs | 0.1648 |   4.87 KB |
| Sign_S3PutTrailingChecksum | 6.591 μs | 0.0105 μs | 0.0063 μs | 0.1586 |    4.4 KB |
