```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.45 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error       | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|------------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 76,625.0 ns |   498.88 ns | 296.87 ns | 0.9191 |      - |   31176 B |
| Xml_ListObjectsStructures | 85,255.1 ns | 1,276.99 ns | 759.92 ns | 1.0302 |      - |   37451 B |
| Xml_DateTimes             | 24,632.5 ns |   184.94 ns | 122.33 ns | 0.6039 |      - |   18055 B |
| Xml_WriteRequestBody      | 20,191.6 ns |    87.25 ns |  45.63 ns | 0.4783 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |    118.0 ns |    33.28 ns |  22.02 ns | 0.0102 |      - |     296 B |
| Xml_SmallResponse         |  2,478.0 ns |    18.38 ns |   9.61 ns | 0.4564 | 0.0106 |   12893 B |
