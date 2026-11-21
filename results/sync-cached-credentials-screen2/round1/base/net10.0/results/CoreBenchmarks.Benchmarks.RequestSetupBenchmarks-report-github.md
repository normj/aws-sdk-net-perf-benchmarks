```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.5 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |---------:|---------:|---------:|-------:|----------:|
| Telemetry_InvokeAsync             | 19.23 μs | 0.281 μs | 0.073 μs | 0.5489 |  16.23 KB |
| NewRequest_InvokeAsync            | 15.74 μs | 0.062 μs | 0.022 μs | 0.3776 |  12.06 KB |
| RefreshingCredentials_InvokeAsync | 16.54 μs | 0.344 μs | 0.123 μs | 0.4067 |  12.35 KB |
