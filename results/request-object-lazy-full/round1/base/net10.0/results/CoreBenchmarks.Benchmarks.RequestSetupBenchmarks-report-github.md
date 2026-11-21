```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.54 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                 | Mean         | Error      | StdDev     | Gen0   | Allocated |
|----------------------- |-------------:|-----------:|-----------:|-------:|----------:|
| NewRequest_Construct   |     41.70 ns |   0.311 ns |   0.205 ns | 0.0087 |     248 B |
| NewRequest_InvokeSync  | 13,118.34 ns | 200.871 ns | 119.535 ns | 0.3658 |   10984 B |
| NewRequest_InvokeAsync | 15,632.11 ns |  95.836 ns |  63.390 ns | 0.4366 |   12352 B |
