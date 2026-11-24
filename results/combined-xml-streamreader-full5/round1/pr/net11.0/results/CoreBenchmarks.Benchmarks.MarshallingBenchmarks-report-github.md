```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.36 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean         | Error      | StdDev     | Gen0   | Gen1   | Allocated |
|-------------------------- |-------------:|-----------:|-----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 69,174.92 ns | 678.074 ns | 448.504 ns | 1.1013 |      - |   31141 B |
| Xml_ListObjectsStructures | 78,257.09 ns | 182.387 ns |  95.392 ns | 1.2626 |      - |   37483 B |
| Xml_DateTimes             | 23,041.77 ns | 129.667 ns |  85.767 ns | 0.5523 |      - |   18020 B |
| Xml_WriteRequestBody      | 19,682.63 ns |  52.726 ns |  27.577 ns | 0.4711 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |     92.44 ns |   1.121 ns |   0.741 ns | 0.0102 |      - |     296 B |
| Xml_SmallResponse         |  2,329.05 ns |  12.918 ns |   7.688 ns | 0.4588 | 0.0187 |   12960 B |
