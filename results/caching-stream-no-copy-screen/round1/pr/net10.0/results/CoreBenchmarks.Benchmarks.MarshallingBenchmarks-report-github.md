```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.45GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.32 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                | Mean       | Error     | StdDev   | Gen0   | Gen1   | Allocated |
|---------------------- |-----------:|----------:|---------:|-------:|-------:|----------:|
| Error_JsonNoMessage   |   993.2 ns |  37.76 ns | 13.46 ns | 0.0818 |      - |   2.34 KB |
| CachingStream_Read16K | 2,273.1 ns | 195.65 ns | 50.81 ns | 1.0225 | 0.0845 |  28.38 KB |
