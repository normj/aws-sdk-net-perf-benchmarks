```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.84 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |---------:|---------:|---------:|-------:|----------:|
| Telemetry_InvokeAsync             | 19.13 μs | 0.103 μs | 0.054 μs | 0.5342 |  16.09 KB |
| NewRequest_InvokeAsync            | 15.98 μs | 0.020 μs | 0.012 μs | 0.3827 |  11.92 KB |
| RefreshingCredentials_InvokeAsync | 16.82 μs | 0.067 μs | 0.040 μs | 0.4041 |  12.21 KB |
