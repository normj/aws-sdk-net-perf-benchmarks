```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.19 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method            | Mean        | Error    | StdDev   | Gen0   | Allocated |
|------------------ |------------:|---------:|---------:|-------:|----------:|
| ChunkedUpload_4KB |    13.02 μs | 0.126 μs | 0.084 μs | 0.4747 |  13.08 KB |
| ChunkedUpload_1MB | 1,010.58 μs | 5.006 μs | 2.979 μs | 3.9063 | 185.24 KB |
