```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.39GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.64 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean         | Error      | StdDev     | Gen0   | Allocated |
|-------------------------- |-------------:|-----------:|-----------:|-------:|----------:|
| Xml_ListObjectsLike       | 69,455.17 ns |  79.382 ns |  47.239 ns | 0.8333 |   31107 B |
| Xml_ListObjectsStructures | 78,366.41 ns | 328.231 ns | 217.104 ns | 1.2563 |   37449 B |
| Xml_DateTimes             | 23,200.40 ns | 135.021 ns |  80.349 ns | 0.5556 |   17987 B |
| Xml_WriteRequestBody      | 19,727.88 ns |  62.967 ns |  41.649 ns | 0.4729 |   13880 B |
| Xml_HeaderOnlyResponse    |     87.91 ns |   0.320 ns |   0.167 ns | 0.0105 |     296 B |
| Xml_SmallResponse         |  2,408.87 ns |  11.235 ns |   7.431 ns | 0.5296 |   15160 B |
