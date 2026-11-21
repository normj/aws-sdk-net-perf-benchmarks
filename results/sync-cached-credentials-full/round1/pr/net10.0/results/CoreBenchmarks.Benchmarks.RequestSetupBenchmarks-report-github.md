```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.71 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |---------:|---------:|---------:|-------:|----------:|
| Telemetry_InvokeAsync             | 19.29 μs | 0.148 μs | 0.088 μs | 0.5388 |  16.09 KB |
| NewRequest_InvokeAsync            | 15.60 μs | 0.078 μs | 0.052 μs | 0.3758 |  11.92 KB |
| RefreshingCredentials_InvokeAsync | 16.63 μs | 0.094 μs | 0.062 μs | 0.3977 |  12.21 KB |
