```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.39 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method            | Mean        | Error     | StdDev   | Gen0   | Allocated |
|------------------ |------------:|----------:|---------:|-------:|----------:|
| ChunkedUpload_4KB |    13.97 μs |  0.282 μs | 0.168 μs | 0.4952 |  14.98 KB |
| ChunkedUpload_1MB | 1,036.06 μs | 14.364 μs | 7.512 μs | 4.1667 | 187.15 KB |
