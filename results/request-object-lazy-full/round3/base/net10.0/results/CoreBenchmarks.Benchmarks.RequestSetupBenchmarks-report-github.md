```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 7.56 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                 | Mean         | Error      | StdDev    | Gen0   | Allocated |
|----------------------- |-------------:|-----------:|----------:|-------:|----------:|
| NewRequest_Construct   |     40.34 ns |   0.157 ns |  0.082 ns | 0.0087 |     248 B |
| NewRequest_InvokeSync  | 13,060.92 ns |  62.495 ns | 32.686 ns | 0.3652 |   10984 B |
| NewRequest_InvokeAsync | 15,429.35 ns | 103.508 ns | 61.596 ns | 0.4302 |   12352 B |
