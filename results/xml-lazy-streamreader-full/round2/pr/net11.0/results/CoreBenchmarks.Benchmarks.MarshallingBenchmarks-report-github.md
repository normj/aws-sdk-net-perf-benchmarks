```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.84 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                 | Mean        | Error        | StdDev     | Gen0   | Gen1   | Allocated |
|----------------------- |------------:|-------------:|-----------:|-------:|-------:|----------:|
| Xml_HeaderOnlyResponse |    74.54 ns |     4.421 ns |   2.924 ns | 0.0103 |      - |     296 B |
| Xml_SmallResponse      | 3,354.17 ns | 1,092.254 ns | 722.459 ns | 0.5309 | 0.0166 |   15224 B |
