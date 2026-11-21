```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 7.54 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                 | Mean          | Error       | StdDev     | Gen0   | Allocated |
|----------------------- |--------------:|------------:|-----------:|-------:|----------:|
| NewRequest_Construct   |      7.697 ns |   0.7662 ns |  0.5068 ns | 0.0023 |      64 B |
| NewRequest_InvokeSync  | 12,371.301 ns | 183.8315 ns | 96.1474 ns | 0.3456 |   10800 B |
| NewRequest_InvokeAsync | 14,425.756 ns |  75.6623 ns | 45.0254 ns | 0.4043 |   12088 B |
