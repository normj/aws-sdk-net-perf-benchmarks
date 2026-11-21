```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 7.48 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                 | Mean          | Error       | StdDev      | Gen0   | Allocated |
|----------------------- |--------------:|------------:|------------:|-------:|----------:|
| NewRequest_Construct   |      6.845 ns |   0.0956 ns |   0.0569 ns | 0.0023 |      64 B |
| NewRequest_InvokeSync  | 13,089.929 ns |  51.1903 ns |  33.8592 ns | 0.3661 |   10800 B |
| NewRequest_InvokeAsync | 15,344.367 ns | 160.6872 ns | 106.2846 ns | 0.4272 |   12168 B |
