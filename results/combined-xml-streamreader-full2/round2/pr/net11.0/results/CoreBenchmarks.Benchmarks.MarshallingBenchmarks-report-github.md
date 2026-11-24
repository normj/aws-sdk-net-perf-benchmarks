```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.53 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean         | Error      | StdDev     | Gen0   | Gen1   | Allocated |
|-------------------------- |-------------:|-----------:|-----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 76,472.19 ns | 548.512 ns | 362.807 ns | 0.9191 |      - |   31176 B |
| Xml_ListObjectsStructures | 85,826.01 ns | 169.975 ns |  88.900 ns | 1.0246 |      - |   37451 B |
| Xml_DateTimes             | 24,006.66 ns | 131.800 ns |  68.934 ns | 0.5952 |      - |   18055 B |
| Xml_WriteRequestBody      | 19,795.75 ns | 213.662 ns | 141.324 ns | 0.4711 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |     99.46 ns |   0.367 ns |   0.192 ns | 0.0103 |      - |     296 B |
| Xml_SmallResponse         |  2,574.94 ns |  55.337 ns |  36.602 ns | 0.4493 | 0.0104 |   12893 B |
