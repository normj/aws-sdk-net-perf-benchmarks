```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.47 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 75,909.1 ns | 334.69 ns | 175.05 ns | 0.9058 |      - |   31176 B |
| Xml_ListObjectsStructures | 83,894.3 ns | 380.71 ns | 251.82 ns | 1.0027 |      - |   37451 B |
| Xml_DateTimes             | 24,703.0 ns | 997.84 ns | 660.01 ns | 0.5814 |      - |   18055 B |
| Xml_WriteRequestBody      | 19,524.5 ns | 193.06 ns | 127.70 ns | 0.4664 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |    108.0 ns |   0.93 ns |   0.55 ns | 0.0103 |      - |     296 B |
| Xml_SmallResponse         |  2,447.9 ns |   6.19 ns |   3.24 ns | 0.4478 | 0.0195 |   12893 B |
