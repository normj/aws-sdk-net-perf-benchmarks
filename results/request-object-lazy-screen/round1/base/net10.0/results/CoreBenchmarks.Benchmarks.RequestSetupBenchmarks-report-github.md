```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.09 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                 | Mean         | Error      | StdDev     | Gen0   | Allocated |
|----------------------- |-------------:|-----------:|-----------:|-------:|----------:|
| NewRequest_Construct   |     45.63 ns |   5.726 ns |   1.487 ns | 0.0088 |     248 B |
| NewRequest_InvokeSync  | 14,085.60 ns | 618.505 ns | 220.565 ns | 0.3762 |   10984 B |
| NewRequest_InvokeAsync | 15,739.00 ns | 311.897 ns |  80.999 ns | 0.3815 |   12352 B |
