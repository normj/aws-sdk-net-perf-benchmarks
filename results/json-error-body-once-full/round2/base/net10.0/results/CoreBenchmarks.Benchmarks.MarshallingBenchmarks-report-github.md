```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.39GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.6 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method              | Mean       | Error    | StdDev   | Gen0   | Allocated |
|-------------------- |-----------:|---------:|---------:|-------:|----------:|
| Error_Json          | 1,012.7 ns | 25.64 ns | 13.41 ns | 0.0808 |   2.28 KB |
| Error_JsonNoMessage |   973.2 ns | 37.99 ns | 25.13 ns | 0.0860 |   2.38 KB |
