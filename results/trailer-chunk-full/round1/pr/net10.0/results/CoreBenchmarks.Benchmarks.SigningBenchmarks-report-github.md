```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.42GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.29 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method            | Mean        | Error     | StdDev    | Gen0   | Allocated |
|------------------ |------------:|----------:|----------:|-------:|----------:|
| ChunkedUpload_4KB |    14.15 μs |  0.759 μs |  0.502 μs | 0.4296 |  13.08 KB |
| ChunkedUpload_1MB | 1,086.30 μs | 85.455 μs | 56.523 μs | 4.1667 | 185.24 KB |
