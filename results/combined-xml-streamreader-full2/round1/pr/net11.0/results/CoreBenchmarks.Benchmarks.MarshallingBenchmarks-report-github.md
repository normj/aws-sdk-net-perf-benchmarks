```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.39GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.53 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 76,704.5 ns | 619.26 ns | 323.89 ns | 0.9236 |      - |   31176 B |
| Xml_ListObjectsStructures | 85,509.7 ns | 358.74 ns | 213.48 ns | 1.0190 |      - |   37451 B |
| Xml_DateTimes             | 24,320.3 ns |  88.70 ns |  58.67 ns | 0.5823 |      - |   18055 B |
| Xml_WriteRequestBody      | 19,820.4 ns | 382.40 ns | 227.56 ns | 0.4729 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |    100.4 ns |   0.37 ns |   0.19 ns | 0.0104 |      - |     296 B |
| Xml_SmallResponse         |  2,629.9 ns |   3.53 ns |   1.85 ns | 0.4517 | 0.0105 |   12893 B |
