```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.71 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |---------:|---------:|---------:|-------:|----------:|
| Telemetry_InvokeAsync             | 18.40 μs | 0.145 μs | 0.086 μs | 0.5153 |  16.01 KB |
| NewRequest_InvokeAsync            | 14.84 μs | 0.054 μs | 0.028 μs | 0.4163 |  11.84 KB |
| RefreshingCredentials_InvokeAsync | 15.74 μs | 0.044 μs | 0.023 μs | 0.4393 |  12.13 KB |
