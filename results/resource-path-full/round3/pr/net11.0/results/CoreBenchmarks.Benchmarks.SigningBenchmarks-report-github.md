```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.18 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|---------:|---------:|-------:|----------:|
| Sign_JsonPost                     | 5,995.7 ns | 27.42 ns | 14.34 ns | 0.1435 |    4392 B |
| Sign_S3GetWithQuery               | 5,581.8 ns |  9.08 ns |  4.75 ns | 0.1555 |    4616 B |
| Presign_S3GetObject               | 6,303.0 ns | 16.02 ns |  9.53 ns | 0.2259 |    6672 B |
| Sign_RestJsonPathResources        | 6,244.1 ns | 33.91 ns | 22.43 ns | 0.1498 |    4600 B |
| Sign_S3GetObjectKey               | 5,012.6 ns | 33.72 ns | 22.30 ns | 0.1205 |    3528 B |
| CanonicalizeResourcePath_RestJson |   323.7 ns |  1.86 ns |  1.23 ns | 0.0129 |     376 B |
| CanonicalizeResourcePath_S3Key    |   305.1 ns |  1.65 ns |  0.98 ns | 0.0061 |     200 B |
