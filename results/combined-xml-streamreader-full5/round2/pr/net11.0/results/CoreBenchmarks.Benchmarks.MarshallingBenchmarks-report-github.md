```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.36 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean         | Error      | StdDev     | Gen0   | Gen1   | Allocated |
|-------------------------- |-------------:|-----------:|-----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 69,660.24 ns | 507.919 ns | 335.957 ns | 0.8333 |      - |   31141 B |
| Xml_ListObjectsStructures | 78,077.54 ns | 770.544 ns | 509.667 ns | 1.2563 |      - |   37483 B |
| Xml_DateTimes             | 22,935.39 ns | 138.601 ns |  82.480 ns | 0.5523 |      - |   18020 B |
| Xml_WriteRequestBody      | 19,929.59 ns |  86.579 ns |  51.522 ns | 0.4741 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |     91.46 ns |   0.291 ns |   0.152 ns | 0.0104 |      - |     296 B |
| Xml_SmallResponse         |  2,339.44 ns |  29.949 ns |  19.809 ns | 0.4585 | 0.0187 |   12960 B |
