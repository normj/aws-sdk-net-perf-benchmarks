```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 7.54 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                 | Mean         | Error      | StdDev    | Gen0   | Allocated |
|----------------------- |-------------:|-----------:|----------:|-------:|----------:|
| NewRequest_Construct   |     35.50 ns |   0.249 ns |  0.148 ns | 0.0087 |     248 B |
| NewRequest_InvokeSync  | 12,263.43 ns | 133.641 ns | 88.395 ns | 0.3467 |   10984 B |
| NewRequest_InvokeAsync | 14,584.91 ns |  50.106 ns | 26.207 ns | 0.4074 |   12272 B |
