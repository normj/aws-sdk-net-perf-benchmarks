```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.62 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error       | StdDev      | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|------------:|------------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 75,689.9 ns |   210.76 ns |   125.42 ns | 0.9191 |      - |   31176 B |
| Xml_ListObjectsStructures | 83,900.2 ns |   157.65 ns |    82.45 ns | 1.0027 |      - |   37451 B |
| Xml_DateTimes             | 24,869.8 ns | 4,095.82 ns | 2,142.19 ns | 0.5796 |      - |   18055 B |
| Xml_WriteRequestBody      | 20,195.7 ns |   271.44 ns |   161.53 ns | 0.4814 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |    104.9 ns |     1.46 ns |     0.87 ns | 0.0104 |      - |     296 B |
| Xml_SmallResponse         |  2,544.3 ns |    82.29 ns |    54.43 ns | 0.4527 | 0.0197 |   12893 B |
