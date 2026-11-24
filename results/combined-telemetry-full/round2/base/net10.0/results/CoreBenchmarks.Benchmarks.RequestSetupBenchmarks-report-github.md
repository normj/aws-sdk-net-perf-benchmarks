```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.85 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                | Mean     | Error    | StdDev   | Gen0   | Allocated |
|---------------------- |---------:|---------:|---------:|-------:|----------:|
| Telemetry_InvokeSync  | 18.80 μs | 1.047 μs | 0.693 μs | 0.5023 |  14.89 KB |
| Telemetry_InvokeAsync | 21.73 μs | 1.375 μs | 0.910 μs | 0.5818 |  16.23 KB |
