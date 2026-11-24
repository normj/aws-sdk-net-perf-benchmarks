```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.17 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                | Mean     | Error    | StdDev   | Gen0   | Allocated |
|---------------------- |---------:|---------:|---------:|-------:|----------:|
| Telemetry_InvokeSync  | 17.30 μs | 0.704 μs | 0.419 μs | 0.4639 |  13.21 KB |
| Telemetry_InvokeAsync | 20.20 μs | 0.481 μs | 0.251 μs | 0.4670 |  14.47 KB |
