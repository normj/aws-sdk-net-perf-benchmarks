```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.44 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 69,857.8 ns | 491.67 ns | 292.58 ns | 0.8371 |      - |   31141 B |
| Xml_ListObjectsStructures | 78,600.7 ns | 356.42 ns | 212.10 ns | 1.2626 |      - |   37483 B |
| Xml_DateTimes             | 23,019.7 ns | 149.40 ns |  98.82 ns | 0.5499 |      - |   18020 B |
| Xml_WriteRequestBody      | 19,995.0 ns | 162.29 ns |  96.58 ns | 0.4771 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |    100.7 ns |   0.73 ns |   0.43 ns | 0.0102 |      - |     296 B |
| Xml_SmallResponse         |  2,329.5 ns |  10.05 ns |   6.65 ns | 0.4570 | 0.0187 |   12960 B |
