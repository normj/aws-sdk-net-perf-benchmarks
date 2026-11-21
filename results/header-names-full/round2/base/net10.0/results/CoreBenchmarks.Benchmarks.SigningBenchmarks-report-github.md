```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.58 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                     | Mean     | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost              | 5.991 μs | 0.0412 μs | 0.0245 μs | 0.1438 |   4.29 KB |
| Sign_S3GetWithQuery        | 5.587 μs | 0.0369 μs | 0.0244 μs | 0.1555 |   4.51 KB |
| Presign_S3GetObject        | 6.380 μs | 0.0304 μs | 0.0181 μs | 0.2552 |   7.16 KB |
| Sign_RestJsonPathResources | 6.702 μs | 0.0328 μs | 0.0217 μs | 0.1879 |    5.4 KB |
| Sign_S3GetObjectKey        | 5.477 μs | 0.0678 μs | 0.0403 μs | 0.1522 |   4.44 KB |
