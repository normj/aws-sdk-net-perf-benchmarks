```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.85 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                 | Mean       | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|----------------------- |-----------:|----------:|----------:|-------:|-------:|----------:|
| Xml_HeaderOnlyResponse |   330.6 ns |  28.87 ns |  19.09 ns | 0.1257 | 0.0012 |   3.48 KB |
| Xml_SmallResponse      | 2,784.9 ns | 222.09 ns | 146.90 ns | 0.5301 | 0.0230 |  14.78 KB |
