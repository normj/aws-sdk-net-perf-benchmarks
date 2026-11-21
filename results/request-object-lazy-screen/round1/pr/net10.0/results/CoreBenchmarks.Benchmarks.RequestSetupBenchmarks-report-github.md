```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.65 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                 | Mean          | Error       | StdDev     | Gen0   | Allocated |
|----------------------- |--------------:|------------:|-----------:|-------:|----------:|
| NewRequest_Construct   |      7.118 ns |   0.2349 ns |  0.0838 ns | 0.0023 |      64 B |
| NewRequest_InvokeSync  | 13,069.025 ns | 221.6153 ns | 57.5528 ns | 0.3658 |   10800 B |
| NewRequest_InvokeAsync | 15,296.483 ns | 167.0095 ns | 43.3718 ns | 0.4306 |   12168 B |
