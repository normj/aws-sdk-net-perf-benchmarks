```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.03 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 69,613.8 ns | 501.70 ns | 331.85 ns | 0.8371 |      - |  30.39 KB |
| Xml_ListObjectsStructures | 79,177.9 ns | 674.29 ns | 446.00 ns | 1.2626 |      - |   36.6 KB |
| Xml_DateTimes             | 22,594.9 ns | 169.32 ns | 112.00 ns | 0.6304 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 19,745.2 ns | 114.34 ns |  75.63 ns | 0.4789 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    268.0 ns |   0.99 ns |   0.59 ns | 0.1260 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,381.5 ns |   9.05 ns |   5.39 ns | 0.5336 |      - |  14.82 KB |
