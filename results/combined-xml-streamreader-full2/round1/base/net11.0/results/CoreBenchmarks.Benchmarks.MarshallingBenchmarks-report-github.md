```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.54 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|----------:|
| Xml_ListObjectsLike       | 72,767.3 ns | 497.01 ns | 328.74 ns | 0.8762 |  30.39 KB |
| Xml_ListObjectsStructures | 81,913.5 ns |  99.84 ns |  52.22 ns | 1.0081 |   36.6 KB |
| Xml_DateTimes             | 24,740.2 ns | 365.92 ns | 242.04 ns | 0.5924 |  17.58 KB |
| Xml_WriteRequestBody      | 21,254.7 ns | 176.63 ns | 116.83 ns | 0.4223 |  13.55 KB |
| Xml_HeaderOnlyResponse    |    663.4 ns |  55.03 ns |  36.40 ns | 0.1255 |   3.48 KB |
| Xml_SmallResponse         |  2,998.5 ns | 398.43 ns | 263.53 ns | 0.5364 |  14.82 KB |
