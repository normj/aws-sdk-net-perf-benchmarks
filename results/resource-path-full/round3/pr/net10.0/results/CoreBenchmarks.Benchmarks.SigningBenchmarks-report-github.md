```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.54 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |-----------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost                     | 6,249.8 ns | 266.41 ns | 176.21 ns | 0.1476 |    4392 B |
| Sign_S3GetWithQuery               | 5,667.3 ns |  21.40 ns |  12.73 ns | 0.1593 |    4616 B |
| Presign_S3GetObject               | 6,280.0 ns |  30.99 ns |  18.44 ns | 0.2264 |    6672 B |
| Sign_RestJsonPathResources        | 6,350.7 ns |  53.32 ns |  31.73 ns | 0.1519 |    4600 B |
| Sign_S3GetObjectKey               | 4,954.1 ns |  20.41 ns |  13.50 ns | 0.1196 |    3528 B |
| CanonicalizeResourcePath_RestJson |   343.8 ns |   0.84 ns |   0.44 ns | 0.0125 |     376 B |
| CanonicalizeResourcePath_S3Key    |   297.7 ns |   1.25 ns |   0.75 ns | 0.0059 |     200 B |
