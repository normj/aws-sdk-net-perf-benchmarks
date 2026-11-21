```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 7.55 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                 | Mean          | Error       | StdDev      | Gen0   | Allocated |
|----------------------- |--------------:|------------:|------------:|-------:|----------:|
| NewRequest_Construct   |      6.834 ns |   0.1848 ns |   0.1222 ns | 0.0023 |      64 B |
| NewRequest_InvokeSync  | 13,396.124 ns | 216.6529 ns | 128.9267 ns | 0.3720 |   10800 B |
| NewRequest_InvokeAsync | 15,538.189 ns | 127.2430 ns |  84.1633 ns | 0.3713 |   12168 B |
