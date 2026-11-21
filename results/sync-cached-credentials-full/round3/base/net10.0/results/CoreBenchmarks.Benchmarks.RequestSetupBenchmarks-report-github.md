```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.85 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |---------:|---------:|---------:|-------:|----------:|
| Telemetry_InvokeAsync             | 19.18 μs | 0.121 μs | 0.080 μs | 0.5362 |  16.23 KB |
| NewRequest_InvokeAsync            | 15.86 μs | 0.049 μs | 0.029 μs | 0.3811 |  12.06 KB |
| RefreshingCredentials_InvokeAsync | 16.82 μs | 0.076 μs | 0.045 μs | 0.4028 |  12.35 KB |
