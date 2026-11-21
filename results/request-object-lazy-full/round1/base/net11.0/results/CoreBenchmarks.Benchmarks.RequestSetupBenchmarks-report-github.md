```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.39GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 7.33 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                 | Mean         | Error      | StdDev     | Gen0   | Allocated |
|----------------------- |-------------:|-----------:|-----------:|-------:|----------:|
| NewRequest_Construct   |     35.62 ns |   0.243 ns |   0.161 ns | 0.0087 |     248 B |
| NewRequest_InvokeSync  | 12,292.86 ns | 267.644 ns | 159.270 ns | 0.3434 |   10984 B |
| NewRequest_InvokeAsync | 14,464.71 ns |  98.643 ns |  65.246 ns | 0.4051 |   12272 B |
