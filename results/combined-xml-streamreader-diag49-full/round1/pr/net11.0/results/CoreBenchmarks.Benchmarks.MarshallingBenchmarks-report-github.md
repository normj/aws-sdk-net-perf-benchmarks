```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.05 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean         | Error      | StdDev     | Gen0   | Gen1   | Allocated |
|-------------------------- |-------------:|-----------:|-----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 69,726.87 ns | 178.862 ns | 106.438 ns | 0.8371 |      - |   31107 B |
| Xml_ListObjectsStructures | 78,639.69 ns | 456.511 ns | 301.953 ns | 1.2500 |      - |   37449 B |
| Xml_DateTimes             | 22,965.94 ns | 137.790 ns |  91.139 ns | 0.5523 |      - |   17987 B |
| Xml_WriteRequestBody      | 19,853.90 ns |  86.461 ns |  51.452 ns | 0.4753 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |     84.92 ns |   0.702 ns |   0.464 ns | 0.0101 |      - |     296 B |
| Xml_SmallResponse         |  2,410.86 ns |  12.703 ns |   8.402 ns | 0.5280 | 0.0192 |   15160 B |
