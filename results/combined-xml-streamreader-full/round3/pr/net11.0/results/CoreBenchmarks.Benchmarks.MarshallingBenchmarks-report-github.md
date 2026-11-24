```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.42GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.29 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 75,921.2 ns | 343.86 ns | 227.44 ns | 0.9102 |      - |   31176 B |
| Xml_ListObjectsStructures | 84,665.2 ns | 757.98 ns | 501.35 ns | 1.0135 |      - |   37451 B |
| Xml_DateTimes             | 24,225.1 ns |  72.39 ns |  47.88 ns | 0.6188 |      - |   18055 B |
| Xml_WriteRequestBody      | 19,854.3 ns |  22.39 ns |  11.71 ns | 0.4759 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |    102.2 ns |   1.58 ns |   0.94 ns | 0.0101 |      - |     296 B |
| Xml_SmallResponse         |  2,492.5 ns |   9.06 ns |   5.39 ns | 0.4501 | 0.0200 |   12893 B |
