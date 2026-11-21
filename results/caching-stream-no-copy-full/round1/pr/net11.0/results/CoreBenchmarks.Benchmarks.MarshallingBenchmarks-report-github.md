```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.01 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                | Mean       | Error   | StdDev  | Gen0   | Gen1   | Allocated |
|---------------------- |-----------:|--------:|--------:|-------:|-------:|----------:|
| Error_JsonNoMessage   |   846.1 ns | 4.27 ns | 2.54 ns | 0.0817 |      - |   2.34 KB |
| CachingStream_Read16K | 1,949.1 ns | 9.77 ns | 5.81 ns | 1.0278 | 0.0779 |  28.38 KB |
