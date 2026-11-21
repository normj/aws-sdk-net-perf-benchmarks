```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.39 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|------------------ |----------:|---------:|---------:|-------:|----------:|
| ChunkedUpload_4KB |  12.72 μs | 0.070 μs | 0.041 μs | 0.4088 |  12.63 KB |
| ChunkedUpload_1MB | 998.00 μs | 4.576 μs | 3.027 μs | 3.9063 | 164.64 KB |
