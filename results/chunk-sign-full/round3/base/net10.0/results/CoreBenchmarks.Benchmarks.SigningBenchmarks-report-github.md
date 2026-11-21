```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.39 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method            | Mean        | Error    | StdDev   | Gen0   | Allocated |
|------------------ |------------:|---------:|---------:|-------:|----------:|
| ChunkedUpload_4KB |    13.31 μs | 0.085 μs | 0.056 μs | 0.5315 |  14.99 KB |
| ChunkedUpload_1MB | 1,014.38 μs | 6.224 μs | 3.704 μs | 3.9063 | 187.15 KB |
