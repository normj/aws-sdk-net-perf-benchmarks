```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.75 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean       | Error     | StdDev   | Gen0   | Allocated |
|---------------------------------- |-----------:|----------:|---------:|-------:|----------:|
| Sign_JsonPost                     | 6,171.6 ns | 148.14 ns | 97.99 ns | 0.1423 |   4.18 KB |
| Sign_RestJsonPathResources        | 6,762.6 ns |  96.71 ns | 57.55 ns | 0.1906 |   5.29 KB |
| CanonicalizeResourcePath_RestJson |   703.9 ns |  15.04 ns |  8.95 ns | 0.0446 |   1.27 KB |
| Sign_JsonPostPooledBody           | 6,758.0 ns |  39.52 ns | 23.52 ns | 0.2160 |   6.12 KB |
| ContentStreamHash_PooledJson      |   748.8 ns |  29.91 ns | 15.64 ns | 0.0421 |    1.2 KB |
