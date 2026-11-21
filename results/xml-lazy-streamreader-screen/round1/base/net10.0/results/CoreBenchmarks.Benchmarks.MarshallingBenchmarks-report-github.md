```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.95 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                 | Mean       | Error    | StdDev   | Gen0   | Gen1   | Allocated |
|----------------------- |-----------:|---------:|---------:|-------:|-------:|----------:|
| Xml_HeaderOnlyResponse |   272.5 ns |  3.94 ns |  1.41 ns | 0.1260 | 0.0011 |   3.48 KB |
| Xml_SmallResponse      | 2,473.4 ns | 50.05 ns | 17.85 ns | 0.5357 | 0.0198 |  14.78 KB |
