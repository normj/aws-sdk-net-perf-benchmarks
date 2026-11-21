```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.3 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error       | StdDev      | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|------------:|------------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 69,233.3 ns | 2,287.65 ns | 1,513.14 ns | 1.0965 |      - |  30.39 KB |
| Xml_ListObjectsStructures | 77,017.2 ns |   328.96 ns |   195.76 ns | 1.2315 |      - |   36.6 KB |
| Xml_DateTimes             | 22,699.5 ns |    28.45 ns |    14.88 ns | 0.6350 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 19,730.0 ns |   493.64 ns |   293.76 ns | 0.4682 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    269.9 ns |     1.97 ns |     1.03 ns | 0.1260 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,379.5 ns |     5.88 ns |     3.07 ns | 0.5317 |      - |  14.82 KB |
