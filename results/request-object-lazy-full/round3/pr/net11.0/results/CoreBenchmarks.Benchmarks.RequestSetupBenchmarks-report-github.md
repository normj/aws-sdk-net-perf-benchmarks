```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 7.53 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                 | Mean          | Error       | StdDev     | Gen0   | Allocated |
|----------------------- |--------------:|------------:|-----------:|-------:|----------:|
| NewRequest_Construct   |      7.118 ns |   0.0671 ns |  0.0444 ns | 0.0022 |      64 B |
| NewRequest_InvokeSync  | 12,351.216 ns |  53.1817 ns | 35.1764 ns | 0.3456 |   10800 B |
| NewRequest_InvokeAsync | 14,638.150 ns | 111.6381 ns | 73.8417 ns | 0.4135 |   12088 B |
