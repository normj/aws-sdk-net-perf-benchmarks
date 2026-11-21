```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.81 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method            | Mean        | Error    | StdDev   | Gen0   | Allocated |
|------------------ |------------:|---------:|---------:|-------:|----------:|
| ChunkedUpload_4KB |    13.47 μs | 0.111 μs | 0.073 μs | 0.5360 |  14.99 KB |
| ChunkedUpload_1MB | 1,015.06 μs | 2.892 μs | 1.721 μs | 3.9063 | 187.15 KB |
